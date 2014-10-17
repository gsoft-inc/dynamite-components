using System;
using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingResultTypeInfoConfig: IBasePublishingResultTypeInfoConfig
    {
        private readonly BasePublishingResultTypeInfos _basePublishingResultTypeInfos;

        public BasePublishingResultTypeInfoConfig(BasePublishingResultTypeInfos basePublishingResultTypeInfos)
        {
            this._basePublishingResultTypeInfos = basePublishingResultTypeInfos;
        }

        public IList<ResultTypeInfo> ResultTypes()
        {
            var resultTypes = new List<ResultTypeInfo>()
            {
                {this._basePublishingResultTypeInfos.NewsPageResultType()},
                {this._basePublishingResultTypeInfos.ContentPageResultType()}
            };

            return resultTypes;
        }
    }
}
