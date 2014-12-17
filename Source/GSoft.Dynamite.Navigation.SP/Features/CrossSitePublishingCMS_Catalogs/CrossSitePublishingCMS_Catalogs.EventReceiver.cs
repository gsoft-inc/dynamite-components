using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_Catalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("6ed6bd2c-2e3a-4b3e-8795-725448e2774d")]
    public class CrossSitePublishingCMS_CatalogsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var catalogHelper = featureScope.Resolve<ICatalogHelper>();
                    var baseCatalogInfoConfig = featureScope.Resolve<INavigationCatalogInfoConfig>();

                    var baseCatalogs = baseCatalogInfoConfig.Catalogs as List<CatalogInfo>;

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
