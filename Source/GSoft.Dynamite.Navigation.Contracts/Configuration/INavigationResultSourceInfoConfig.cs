using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Result sources configuration for the navigation module
    /// </summary>
    public interface INavigationResultSourceInfoConfig
    {
        /// <summary>
        /// Property that return all the result sources to create or configure in the navigation module
        /// </summary>
        IList<ResultSourceInfo> ResultSources { get; }
    }
}
