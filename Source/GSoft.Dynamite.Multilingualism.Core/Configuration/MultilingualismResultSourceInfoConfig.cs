using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Search result sources configuration for the multilingualism module
    /// </summary>
    public class MultilingualismResultSourceInfoConfig : IMultilingualismResultSourceInfoConfig
    {
        private readonly IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig;
        private readonly IConsolidatedManagedPropertyConfig consolidatedManagedPropertyConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultilingualismResultSourceInfoConfig"/> class.
        /// </summary>
        /// <param name="publishingResultSourceInfoConfig">The publishing result source information configuration.</param>
        /// <param name="consolidatedManagedPropertyConfig">The consolidated managed property configuration.</param>
        public MultilingualismResultSourceInfoConfig(IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig, IConsolidatedManagedPropertyConfig consolidatedManagedPropertyConfig)
        {
            this.publishingResultSourceInfoConfig = publishingResultSourceInfoConfig;
            this.consolidatedManagedPropertyConfig = consolidatedManagedPropertyConfig;
        }

        /// <summary>
        /// Property that return all the result sources to create or configure in the multilingualism module
        /// </summary>
        /// <returns>The result source settings for the multilingualism module</returns>
        public IList<ResultSourceInfo> ResultSources
        {
            get
            {
                var resultSources = new List<ResultSourceInfo>
                {
                    this.SingleTargetItem,
                    this.SingleCatalogItem,
                    this.CatalogCategoryItems
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
        /// Override the single catalog item result source query by appending the language condition
        /// </summary>
        /// <returns>The updated result source info</returns>
        private ResultSourceInfo SingleCatalogItem
        {
            get
            {
                var resultSource = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.SingleCatalogItem.Name);
                var itemLanguage = this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(MultilingualismManagedPropertyInfos.ItemLanguage.Name).Name;

                // Extend the existing query 
                resultSource.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;
                resultSource.Query =
                    itemLanguage + ":{Page.DynamiteItemLanguage}";

                return resultSource;
            }
        }

        /// <summary>
        /// Override the single target item result source query by appending the language condition
        /// </summary>
        /// <returns>The updated result source info</returns>
        private ResultSourceInfo SingleTargetItem
        {
            get
            {
                var resultSource = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.SingleTargetItem.Name);
                var itemLanguage = this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(MultilingualismManagedPropertyInfos.ItemLanguage.Name).Name;

                // Extend the existing query 
                resultSource.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;
                resultSource.Query = itemLanguage + ":{Page.DynamiteItemLanguage}";

                return resultSource;
            }
        }

        /// <summary>
        /// Override the catalog category items result source query by appending the language condition
        /// </summary>
        /// <returns>The updated result source info</returns>
        private ResultSourceInfo CatalogCategoryItems
        {
            get
            {
                var resultSource = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.CatalogCategoryItems.Name);
                var itemLanguage = this.consolidatedManagedPropertyConfig.GetManagedPropertyInfoByName(MultilingualismManagedPropertyInfos.ItemLanguage.Name).Name;

                // Extend the existing query 
                resultSource.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;
                resultSource.Query = itemLanguage + ":{Page.DynamiteItemLanguage}";

                return resultSource;
            }
        }
    }
}
