using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CrossSitePublishingCMS_SyncCatalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("28f4f5a2-4141-4d58-a67c-ed7aebf92bbe")]
    public class CrossSitePublishingCmsSyncCatalogsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var variationHelper = featureScope.Resolve<VariationHelper>();
                    var baseVariationSettingsConfig = featureScope.Resolve<IBaseMultilingualismVariationsConfig>();
                    var baseCatalogInfoConfig = featureScope.Resolve<IBasePublishingCatalogInfoConfig>();
                    var baseVariationSettings = baseVariationSettingsConfig.VariationSettings();

                    if (baseVariationSettings != null)
                    {
                        // Check if custom configuration is present
                        ICustomPublishingCatalogInfoConfig customCatalogInfoConfig = null;
                        IList<CatalogInfo> baseCatalogs;
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

                        // Sync catalogs
                        foreach (var catalog in baseCatalogs)
                        {
                            logger.Info("Synchronize variations for catalog {0} in web {1}", catalog.DisplayName, web.Url);
                            variationHelper.SyncList(web, catalog, baseVariationSettings.Labels);
                        }
                    }
                }
            }
        }
    }
}