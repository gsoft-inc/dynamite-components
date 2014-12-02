using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    /// <summary>
    /// Search managed properties configuration for the whole solution. Remember, managed properties are only created in the document management module, after the content is uploaded.
    /// </summary>
    public interface IDocsManagedPropertyInfoConfig
    {
        /// <summary>
        /// Property that return all the managed properties to create or configure from all the modules in the solution
        /// </summary>
        IList<ManagedPropertyInfo> ManagedProperties { get; } 
    }
}
