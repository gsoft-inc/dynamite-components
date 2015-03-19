using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Search.SP.Features.CrossSitePublishingCMS_BrowsableItemsEventReceivers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("ac2ff9db-0d0e-467b-bf0f-a53aed313d69")]
    public class CrossSitePublishingCMS_BrowsableItemsEventReceiversEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Creates event receivers for the <c>browsable</c> item content type
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = SearchContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<ISearchEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<SearchEventReceiverInfos>();

                    // Add only Browsable Item events
                    baseEventReceivers.Clear();

                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemUpdated());

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.AddEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes event receivers for the <c>browsable</c> item content type
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = SearchContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<ISearchEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<SearchEventReceiverInfos>();

                    // Add only Browsable Item events
                    baseEventReceivers.Clear();

                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.BrowsableItemItemUpdated());

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
