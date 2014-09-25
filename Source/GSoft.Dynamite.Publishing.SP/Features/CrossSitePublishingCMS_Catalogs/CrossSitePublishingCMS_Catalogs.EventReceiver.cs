using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Portal.SP.Publishing;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using GSoft.Dynamite.Utils;
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
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    IList<CatalogInfo> baseCatalogs;

                    var logger = featureScope.Resolve<ILogger>();
                    var catalogHelper = featureScope.Resolve<CatalogHelper>();
                    var baseCatalogInfoConfig = featureScope.Resolve<IBasePublishingCatalogInfoConfig>();

                    // Check if custom configuration is present
                    ICustomPublishingCatalogInfoConfig customCatalogInfoConfig = null;
                    if (featureScope.TryResolve(out customCatalogInfoConfig))
                    {
                        logger.Info("Custom catalogs configuration override found!");
                        baseCatalogs = customCatalogInfoConfig.Catalogs();
                    }
                    else
                    {
                        logger.Info("No custom catalogs configuration override found!");
                        baseCatalogs = baseCatalogInfoConfig.Catalogs();
                    }

                    // Create catalogs
                    foreach (var catalog in baseCatalogs)
                    {
                        catalogHelper.EnsureCatalog(web, catalog);
                    }
                }
            }
        }

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}
    }
}
