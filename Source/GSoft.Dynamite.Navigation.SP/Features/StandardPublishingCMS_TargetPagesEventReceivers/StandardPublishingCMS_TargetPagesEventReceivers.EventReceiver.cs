using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

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
                    var variationHelper = featureScope.Resolve<IVariationHelper>();

                    var eventReceiversInfos = featureScope.Resolve<NavigationEventReceiverInfos>();
                    var navigationTermService = featureScope.Resolve<INavigationTermBuilderService>();

                    // Fix any pages that are no longer properly mapped to their term.
                    // This is in the case where the term set was updated using PowerShell clearing all term driven page settings.
                    foreach (SPWeb web in site.AllWebs)
                    {
                        navigationTermService.SetTermDrivenPageForTerms(web);
                    }                   

                    // Add only Browsable Page events
                    var targetContentPageEventReceivers = new List<EventReceiverInfo>();
                    targetContentPageEventReceivers.Add(eventReceiversInfos.TargetContentPageItemAdded());
                    targetContentPageEventReceivers.Add(eventReceiversInfos.TargetContentPageUpdated());
                    targetContentPageEventReceivers.Add(eventReceiversInfos.TargetContentPageDeleting());

                    foreach (var eventReceiver in targetContentPageEventReceivers)
                    {
                        logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.AddContentTypeEventReceiverDefinition(site, eventReceiver);
                    }

                    // Prevent Navigation field on target webs' Pages libraries from being re-mapped to the
                    // source web's navigation term set every time a page variation gets propagated.
                    // We want to keep the target-label-specific navigation term set connected to our list column.
                    if (variationHelper.IsVariationsEnabled(site))
                    {
                        var variationLabels = variationHelper.GetVariationLabels(site);
                        
                        foreach (VariationLabel label in variationLabels)
                        {
                            if (!label.IsSource)
                            {
                                var variationTargetLabelWeb = site.AllWebs[label.Title];    // a variation label's title corresponds to its root-web-relative URL
                                var pagesLibraryOnTargetLabelWeb = variationTargetLabelWeb.GetPagesLibrary();
                                var webRelativeUrl = pagesLibraryOnTargetLabelWeb.RootFolder.Url;

                                ApplyEventReceiverToAllSubWebListsRecursively(eventReceiverHelper, logger, variationTargetLabelWeb, webRelativeUrl);
                            }
                        }
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
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var logger = featureScope.Resolve<ILogger>();

                    var eventReceiversInfos = featureScope.Resolve<NavigationEventReceiverInfos>();

                    // Add only Browsable Page events
                    var targetContentPageEventReceivers = new List<EventReceiverInfo>();

                    targetContentPageEventReceivers.Add(eventReceiversInfos.TargetContentPageItemAdded());
                    targetContentPageEventReceivers.Add(eventReceiversInfos.TargetContentPageUpdated());
                    targetContentPageEventReceivers.Add(eventReceiversInfos.TargetContentPageDeleting());

                    // For legacy purposes: unregister the old broken ItemDeleted event
                    var itemDeleted = eventReceiversInfos.TargetContentPageDeleting();
                    itemDeleted.ReceiverType = SPEventReceiverType.ItemDeleted;
                    targetContentPageEventReceivers.Add(itemDeleted);

                    foreach (var eventReceiver in targetContentPageEventReceivers)
                    {
                        logger.Info("Deleting event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                        eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;

                        eventReceiverHelper.DeleteContentTypeEventReceiverDefinition(site, eventReceiver);
                    }
                }
            }
        }

        private static void ApplyEventReceiverToAllSubWebListsRecursively(IEventReceiverHelper eventReceiverHelper, ILogger logger, SPWeb variationTargetLabelWeb, string webRelativeUrl)
        {
            try
            {
                eventReceiverHelper.AddListEventReceiverDefinition(
                    variationTargetLabelWeb,
                    new EventReceiverInfo(
                        new ListInfo(webRelativeUrl, webRelativeUrl, webRelativeUrl),
                        SPEventReceiverType.FieldUpdating,
                        SPEventReceiverSynchronization.Synchronous)
                    {
                        AssemblyName = Assembly.GetExecutingAssembly().FullName,
                        ClassName = "GSoft.Dynamite.Navigation.SP.Events.VariationTargetPagesLibraryEvents"
                    });
            }
            catch (Exception e)
            {
                logger.Error(
                    "Failed to apply subweb Pages library FieldUpdate event receiver on subweb {0} at Url {1}."
                    + " Moving on to try to apply config to further subwebs' Pages library anyway. Exception: {2}",
                    variationTargetLabelWeb.ID,
                    variationTargetLabelWeb.Url,
                    e.ToString());
            }

            foreach (SPWeb subWeb in variationTargetLabelWeb.Webs)
            {
                ApplyEventReceiverToAllSubWebListsRecursively(eventReceiverHelper, logger, subWeb, webRelativeUrl);
            }
        }
    }
}
