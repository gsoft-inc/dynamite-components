using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Events;

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
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", eventReceiver.ContentType.DisplayName);

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                        eventReceiver.ClassName = "GSoft.Dynamite.Multilingualism.SP.Events.TranslatableItemEvents";

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
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var eventReceiverHelper = featureScope.Resolve<IEventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<IMultilingualismEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Deleting event receiver for content type {0}", eventReceiver.ContentType.DisplayName);

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                        eventReceiver.ClassName = "GSoft.Dynamite.Multilingualism.SP.Events.TranslatableItemEvents";

                        eventReceiverHelper.DeleteEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }
    }
}
