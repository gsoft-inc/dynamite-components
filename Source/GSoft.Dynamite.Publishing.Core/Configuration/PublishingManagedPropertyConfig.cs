using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the creation of the Search Managed Properties
    /// As we want to minimize the amount of operations for managed properties creation, 
    /// this configuration implementation is used by all the modules across the solution. 
    /// At the end, this configuration is processed in the "Docs" module, after the content provisioning, prerequisite of a search managed property creation.
    /// </summary>
    public class PublishingManagedPropertyConfig : ICommonManagedPropertyConfig
    {
        /// <summary>
        /// Property that return all the search managed properties to create in the publishing module
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    PublishingManagedPropertyInfos.NavigationText,
                    PublishingManagedPropertyInfos.Summary,
                };

                return managedProperties;
            }         
        }

        /// <summary>
        /// Gets the managed property information by name from this configuration.
        /// </summary>
        /// <param name="managedPropertyName">Name of the managed property.</param>
        /// <returns>
        /// The managed property information
        /// </returns>
        public ManagedPropertyInfo GetManagedPropertyInfoByName(string managedPropertyName)
        {
            return this.ManagedProperties.Single(m => m.Name.Equals(managedPropertyName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
