using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.StandardPublishingCMS_TargetPagesEventReceivers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("6eac4235-6c4b-4f2a-985e-9cd3e6c3a801")]
    public class SimplePublishingCMS_EventReceiversEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Adds event receivers for the target page content type. Only used with Standard Publishing CMS based solutions.
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
                    var navigationTermService = featureScope.Resolve<INavigationTermBuilderService>();

                    // Fix any pages that are no longer properly mapped to their term.
                    // This is in the case where the term set was updated using PowerShell clearing all term driven page settings.
                    foreach (SPWeb web in site.AllWebs)
                    {
                        navigationTermService.SetTermDrivenPageForTerms(web);
                    }                   

                    // Add only Browsable Page events
                    var baseEventReceivers = new List<EventReceiverInfo>();
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentPageItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentPageUpdated());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentPageDeleted());

                    foreach (var eventReceiver in baseEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.AddContentTypeEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }

        /// <summary>
        /// Removes event receivers for the target page content type. Only used with Standard Publishing CMS based solutions.
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
                    var baseReceiversConfig = featureScope.Resolve<INavigationEventReceiverInfoConfig>();
                    var baseEventReceivers = baseReceiversConfig.EventReceivers;
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<NavigationEventReceiverInfos>();

                    // Add only Browsable Page events
                    baseEventReceivers.Clear();

                    baseEventReceivers.Add(eventReceiversInfos.TargetContentPageItemAdded());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentPageUpdated());
                    baseEventReceivers.Add(eventReceiversInfos.TargetContentPageDeleted());

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
