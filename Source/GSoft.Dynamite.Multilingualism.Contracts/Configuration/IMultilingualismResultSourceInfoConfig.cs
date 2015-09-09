using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    /// <summary>
    /// Interface for search result sources configuration for the multilingualism module
    /// </summary>
    public interface IMultilingualismResultSourceInfoConfig
    {
        /// <summary>
        /// Property that return all the result source to create/update
        /// </summary>
        IList<ResultSourceInfo> ResultSources { get; }

        /// <summary>
        /// Gets the result source information by name from this configuration.
        /// </summary>
        /// <param name="name">The result source name.</param>
        /// <returns>The result source information</returns>
        ResultSourceInfo GetResultSourceInfoByName(string name);
    }
}
