using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;

namespace GSoft.Dynamite.Search.Core.Configuration
{
    /// <summary>
    /// The Managed properties configuration for the search module
    /// </summary>
    public class SearchManagedPropertyInfoConfig : ICommonManagedPropertyConfig
    {
        private readonly SearchManagedPropertyInfos searchManagedPropertyInfos;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="searchManagedPropertyInfos">Search module managed property info</param>
        public SearchManagedPropertyInfoConfig(SearchManagedPropertyInfos searchManagedPropertyInfos)
        {
            this.searchManagedPropertyInfos = searchManagedPropertyInfos;
        }

        /// <summary>
        /// Property that return all the Managed properties to create in the search module
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    { this.searchManagedPropertyInfos.BrowserTitle },
                    { this.searchManagedPropertyInfos.MetaDescription },
                    { this.searchManagedPropertyInfos.MetaKeywords },
                    { this.searchManagedPropertyInfos.RobotsNoIndex }
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
