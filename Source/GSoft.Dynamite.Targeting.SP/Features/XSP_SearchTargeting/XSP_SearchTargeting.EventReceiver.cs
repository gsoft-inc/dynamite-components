using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP.Features.CrossSitePublishingCMS_ResultSources
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("d157298f-4122-470d-8de7-ee76ccd533df")]
    public class CrossSitePublishingCmsResultSourcesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Creates search result sources in the Search Service Application for the targeting module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var searchHelper = featureScope.Resolve<ISearchHelper>();
                    var baseResultSourceInfoConfig = featureScope.Resolve<ITargetingSearchConfig>();

                    var resultSources = baseResultSourceInfoConfig.ResultSources;

                    // Create targeting result sources
                    foreach (var resultSource in resultSources)
                    {
                        logger.Info("Create targeting result sources");
                        searchHelper.EnsureResultSource(site, resultSource);
                    }
                }
            }
        }

        /// <summary>
        /// Removes the search result sources associated to the targeting module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var searchHelper = featureScope.Resolve<ISearchHelper>();
                    var baseResultSourceInfoConfig = featureScope.Resolve<ITargetingSearchConfig>();

                    var resultSources = baseResultSourceInfoConfig.ResultSources;

                    // Removes the query added by this feature
                    foreach (var resultSource in resultSources)
                    {
                        logger.Info("Revert result source {0}", resultSource.Name);
                        resultSource.UpdateMode = ResultSourceUpdateBehavior.RevertQuery;
                        searchHelper.EnsureResultSource(site, resultSource);
                    }
                }
            }
        }
    }
}
