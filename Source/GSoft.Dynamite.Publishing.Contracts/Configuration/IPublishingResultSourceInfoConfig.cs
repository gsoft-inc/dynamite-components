using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration interface for the creation of the Result Sources
    /// </summary>
    public interface IPublishingResultSourceInfoConfig
    {
        /// <summary>
        /// Property that return all the result sources to create in the publishing module
        /// </summary>
        /// <returns>The result sources</returns>
        IList<ResultSourceInfo> ResultSources { get; }

        /// <summary>
        /// Gets the result source information by name from this configuration.
        /// </summary>
        /// <param name="name">The name of the result source.</param>
        /// <returns>The result source information</returns>
        ResultSourceInfo GetResultSourceInfoByName(string name);
    }
}
