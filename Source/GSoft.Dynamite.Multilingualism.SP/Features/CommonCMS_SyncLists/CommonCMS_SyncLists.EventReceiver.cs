using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.TimerJobs;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CommonCMS_SyncLists
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("ce7da170-56ee-4a68-8067-f3e38d3ac69f")]
    public class CommonCMS_SyncListsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Fires when the feature is activated. Looks for ListInfo objects registered on the IPublishingListInfoConfig
        /// for the property IsSynced to determine which lists to for variations syncing on.
        /// </summary>
        /// <param name="properties">The feature activation context</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var variationSyncHelper = featureScope.Resolve<IVariationSyncHelper>();
                    var timerJobHelper = featureScope.Resolve<ITimerJobHelper>();
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var variationSettingsConfig = featureScope.Resolve<IMultilingualismVariationsConfig>();
                    var listInfoConfig = featureScope.Resolve<IPublishingListInfoConfig>();
                    var variationSettings = variationSettingsConfig.VariationSettings();

                    if (variationSettings != null)
                    {
                        var lists = listInfoConfig.Lists;

                        // Sync lists (only those with IsSynced = TRUE)
                        bool needsAtLeastOneSync = false;
                        foreach (var list in lists)
                        {
                            if (list.IsSynced)
                            {
                                logger.Info("Synchronize variations for list {0} in web {1}", resourceLocator.Find(list.DisplayNameResourceKey), web.Url);
                                variationSyncHelper.SyncList(web, list, variationSettings.Labels.ToList());
                                needsAtLeastOneSync = true;

                                // Extra trick: we need to prevent the taxonomy field definitions on the target list from getting updated
                                // whenever a list item gets variated.
                                var pubWeb = PublishingWeb.GetPublishingWeb(web);
                                foreach (var targetWebUrl in pubWeb.VariationPublishingWebUrls)
                                {
                                    using (var site = new SPSite(targetWebUrl))
                                    {
                                        using (var targetWeb = site.OpenWeb())
                                        {
                                            eventReceiverHelper.AddListEventReceiverDefinition(
                                                targetWeb,
                                                new EventReceiverInfo(
                                                    list,
                                                    SPEventReceiverType.FieldUpdating,
                                                    SPEventReceiverSynchronization.Synchronous)
                                                {
                                                    AssemblyName = Assembly.GetExecutingAssembly().FullName,
                                                    ClassName = "GSoft.Dynamite.Multilingualism.SP.Events.VariationTargetListEvents"
                                                });
                                        }
                                    }
                                }
                            }
                        }

                        if (needsAtLeastOneSync)
                        {
                            // Only after a timer job run will the sync be locked in.
                            // If the lists were already present on the target webs, they will be connected to the source list.
                            // If the lists didn't exist yet, the timer job should create them at the destination.
                            timerJobHelper.StartAndWaitForJob(web.Site, BuiltInVariationsTimerJobs.VariationsSpawnSites);
                        }
                    }
                }
            }
        }
    }
}
