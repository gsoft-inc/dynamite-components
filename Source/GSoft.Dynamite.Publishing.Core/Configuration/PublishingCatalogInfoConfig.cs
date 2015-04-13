using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the catalogs settings. Catalogs are only used with Cross Site Publishing based solutions
    /// </summary>
    public class PublishingCatalogInfoConfig : IPublishingCatalogInfoConfig
    {
        private readonly IPublishingTaxonomyConfig publishingTaxonomyConfig;
        private readonly IPublishingFieldInfoConfig publishingFieldInfoConfig;
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingTaxonomyConfig">The publishing taxonomy configuration.</param>
        /// <param name="publishingFieldInfoConfig">The publishing field information configuration.</param>
        /// <param name="publishingContentTypeInfoConfig">The publishing content type information configuration.</param>
        public PublishingCatalogInfoConfig(
            IPublishingTaxonomyConfig publishingTaxonomyConfig,
            IPublishingFieldInfoConfig publishingFieldInfoConfig,
            IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig)
        {
            this.publishingTaxonomyConfig = publishingTaxonomyConfig;
            this.publishingFieldInfoConfig = publishingFieldInfoConfig;
            this.publishingContentTypeInfoConfig = publishingContentTypeInfoConfig;
        }

        /// <summary>
        /// Property that return all the catalogs to use in the publishing module
        /// </summary>
        /// <returns>Teh catalogs</returns>
        public IList<CatalogInfo> Catalogs
        {
            get
            {
                return new List<CatalogInfo>
                {
                    this.NewsPagesCatalogInfo,
                    this.ContentPagesCatalogInfo
                };
            }
        }

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>
        /// The catalog information
        /// </returns>
        public CatalogInfo GetCatalogInfoByWebRelativeUrl(string webRelativeUrl)
        {
            return this.GetCatalogInfoByWebRelativeUrl(new Uri(webRelativeUrl, UriKind.Relative));
        }

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>
        /// The catalog information
        /// </returns>
        public CatalogInfo GetCatalogInfoByWebRelativeUrl(Uri webRelativeUrl)
        {
            return this.Catalogs.Single(c => c.WebRelativeUrl.Equals(webRelativeUrl));
        }

        private CatalogInfo NewsPagesCatalogInfo
        {
            get
            {
                // Customize navigation field for the news catalog 
                // 1. Enfore unique values 
                // 2. Set the term store mapping
                var customNavigationField = this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo;
                customNavigationField.EnforceUniqueValues = true;
                customNavigationField.TermStoreMapping = new TaxonomyContext(this.publishingTaxonomyConfig.GetTermSetById(PublishingTermSetInfos.RestrictedNews.Id));

                // Configure the news pages catalog
                var newsPagesCatalog = PublishingCatalogInfos.NewsPages;
                newsPagesCatalog.TaxonomyFieldMap = customNavigationField;
                newsPagesCatalog.ContentTypes = new[] 
                {
                    this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.NewsItem.ContentTypeId)
                };

                newsPagesCatalog.DefaultViewFields = new[]
                {
                    customNavigationField
                };

                newsPagesCatalog.FieldDefinitions = new[]
                {
                    customNavigationField
                };

                return newsPagesCatalog;
            }
        }

        private CatalogInfo ContentPagesCatalogInfo
        {
            get
            {
                // Customize navigation field for the content pages catalog (enforce unique values)
                var customNavigationField = this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo;
                customNavigationField.EnforceUniqueValues = true;

                // Configure the content pages catalog
                var contentPagesCatalog = PublishingCatalogInfos.ContentPages;
                contentPagesCatalog.TaxonomyFieldMap = customNavigationField;
                contentPagesCatalog.ContentTypes = new[] 
                {
                    this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.ContentItem.ContentTypeId)
                };

                contentPagesCatalog.DefaultViewFields = new[]
                {
                    customNavigationField
                };

                contentPagesCatalog.FieldDefinitions = new[]
                {
                    customNavigationField
                };

                return contentPagesCatalog;
            }
        }
    }
}
