using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Features;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_Catalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("937be292-2393-47d6-8c8e-117622999f84")]
    public class CrossSitePublishingCMS_CatalogsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var catalogHelper = featureScope.Resolve<ICatalogHelper>();
                    var baseCatalogInfoConfig = featureScope.Resolve<IPublishingCatalogInfoConfig>();

                    // Resolve feature dependency activator
                    // Note: Need to pass the site and web objects to support site and web scoped features.
                    var featureDependencyActivator =
                        featureScope.Resolve<IFeatureDependencyActivator>(
                            new TypedParameter(typeof(SPSite), web.Site),
                            new TypedParameter(typeof(SPWeb), web));

                    // Activate feature dependencies defined in this configuration
                    featureDependencyActivator.EnsureFeatureActivation(baseCatalogInfoConfig as IFeatureDependencyConfig);

                    // Create catalogs
                    var baseCatalogs = baseCatalogInfoConfig.Catalogs as List<CatalogInfo>;
                    foreach (var catalog in baseCatalogs)
                    {
                        logger.Info("Creating catalog {0} on web {1}", catalog.WebRelativeUrl, web.Url);
                        catalogHelper.EnsureCatalog(web, catalog);
                    }
                }
            }
        }
    }
}
