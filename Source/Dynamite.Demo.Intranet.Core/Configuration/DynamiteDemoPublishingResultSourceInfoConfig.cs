using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingResultSourceInfoConfig: ICustomPublishingResultSourceInfoConfig
    {
        private readonly DynamiteDemoPublishingResultSourceInfos _resultSourceInfos;

        public DynamiteDemoPublishingResultSourceInfoConfig(DynamiteDemoPublishingResultSourceInfos resultSourceInfos)
        {
            this._resultSourceInfos = resultSourceInfos;
        }

        public IList<ResultSourceInfo> ResultSources()
        {
            return new List<ResultSourceInfo>()
            {
                {this._resultSourceInfos.DynamiteDemoResultSource()}
            };
        }
    }
}
