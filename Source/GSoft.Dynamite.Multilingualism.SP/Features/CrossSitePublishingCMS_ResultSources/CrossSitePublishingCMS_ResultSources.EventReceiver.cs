using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CrossSitePublishingCMS_ResultSources
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("a145b249-5d4f-4854-8724-9fb2ac5d219d")]
    public class CrossSitePublishingCMS_ResultSourcesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Creates search result sources for the multilingualism
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var searchHelper = featureScope.Resolve<ISearchHelper>();
                    var baseResultSourceInfoConfig = featureScope.Resolve<IMultilingualismResultSourceInfoConfig>();

                    IList<ResultSourceInfo> resultSources = baseResultSourceInfoConfig.ResultSources;

                    // Create multilingualism result sources
                    foreach (var resultSource in resultSources)
                    {
                        logger.Info("Create multilingualism result sources");
                        searchHelper.EnsureResultSource(site, resultSource);
                    }
                }
            }
        }

        /// <summary>
        /// Reverts to the publishing module result source configuration 
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var searchHelper = featureScope.Resolve<ISearchHelper>();
                    var baseResultSourceInfoConfig = featureScope.Resolve<IMultilingualismResultSourceInfoConfig>();

                    IList<ResultSourceInfo> resultSources = baseResultSourceInfoConfig.ResultSources;

                    // Re create publishing result sources
                    foreach (var resultSource in resultSources)
                    {
                        logger.Info("Revert to publishing result sources");
                        resultSource.UpdateMode = ResultSourceUpdateBehavior.RevertQuery;
                        searchHelper.EnsureResultSource(site, resultSource);
                    }
                }
            }
        }
    }
}
