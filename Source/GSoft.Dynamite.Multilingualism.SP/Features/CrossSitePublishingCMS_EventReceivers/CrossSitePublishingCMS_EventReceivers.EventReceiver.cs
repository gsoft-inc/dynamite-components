using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CrossSitePublishingCMS_EventReceivers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("ebb45495-7d0c-407e-abb6-2a64c7322e25")]
    public class CrossSitePublishingCMS_EventReceiversEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Adds event receivers for the multilingualism module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<IMultilingualismEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                        eventReceiver.ClassName = "GSoft.Dynamite.Multilingualism.SP.Events.TranslatableItemEvents";

                        eventReceiverHelper.AddEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }

        /// <summary>
        /// Removes event receivers for the multilingualism module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<IMultilingualismEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Deleting event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                        eventReceiver.ClassName = "GSoft.Dynamite.Multilingualism.SP.Events.TranslatableItemEvents";

                        eventReceiverHelper.DeleteEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }
    }
}
