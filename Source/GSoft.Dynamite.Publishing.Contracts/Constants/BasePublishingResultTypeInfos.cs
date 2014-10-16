using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Definitions.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingResultTypeInfos
    {
        private readonly BasePublishingDisplayTemplateInfos _displayTemplateInfos;
        private readonly BasePublishingResultSourceInfos _resultSourceInfos;      
        private readonly BasePublishingContentTypeInfos _contentTypeInfos;

        public BasePublishingResultTypeInfos(BasePublishingDisplayTemplateInfos displayTemplateInfos,
            BasePublishingResultSourceInfos resultSourceInfos, BasePublishingContentTypeInfos contentTypeInfos)
        {
            this._displayTemplateInfos = displayTemplateInfos;
            this._resultSourceInfos = resultSourceInfos;
            this._contentTypeInfos = contentTypeInfos;
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
                    BasePublishingManagedPropertyInfo.Navigation,
                },
                Rules = new List<ResultTypeRuleInfo>()
                {
                    new ResultTypeRuleInfo(BasePublishingManagedPropertyInfo.ContentTypeId,
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
                    BasePublishingManagedPropertyInfo.Navigation,
                },
                Rules = new List<ResultTypeRuleInfo>()
                {
                    new ResultTypeRuleInfo(BasePublishingManagedPropertyInfo.ContentTypeId,
                        PropertyRuleOperator.DefaultOperator.Contains,
                        new string[] {this._contentTypeInfos.ContentItem().ContentTypeId})
                }
            };
        }
    }
}
