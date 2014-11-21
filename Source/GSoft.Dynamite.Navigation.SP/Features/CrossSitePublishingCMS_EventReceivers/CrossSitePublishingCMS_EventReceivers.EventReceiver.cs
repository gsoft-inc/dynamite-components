using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_EventReceivers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("01031036-6b13-42bc-a9f5-142eabaa7f48")]
    public class CrossSitePublishingCMS_EventReceiversEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<INavigationEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<NavigationEventReceiverInfos>();

                    // Add only Browsable Item events
                    baseEventReceivers.Clear();

                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemUpdated());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemUpdated());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemDeleted());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemDeleting());

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.AddEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<INavigationEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<NavigationEventReceiverInfos>();

                    // Add only Browsable Item events
                    baseEventReceivers.Clear();

                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemUpdated());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemUpdated());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemDeleted());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemDeleting());

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Deleting event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.DeleteEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }
    }
}
