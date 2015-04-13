using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Common.Contract.Configuration
{
    /// <summary>
    /// Search managed properties configuration for the whole solution. Remember, managed properties are only created in the migration module, after the content is uploaded.
    /// </summary>
    public interface IConsolidatedManagedPropertyConfig
    {
        /// <summary>
        /// Property that return all the managed properties to create or configure from all the modules in the solution
        /// </summary>
        IList<ManagedPropertyInfo> ManagedProperties { get; }

        /// <summary>
        /// Gets the managed property information by name from this configuration.
        /// </summary>
        /// <param name="managedPropertyName">Name of the managed property.</param>
        /// <returns>The managed property information</returns>
        ManagedPropertyInfo GetManagedPropertyInfoByName(string managedPropertyName);
    }
}
