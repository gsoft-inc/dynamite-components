using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Migration.Contracts.Configuration
{
    /// <summary>
    /// Search managed properties configuration for the whole solution. Remember, managed properties are only created in the migration module, after the content is uploaded.
    /// </summary>
    public interface IMigrationManagedPropertyInfoConfig
    {
        /// <summary>
        /// Property that return all the managed properties to create or configure from all the modules in the solution
        /// </summary>
        IList<ManagedPropertyInfo> ManagedProperties { get; } 
    }
}
