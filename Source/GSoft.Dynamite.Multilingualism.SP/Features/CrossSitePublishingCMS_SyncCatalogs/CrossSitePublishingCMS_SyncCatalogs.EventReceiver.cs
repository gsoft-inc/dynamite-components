using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
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
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();
                    var variationSyncHelper = featureScope.Resolve<IVariationSyncHelper>();
                    var baseVariationSettingsConfig = featureScope.Resolve<IMultilingualismVariationsConfig>();
                    var baseCatalogInfoConfig = featureScope.Resolve<IPublishingCatalogInfoConfig>();
                    var baseVariationSettings = baseVariationSettingsConfig.VariationSettings();

                    if (baseVariationSettings != null)
                    {                      
                        logger.Info("No custom catalogs configuration override found!");
                        var baseCatalogs = baseCatalogInfoConfig.Catalogs;

                        // Sync catalogs
                        foreach (var catalog in baseCatalogs)
                        {
                            logger.Info("Synchronize variations for catalog {0} in web {1}", resourceLocator.Find(catalog.DisplayNameResourceKey), web.Url);
                            variationSyncHelper.SyncList(web, catalog, baseVariationSettings.Labels.ToList());
                        }
                    }
                }
            }
        }
    }
}
