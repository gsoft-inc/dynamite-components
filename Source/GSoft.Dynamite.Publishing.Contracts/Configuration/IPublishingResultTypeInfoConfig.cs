using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// The search result types configuration for the publishing module
    /// </summary>
    public interface IPublishingResultTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the result types to create in the publishing module
        /// </summary>
        IList<ResultTypeInfo> ResultTypes { get; }

        /// <summary>
        /// Gets the result type information by name from this configuration.
        /// </summary>
        /// <param name="name">The name of the Result Type.</param>
        /// <returns>The result type information</returns>
        ResultTypeInfo GetResultTypeInfoByName(string name);
    }
}
