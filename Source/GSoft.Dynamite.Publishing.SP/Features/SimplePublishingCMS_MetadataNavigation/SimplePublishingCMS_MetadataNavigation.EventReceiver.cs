using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.SimplePublishingCNS_MetadataNavigation
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("57cc183d-36cf-4514-8fb3-0ea0f7e92dc7")]
    public class SimplePublishingCMS_MetadataNavigationEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var settings = featureScope.Resolve<IPublishingMetadataNavigationSettingsConfig>().MetadataNavigationSettings;
                    var metadataNavigationInfos = featureScope.Resolve<PublishingMetadataNavigationSettingsInfos>();
                    var logger = featureScope.Resolve<ILogger>();

                    settings.Clear();
                    settings.Add(metadataNavigationInfos.PagesLibraryNavigation);

                    foreach (var setting in settings)
                    {
                        logger.Info("Configuring metadata navigation on list {0} in web {1}", setting.List.WebRelativeUrl, web.Url);
                        listHelper.SetMetadataNavigation(web, setting);
                    }
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var settings = featureScope.Resolve<IPublishingMetadataNavigationSettingsConfig>().MetadataNavigationSettings;
                    var metadataNavigationInfos = featureScope.Resolve<PublishingMetadataNavigationSettingsInfos>();
                    var logger = featureScope.Resolve<ILogger>();

                    settings.Clear();
                    settings.Add(new MetadataNavigationSettingsInfo(metadataNavigationInfos.PagesLibraryNavigation.List, true, false, false));


                    foreach (var setting in settings)
                    {
                        // Reset the configuration
                        logger.Info("Reset metadata navigation on list {0} in web {1}", setting.List.WebRelativeUrl, web.Url);
                        listHelper.SetMetadataNavigation(web, setting);
                    }
                }
            }
        }
    }
}
