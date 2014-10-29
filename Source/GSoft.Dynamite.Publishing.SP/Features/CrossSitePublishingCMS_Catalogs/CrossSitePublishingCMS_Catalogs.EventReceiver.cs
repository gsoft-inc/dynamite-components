using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
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
                    var logger = featureScope.Resolve<ILogger>();
                    var catalogHelper = featureScope.Resolve<ICatalogHelper>();
                    var baseCatalogInfoConfig = featureScope.Resolve<IPublishingCatalogInfoConfig>();

                    var baseCatalogs = baseCatalogInfoConfig.Catalogs() as List<CatalogInfo>;
                    
                    // Create catalogs
                    foreach (var catalog in baseCatalogs)
                    {
                        logger.Info("Creating catalog {0} on web {1}", catalog.RootFolderUrl, web.Url);
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
