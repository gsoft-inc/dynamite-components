using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Search managed properties configuration for the multilingualism module
    /// </summary>
    public class MultilingualismManagedPropertyInfoConfig : ICommonManagedPropertyConfig
    {
        /// <summary>
        /// Property that return all the managed properties to create or configure in the multilingualism module
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    MultilingualismManagedPropertyInfos.ContentAssociationKey,
                    MultilingualismManagedPropertyInfos.ItemLanguage
                };

                return managedProperties;
            }
        }

        /// <summary>
        /// Gets the managed property information by name from this configuration.
        /// </summary>
        /// <param name="ManagedPropertyName">Name of the managed property.</param>
        /// <returns>The managed property information</returns>
        public ManagedPropertyInfo GetManagedPropertyInfoByName(string managedPropertyName)
        {
            return this.ManagedProperties.Single(m => m.Name.Equals(managedPropertyName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
