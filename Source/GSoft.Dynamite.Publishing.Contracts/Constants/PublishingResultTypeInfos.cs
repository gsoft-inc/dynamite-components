using System.Collections.Generic;
using GSoft.Dynamite.Search;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingResultTypeInfos
    {
        private readonly PublishingDisplayTemplateInfos _displayTemplateInfos;
        private readonly PublishingResultSourceInfos _resultSourceInfos;      
        private readonly PublishingContentTypeInfos _contentTypeInfos;
        private readonly PublishingManagedPropertyInfos _publishingManagedPropertyInfos;

        public PublishingResultTypeInfos(PublishingDisplayTemplateInfos displayTemplateInfos,
            PublishingResultSourceInfos resultSourceInfos, PublishingContentTypeInfos contentTypeInfos, PublishingManagedPropertyInfos publishingManagedPropertyInfos)
        {
            this._displayTemplateInfos = displayTemplateInfos;
            this._resultSourceInfos = resultSourceInfos;
            this._contentTypeInfos = contentTypeInfos;
            this._publishingManagedPropertyInfos = publishingManagedPropertyInfos;
        }

        public ResultTypeInfo NewsPageResultType()
        {
            return new ResultTypeInfo("Dynamite - News Page",
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
                    new ResultTypeRuleInfo(this._publishingManagedPropertyInfos.ContentTypeId,
                        PropertyRuleOperator.DefaultOperator.Contains,
                        new string[] {this._contentTypeInfos.NewsItem().ContentTypeId})
                }
            };
        }

        public ResultTypeInfo ContentPageResultType()
        {
            return new ResultTypeInfo("Dynamite - Content Page",
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
                    new ResultTypeRuleInfo(this._publishingManagedPropertyInfos.ContentTypeId,
                        PropertyRuleOperator.DefaultOperator.Contains,
                        new string[] {this._contentTypeInfos.ContentItem().ContentTypeId})
                }
            };
        }
    }
}
