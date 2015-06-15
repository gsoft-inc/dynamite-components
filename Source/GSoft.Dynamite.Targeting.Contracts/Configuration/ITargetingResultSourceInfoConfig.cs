using System;
using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Targeting.Contracts.Configuration
{
    /// <summary>
    /// Result sources configuration for the targeting module
    /// </summary>
    public interface ITargetingResultSourceInfoConfig
    {

        /// <summary>
        /// Property that return all the result sources to create or configure in the navigation module
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
