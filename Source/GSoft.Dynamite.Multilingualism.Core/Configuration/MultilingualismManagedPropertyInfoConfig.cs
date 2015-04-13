using System.Collections.Generic;
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
        private readonly MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="multilingualismManagedPropertyInfos">The managed properties settings from the multilingualism module</param>
        public MultilingualismManagedPropertyInfoConfig(MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos)
        {
            this.multilingualismManagedPropertyInfos = multilingualismManagedPropertyInfos;
        }

        /// <summary>
        /// Property that return all the managed properties to create or configure in the multilingualism module
        /// </summary>
        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    this.multilingualismManagedPropertyInfos.ContentAssociationKey,
                    this.multilingualismManagedPropertyInfos.ItemLanguage
                };

                return managedProperties;
            }
        }
    }
}
