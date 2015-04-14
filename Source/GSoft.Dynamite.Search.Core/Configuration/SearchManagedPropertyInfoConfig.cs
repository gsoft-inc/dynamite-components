using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;

namespace GSoft.Dynamite.Search.Core.Configuration
{
    /// <summary>
    /// The Managed properties configuration for the search module
    /// </summary>
    public class SearchManagedPropertyInfoConfig : ICommonManagedPropertyConfig
    {
        /// <summary>
        /// Property that return all the Managed properties to create in the search module
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    SearchManagedPropertyInfos.BrowserTitle,
                    SearchManagedPropertyInfos.MetaDescription,
                    SearchManagedPropertyInfos.MetaKeywords,
                    SearchManagedPropertyInfos.RobotsNoIndex
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
