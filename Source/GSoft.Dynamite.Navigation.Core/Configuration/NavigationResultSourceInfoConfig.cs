using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Result sources configuration for the navigation module
    /// </summary>
    public class NavigationResultSourceInfoConfig : INavigationResultSourceInfoConfig
    {
        private readonly IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig;
        private readonly IConsolidatedManagedPropertyConfig consolidatedManagedPropertyConfig;
        private readonly IPublishingFieldInfoConfig publishingFieldInfoConfig;
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig;

        public NavigationResultSourceInfoConfig(
            IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig,
            IConsolidatedManagedPropertyConfig consolidatedManagedPropertyConfig,
            IPublishingFieldInfoConfig publishingFieldInfoConfig,
            IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig)
        {
            this.publishingResultSourceInfoConfig = publishingResultSourceInfoConfig;
            this.consolidatedManagedPropertyConfig = consolidatedManagedPropertyConfig;
            this.publishingFieldInfoConfig = publishingFieldInfoConfig;
            this.publishingContentTypeInfoConfig = publishingContentTypeInfoConfig;
        }

        /// <summary>
        /// Property that return all the result sources to create or configure in the navigation module
        /// </summary>
        public IList<ResultSourceInfo> ResultSources
        {
            get
            {
                var resultSources = new List<ResultSourceInfo>
                {
                    this.UpdatedSingleTargetItem,
                    this.UpdatedSingleCatalogItem,
                    NavigationResultSourceInfos.AllMenuItems
                };

                return resultSources;
            }
        }

        /// <summary>
        /// Gets the result source information by name from this configuration.
        /// </summary>
        /// <param name="name">The result source name.</param>
        /// <returns>
        /// The result source information
        /// </returns>
        public ResultSourceInfo GetResultSourceInfoByName(string name)
        {
            return this.ResultSources.Single(s => s.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// The search result source to get a single catalog item according to the current taxonomy navigation context
        /// </summary>
        private ResultSourceInfo UpdatedSingleCatalogItem
        {
            get
            {
                var listItemId = BuiltInManagedProperties.ListItemId.Name;
                var dateSlug = this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(NavigationManagedPropertyInfos.DateSlugManagedProperty.Name);
                var titleSlug = this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(NavigationManagedPropertyInfos.TitleSlugManagedProperty.Name);
                var navigation = (this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo).OWSTaxIdManagedPropertyInfo.Name;

                // Extend the existing query 
                var singleCatalogItem = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.SingleCatalogItem.Name);
                singleCatalogItem.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;
                singleCatalogItem.Query =
                  string.Format("{0}:{{Term}}" + " {1}:{{URLToken.1}}" + " {2}={{URLToken.2}}" + " {3}:{{URLToken.3}}", navigation, titleSlug, listItemId, dateSlug);

                return singleCatalogItem;
            }
        }

        /// <summary>
        /// The search result source to get a single item according to the current taxonomy navigation context
        /// </summary>
        private ResultSourceInfo UpdatedSingleTargetItem
        {
            get
            {
                var navigation = (this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo).OWSTaxIdManagedPropertyInfo.Name;
                var targetContentTypeId = this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.TargetContentItem.ContentTypeId);

                // Extend the existing query 
                var singleCatalogItem = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.SingleTargetItem.Name);
                singleCatalogItem.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;
                singleCatalogItem.Query = navigation + ":{Term}" + " " + "ContentTypeId:" + targetContentTypeId + "*";

                return singleCatalogItem;
            }
        }
    }
}
