using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingResultSourceInfoConfig : IBasePublishingResultSourceInfoConfig
    {
        private readonly BasePublishingResultSourceInfos _resultSourceValues;

        public BasePublishingResultSourceInfoConfig(BasePublishingResultSourceInfos resultSourceValues)
        {
            this._resultSourceValues = resultSourceValues;
        }

        public IDictionary<string, ResultSourceInfo> ResultSources()
        {
            var resultSources = new Dictionary<string, ResultSourceInfo>
            {
                {BasePublishingResultSourceInfoKeys.SingleTargetItem, _resultSourceValues.SingleTargetItem()},
                {BasePublishingResultSourceInfoKeys.SingleCatalogItem, _resultSourceValues.SingleCatalogItem()}
            };

            return resultSources;
        }
    }
}
