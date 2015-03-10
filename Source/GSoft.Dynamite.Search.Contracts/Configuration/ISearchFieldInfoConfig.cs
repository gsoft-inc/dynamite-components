using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Search.Contracts.Configuration
{
    /// <summary>
    /// Interface for the base search field info config.
    /// </summary>
    public interface ISearchFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the field to create in the search module
        /// </summary>
        /// <returns>he fields</returns>
        IList<IFieldInfo> Fields { get; }
    }
}
