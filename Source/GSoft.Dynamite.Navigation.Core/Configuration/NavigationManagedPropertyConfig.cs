using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Configuration for the creation of the Search Managed Properties
    /// As we want to minimize the amount of operations for managed properties creation, 
    /// this configuration interface is used by all the modules across the solution. 
    /// At the end, this configuration is processed in the "Docs" module, after the content provisioning, prerequisite of a search managed property creation.
    /// </summary>
    public class NavigationManagedPropertyConfig : IPublishingManagedPropertyInfoConfig
    {
        private readonly NavigationManagedPropertyInfos navigationManagedPropertyInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="navigationManagedPropertyInfos">The managed property info objects configuration</param>
        public NavigationManagedPropertyConfig(NavigationManagedPropertyInfos navigationManagedPropertyInfos)
        {
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
        }

        /// <summary>
        /// Property that return all the search managed properties to create or configure in the navigation module
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    this.navigationManagedPropertyInfos.DateSlugManagedProperty,
                    this.navigationManagedPropertyInfos.TitleSlugManagedProperty,
                    this.navigationManagedPropertyInfos.OccurrenceLinkLocationManagedProperty,
                    this.navigationManagedPropertyInfos.OccurrenceLinkLocationManagedPropertyText
                };

                return managedProperties;
            }  
        }
    }
}
