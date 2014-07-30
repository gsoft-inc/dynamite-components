using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Factories;
using GSoft.Dynamite.SiteColumns;
using Microsoft.SharePoint;
using GSoft.Dynamite.Portal.Contracts.Config;

namespace GSoft.Dynamite.Portal.SP.Authoring.Features.Catalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("0c65228a-2dcc-4617-826d-75d05be2e0b2")]
    public class CatalogsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event handler for the feature activation
        /// </summary>
        /// <param name="properties">the event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            using (var featureScope = AuthoringContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var catalogBuilder = featureScope.Resolve<CatalogBuilder>();
                var listViewFactory = featureScope.Resolve<IListViewFactory>();
                var termStoreConfig = featureScope.Resolve<IPortalTermStoreConfig>();
                var catalogConfig = featureScope.Resolve<IPortalCatalogConfig>();

                var currentWebCatalogConfigs = catalogConfig.CatalogDefinitionsForWeb(web);

                foreach (var catalog in currentWebCatalogConfigs)
                {
                    catalogBuilder.ProcessCatalog(web, catalog);
                    listViewFactory.CreateContentCatalogView(web, catalog);
                }
            }
        }
    }
}
