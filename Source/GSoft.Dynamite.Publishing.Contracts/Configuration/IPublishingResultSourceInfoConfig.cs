using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingResultSourceInfoConfig
    {
        IList<ResultSourceInfo> ResultSources();
    }
}
