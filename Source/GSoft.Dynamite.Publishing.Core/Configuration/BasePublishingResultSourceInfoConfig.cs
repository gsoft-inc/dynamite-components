using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingResultSourceInfoConfig : IBasePublishingResultSourceInfoConfig
    {
        private readonly BasePublishingResultSourceInfos _resultSourceValues;

        public BasePublishingResultSourceInfoConfig(BasePublishingResultSourceInfos resultSourceValues)
        {
            this._resultSourceValues = resultSourceValues;
        }

        public IList<ResultSourceInfo> ResultSources()
        {
            var resultSources = new List<ResultSourceInfo>
            {
                {_resultSourceValues.SingleTargetItem()},
                {_resultSourceValues.SingleCatalogItem()}
            };

            return resultSources;
        }
    }
}
