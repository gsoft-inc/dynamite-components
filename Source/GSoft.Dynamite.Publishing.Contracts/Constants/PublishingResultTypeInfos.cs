using System.Collections.Generic;
using GSoft.Dynamite.Search;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Search result types definitions for the publishing modules
    /// </summary>
    public class PublishingResultTypeInfos
    {
        private readonly PublishingDisplayTemplateInfos _displayTemplateInfos;
        private readonly PublishingResultSourceInfos _resultSourceInfos;      
        private readonly PublishingContentTypeInfos _contentTypeInfos;
        private readonly PublishingManagedPropertyInfos _publishingManagedPropertyInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="displayTemplateInfos">The display template info objects configuration</param>
        /// <param name="resultSourceInfos">The result source info objects configuration</param>
        /// <param name="contentTypeInfos">The content type info objects configuration</param>
        /// <param name="publishingManagedPropertyInfos">The managed property info objects configuration</param>
        public PublishingResultTypeInfos(
            PublishingDisplayTemplateInfos displayTemplateInfos,
            PublishingResultSourceInfos resultSourceInfos,
            PublishingContentTypeInfos contentTypeInfos, 
            PublishingManagedPropertyInfos publishingManagedPropertyInfos)
        {
            this._displayTemplateInfos = displayTemplateInfos;
            this._resultSourceInfos = resultSourceInfos;
            this._contentTypeInfos = contentTypeInfos;
            this._publishingManagedPropertyInfos = publishingManagedPropertyInfos;
        }

        /// <summary>
        /// The news page result type
        /// </summary>
        /// <returns>The result type configuration object</returns>
        public ResultTypeInfo NewsPageResultType()
        {
            return new ResultTypeInfo(
                "Dynamite - News Page",
                this._displayTemplateInfos.ItemSingleNewsItemContent(),
                this._resultSourceInfos.SingleCatalogItem())
            {
                OptimizeForFrequenUse = true,
                Priority = 1,
                DisplayProperties = new List<ManagedPropertyInfo>()
                {
                    this._publishingManagedPropertyInfos.Title,
                    this._publishingManagedPropertyInfos.PublishingPageContent
                },
                Rules = new List<ResultTypeRuleInfo>()
                {
                    new ResultTypeRuleInfo(
                        this._publishingManagedPropertyInfos.ContentTypeId,
                        PropertyRuleOperator.DefaultOperator.Contains,
                        new string[] { this._contentTypeInfos.NewsItem().ContentTypeId.ToString() })
                }
            };
        }

        /// <summary>
        /// The content page result type
        /// </summary>
        /// <returns>The result type configuration object</returns>
        public ResultTypeInfo ContentPageResultType()
        {
            return new ResultTypeInfo(
                "Dynamite - Content Page",
                this._displayTemplateInfos.ItemSingleContentItem(),
                this._resultSourceInfos.SingleTargetItem())
            {
                OptimizeForFrequenUse = true,
                Priority = 1,
                DisplayProperties = new List<ManagedPropertyInfo>()
                {
                    this._publishingManagedPropertyInfos.Title,
                    this._publishingManagedPropertyInfos.PublishingPageContent
                },
                Rules = new List<ResultTypeRuleInfo>()
                {
                    new ResultTypeRuleInfo(
                        this._publishingManagedPropertyInfos.ContentTypeId,
                        PropertyRuleOperator.DefaultOperator.Contains,
                        new string[] { this._contentTypeInfos.ContentItem().ContentTypeId.ToString() })
                }
            };
        }

        /// <summary>
        /// The catalog item result type
        /// </summary>
        /// <returns>The result type configuration object</returns>
        public ResultTypeInfo CategoryItemResultType()
        {
            return new ResultTypeInfo(
                "Dynamite - Category Item",
                this._displayTemplateInfos.ItemNewsCategoryItem(),
                this._resultSourceInfos.CatalogCategoryItems())
            {
                OptimizeForFrequenUse = true,
                Priority = 1,
                DisplayProperties = new List<ManagedPropertyInfo>()
                {
                    this._publishingManagedPropertyInfos.Title,
                    this._publishingManagedPropertyInfos.Summary,
                    this._publishingManagedPropertyInfos.PublishingImage,
                },
                Rules = new List<ResultTypeRuleInfo>()
                {
                    new ResultTypeRuleInfo(
                        this._publishingManagedPropertyInfos.ContentTypeId,
                        PropertyRuleOperator.DefaultOperator.Contains,
                        new string[] { this._contentTypeInfos.NewsItem().ContentTypeId.ToString() })
                }
            };
        }
    }
}
