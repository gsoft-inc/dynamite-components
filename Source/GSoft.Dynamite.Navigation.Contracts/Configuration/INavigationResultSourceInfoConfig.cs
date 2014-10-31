using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationResultSourceInfoConfig
    {
        IList<ResultSourceInfo> ResultSources();
    }
}
