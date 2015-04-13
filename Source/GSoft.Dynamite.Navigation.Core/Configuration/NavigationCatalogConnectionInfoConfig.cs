using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Catalog connections configuration for the navigation module. Only for Cross Site Publishing based solutions
    /// </summary>
    public class NavigationCatalogConnectionInfoConfig : INavigationCatalogConnectionInfoConfig
    {
        private readonly IConsolidatedManagedPropertyConfig consolidatedManagedPropertyConfig;
        private readonly IPublishingCatalogInfoConfig publishingCatalogInfoConfig;
        private readonly IPublishingFieldInfoConfig publishingFieldInfoConfig;

        public NavigationCatalogConnectionInfoConfig(
            IConsolidatedManagedPropertyConfig consolidatedManagedPropertyConfig,
            IPublishingCatalogInfoConfig publishingCatalogInfoConfig,
            IPublishingFieldInfoConfig publishingFieldInfoConfig)
        {
            this.consolidatedManagedPropertyConfig = consolidatedManagedPropertyConfig;
            this.publishingCatalogInfoConfig = publishingCatalogInfoConfig;
            this.publishingFieldInfoConfig = publishingFieldInfoConfig;
        }

        /// <summary>
        /// Property that return all the catalog connections to create or configure in the publishing module
        /// </summary>
        public IList<CatalogConnectionInfo> CatalogConnections
        {
            get
            {
                return new List<CatalogConnectionInfo>()
                {
                    this.NewsPagesConnection,
                    this.ContentPagesConnection
                };
            }         
        }

        /// <summary>
        /// Gets the catalog connection information by catalog information from this configuration.
        /// </summary>
        /// <param name="catalog">The catalog information.</param>
        /// <returns>
        /// The catalog connection information
        /// </returns>
        public CatalogConnectionInfo GetCatalogConnectionInfoByCatalog(CatalogInfo catalog)
        {
            return this.CatalogConnections.Single(c => c.Catalog.Equals(catalog));
        }

        /// <summary>
        /// Catalog connection for the news pages catalog
        /// </summary>
        private CatalogConnectionInfo NewsPagesConnection
        {
            get
            {
                // Friendly URL format
                var urlTemplate = string.Format(
                    CultureInfo.InvariantCulture,
                    "/[{0}]/[{1}]/[{2}]",
                    this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(NavigationManagedPropertyInfos.DateSlugManagedProperty.Name).Name,
                    BuiltInManagedProperties.ListItemId.Name,
                    this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(NavigationManagedPropertyInfos.TitleSlugManagedProperty.Name).Name);

                // The SPWeb will be populated during the feature activation
                var catalogInfo = this.publishingCatalogInfoConfig.GetCatalogInfoByWebRelativeUrl(PublishingCatalogInfos.NewsPages.WebRelativeUrl);
                var navField = this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo;
                return new CatalogConnectionInfo(
                    catalogInfo,
                    navField.OWSTaxIdManagedPropertyInfo.Name,
                    true,
                    false,
                    false,
                    urlTemplate);
            }
        }

        /// <summary>
        /// Catalog connection for the content pages catalog
        /// </summary>
        private CatalogConnectionInfo ContentPagesConnection
        {
            get
            {
                // Friendly URL format
                var urlTemplate = string.Format(
                    CultureInfo.InvariantCulture,
                    "/[{0}]/[{1}]",
                    BuiltInManagedProperties.ListItemId.Name,
                    this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(NavigationManagedPropertyInfos.TitleSlugManagedProperty.Name).Name);

                // The SPWeb will be populated during the feature activation
                // Note: Empty slug for content pages since they are only attached to a specific term.
                var catalogInfo = this.publishingCatalogInfoConfig.GetCatalogInfoByWebRelativeUrl(PublishingCatalogInfos.ContentPages.WebRelativeUrl);
                var navField = this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo;
                return new CatalogConnectionInfo(
                    catalogInfo,
                    navField.OWSTaxIdManagedPropertyInfo.Name,
                    true,
                    false,
                    false,
                    urlTemplate);
            }
        }
    }
}
