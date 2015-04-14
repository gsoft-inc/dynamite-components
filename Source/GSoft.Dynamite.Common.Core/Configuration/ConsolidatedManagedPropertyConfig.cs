using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Common.Core.Configuration
{
    /// <summary>
    /// Search managed properties configuration for the whole solution. Remember, managed properties are only created in the migration module, after the content is uploaded.
    /// </summary>
    public class ConsolidatedManagedPropertyConfig : IConsolidatedManagedPropertyConfig
    {
        private readonly IList<ICommonManagedPropertyConfig> modulesConfiguration;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="modulesConfiguration">A list of managed properties configuration got from all modules in the solution</param>
        public ConsolidatedManagedPropertyConfig(IList<ICommonManagedPropertyConfig> modulesConfiguration)
        {
            this.modulesConfiguration = modulesConfiguration;
        }

        /// <summary>
        /// Property that return all the managed properties to create or configure from all the modules in the solution
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>();
                foreach (var configuration in this.modulesConfiguration)
                {
                    managedProperties.AddRange(configuration.ManagedProperties);
                }

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
