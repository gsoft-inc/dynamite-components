using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingResultSourceInfoConfig : IPublishingResultSourceInfoConfig
    {
        private readonly PublishingResultSourceInfos _resultSourceValues;

        public PublishingResultSourceInfoConfig(PublishingResultSourceInfos resultSourceValues)
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
