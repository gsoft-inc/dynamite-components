using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    public class DocsManagedPropertyInfosConfig : IDocsManagedPropertyInfoConfig
    {
        private readonly IList<IPublishingManagedPropertyInfosConfig> modulesConfiguration;

        public DocsManagedPropertyInfosConfig(IList<IPublishingManagedPropertyInfosConfig> modulesConfiguration)
        {
            this.modulesConfiguration = modulesConfiguration;
        }

        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>();

                foreach (var configuration in modulesConfiguration)
                {
                    managedProperties.AddRange(configuration.ManagedProperties);
                }

                return managedProperties;
            }
        }
    }
}
