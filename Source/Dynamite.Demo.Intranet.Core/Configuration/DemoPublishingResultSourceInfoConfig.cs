using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DemoPublishingResultSourceInfoConfig: IPublishingResultSourceInfoConfig
    {
        private readonly DemoPublishingResultSourceInfos _resultSourceInfos;
        private readonly IPublishingResultSourceInfoConfig _publishingResultSourceInfoConfig;

        public DemoPublishingResultSourceInfoConfig(IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig, DemoPublishingResultSourceInfos resultSourceInfos)
        {
            this._resultSourceInfos = resultSourceInfos;
            this._publishingResultSourceInfoConfig = publishingResultSourceInfoConfig;
        }

        public IList<ResultSourceInfo> ResultSources()
        {
            var baseResultSourceConfig = this._publishingResultSourceInfoConfig.ResultSources();

            baseResultSourceConfig.Add(this._resultSourceInfos.DynamiteDemoResultSource());

            return baseResultSourceConfig;
        }
    }
}
