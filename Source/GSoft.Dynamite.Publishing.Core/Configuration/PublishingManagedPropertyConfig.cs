using System.Collections.Generic;
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
    public class PublishingManagedPropertyConfig : ICommonManagedPropertyInfosConfig
    {
        private readonly PublishingManagedPropertyInfos publishingManagedPropertyInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingManagedPropertyInfos">The managed properties configuration info objects</param>
        public PublishingManagedPropertyConfig(PublishingManagedPropertyInfos publishingManagedPropertyInfos)
        {
            this.publishingManagedPropertyInfos = publishingManagedPropertyInfos;
        }

        /// <summary>
        /// Property that return all the search managed properties to create in the publishing module
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    this.publishingManagedPropertyInfos.NavigationText,
                };

                return managedProperties;
            }         
        }
    }
}
