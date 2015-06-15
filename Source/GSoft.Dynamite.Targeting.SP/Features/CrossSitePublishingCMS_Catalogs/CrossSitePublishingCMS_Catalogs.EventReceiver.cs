using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP.Features.CrossSitePublishingCMS_Catalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("bbbc8a60-c310-43b8-ad7e-83696bede5be")]
    public class CrossSitePublishingCmsCatalogsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event deploying catalogs (targeting module)
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var catalogHelper = featureScope.Resolve<ICatalogHelper>();
                    var baseCatalogInfoConfig = featureScope.Resolve<ITargetingCatalogInfoConfig>();

                    var baseCatalogs = baseCatalogInfoConfig.Catalogs;

                    // Ensure catalogs
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
