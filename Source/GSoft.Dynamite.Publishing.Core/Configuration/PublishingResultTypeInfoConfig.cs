using System;
using System.Collections.Generic;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingResultTypeInfoConfig: IPublishingResultTypeInfoConfig
    {
        private readonly PublishingResultTypeInfos _basePublishingResultTypeInfos;

        public PublishingResultTypeInfoConfig(PublishingResultTypeInfos basePublishingResultTypeInfos)
        {
            this._basePublishingResultTypeInfos = basePublishingResultTypeInfos;
        }

        public IList<ResultTypeInfo> ResultTypes()
        {
            var resultTypes = new List<ResultTypeInfo>()
            {
                {this._basePublishingResultTypeInfos.NewsPageResultType()},
                {this._basePublishingResultTypeInfos.ContentPageResultType()},
                {this._basePublishingResultTypeInfos.CategoryItemResultType()}
            };

            return resultTypes;
        }
    }
}
