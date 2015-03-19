using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;

namespace GSoft.Dynamite.Search.Core.Configuration
{
    /// <summary>
    /// The Managed properties configuration for the search module
    /// </summary>
    public class SearchManagedPropertyInfoConfig : ICommonManagedPropertyInfosConfig
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
    }
}
