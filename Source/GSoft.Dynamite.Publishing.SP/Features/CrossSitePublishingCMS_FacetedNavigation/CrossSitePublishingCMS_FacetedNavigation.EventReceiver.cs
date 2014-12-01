using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_FacetedNavigation
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("e07bc3af-581a-4d24-9780-b2b5ca65a068")]
    public class CrossSitePublishingCMS_FacetedNavigationEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var searchHelper = featureScope.Resolve<ISearchHelper>();
                    var facetedNavigationsettings = featureScope.Resolve<IPublishingFacetedNavigationInfoConfig>().FacetedNavigationInfos;

                    foreach (var setting in facetedNavigationsettings)
                    {
                        searchHelper.AddFacetedRefinersForTerm(site, setting);
                    }
                }
            }
        }

        /// <summary>
        /// Feature deactivating event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var searchHelper = featureScope.Resolve<ISearchHelper>();
                    var facetedNavigationsettings = featureScope.Resolve<IPublishingFacetedNavigationInfoConfig>().FacetedNavigationInfos;

                    foreach (var setting in facetedNavigationsettings)
                    {
                        searchHelper.RemoveFacetedRefinersForTerm(site, setting.Term);
                    }
                }
            }
        }
    }
}
