using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration for the creation of the Search Managed Properties
    /// As we want to minimize the amount of operations for managed properties creation, 
    /// this configuration interface is used by all the modules across the solution. 
    /// At the end, this configuration is processed in the "Docs" module, after the content provisioning, prerequisite of a search managed property creation.
    /// </summary>
    public interface IPublishingManagedPropertyInfoConfig
    {
        /// <summary>
        /// Property that return all the search managed properties to create or configure in all modules
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
