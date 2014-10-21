using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
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
                    var eventReceiverHelper = featureScope.Resolve<EventReceiverHelper>();
                    var baseReceiversConfig = featureScope.Resolve<INavigationEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", eventReceiver.ContentType.DisplayName);

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                        eventReceiver.ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsableItemEvents";

                        eventReceiverHelper.AddEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }
    }
}
