using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationResultSourceInfoConfig
    {
        IList<ResultSourceInfo> ResultSources();
    }
}
