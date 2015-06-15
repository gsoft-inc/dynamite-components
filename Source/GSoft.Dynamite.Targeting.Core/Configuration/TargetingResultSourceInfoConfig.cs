using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Targeting.Contracts.Configuration;

namespace GSoft.Dynamite.Targeting.Core.Configuration
{
    /// <summary>
    /// Search result sources configuration for the targeting module
    /// </summary>
    public class TargetingResultSourceInfoConfig : ITargetingResultSourceInfoConfig
    {
        /// <summary>
        /// Property that return all the result sources to create or configure in the targeting module
        /// </summary>
        /// <returns>The result source settings for the targeting module</returns>
        public IList<ResultSourceInfo> ResultSources
        {
            get
            {
                return new List<ResultSourceInfo>();
            }
        }

        /// <summary>
        /// Gets the result source information by name from this configuration.
        /// </summary>
        /// <param name="name">The result source name.</param>
        /// <returns>
        /// The result source information
        /// </returns>
        public ResultSourceInfo GetResultSourceInfoByName(string name)
        {
            return this.ResultSources.Single(s => s.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
