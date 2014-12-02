using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    /// <summary>
    /// Example of a search result sources override from the publishing module
    /// </summary>
    public class DemoPublishingResultSourceInfoConfig : IPublishingResultSourceInfoConfig
    {
        private readonly DemoPublishingResultSourceInfos _resultSourceInfos;
        private readonly IPublishingResultSourceInfoConfig _publishingResultSourceInfoConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingResultSourceInfoConfig">The result sources configuration from the publishing module</param>
        /// <param name="resultSourceInfos">The result sources settings from the Dynamite demo module></param>
        public DemoPublishingResultSourceInfoConfig(IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig, DemoPublishingResultSourceInfos resultSourceInfos)
        {
            this._resultSourceInfos = resultSourceInfos;
            this._publishingResultSourceInfoConfig = publishingResultSourceInfoConfig;
        }

        /// <summary>
        /// Override of result sources from the publishing module
        /// </summary>
        /// <returns>A list of result sources</returns>
        public IList<ResultSourceInfo> ResultSources()
        {
            var baseResultSourceConfig = this._publishingResultSourceInfoConfig.ResultSources();

            baseResultSourceConfig.Add(this._resultSourceInfos.DynamiteDemoResultSource());

            return baseResultSourceConfig;
        }
    }
}
