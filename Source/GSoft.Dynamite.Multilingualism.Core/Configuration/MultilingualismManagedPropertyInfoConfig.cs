using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class MultilingualismManagedPropertyInfoConfig : IGlobalManagedPropertyInfosConfig
    {
        private readonly MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos;

        public MultilingualismManagedPropertyInfoConfig(MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos)
        {
            this.multilingualismManagedPropertyInfos = multilingualismManagedPropertyInfos;
        }

        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    {this.multilingualismManagedPropertyInfos.ContentAssociationKey},
                    {this.multilingualismManagedPropertyInfos.ItemLanguage}
                };

                return managedProperties;
            }
        }
    }
}
