using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CommonCMS_NavigationEventReceivers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("7c3fcc9d-c9b4-4e75-bde4-7d052a102383")]
    public class CommonCMS_NavigationEventReceiversEventReceiver : SPFeatureReceiver
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
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var baseReceiversConfig = featureScope.Resolve<INavigationEventReceiverInfoConfig>();
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var eventReceiverInfo in baseReceiversConfig.EventReceivers)
                    {
                        // Do it for content type and list
                        eventReceiverHelper.AddContentTypeEventReceiverDefinition(site, eventReceiverInfo);
                        logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiverInfo.ContentType.DisplayNameResourceKey));
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
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var baseReceiversConfig = featureScope.Resolve<INavigationEventReceiverInfoConfig>();
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var eventReceiver in baseReceiversConfig.EventReceivers)
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
