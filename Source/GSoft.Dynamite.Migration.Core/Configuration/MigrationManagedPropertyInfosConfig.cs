using System.Collections.Generic;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Migration.Core.Configuration
{
    /// <summary>
    /// Search managed properties configuration for the whole solution. Remember, managed properties are only created in the migration module, after the content is uploaded.
    /// </summary>
    public class MigrationManagedPropertyInfosConfig : IMigrationManagedPropertyInfoConfig
    {
        private readonly IList<ICommonManagedPropertyInfosConfig> modulesConfiguration;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="modulesConfiguration">A list of managed properties configuration got from all modules in the solution</param>
        public MigrationManagedPropertyInfosConfig(IList<ICommonManagedPropertyInfosConfig> modulesConfiguration)
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
    }
}
