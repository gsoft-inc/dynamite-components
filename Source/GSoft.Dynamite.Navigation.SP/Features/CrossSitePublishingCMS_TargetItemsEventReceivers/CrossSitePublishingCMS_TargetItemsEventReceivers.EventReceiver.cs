using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_TargetItemsEventReceivers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("8cb2ec32-a732-4818-acfd-16ff2826d617")]
    public class CrossSitePublishingCMS_TargetItemsEventReceiversEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Adds event receivers for the target item content type. Only used with Cross Site Publishing CMS based solutions.
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<NavigationEventReceiverInfos>();

                    // Add only Target Item events
                    var targetItemEventReceivers = new List<EventReceiverInfo>();

                    targetItemEventReceivers.Add(eventReceiversInfos.TargetContentItemItemAdded());
                    targetItemEventReceivers.Add(eventReceiversInfos.TargetContentItemItemUpdated());
                    targetItemEventReceivers.Add(eventReceiversInfos.TargetContentItemItemDeleted());

                    foreach (var eventReceiver in targetItemEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.AddContentTypeEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }

        /// <summary>
        /// Removes event receivers for the target item content type. Only used with Cross Site Publishing CMS based solutions.
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<NavigationEventReceiverInfos>();

                    // Add only Target Item events
                    var baseEventReceivers = new List<EventReceiverInfo>();
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemUpdated());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentItemItemDeleted());

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Deleting event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.DeleteContentTypeEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }
    }
}
