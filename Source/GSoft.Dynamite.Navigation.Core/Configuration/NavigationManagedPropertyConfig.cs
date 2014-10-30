using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationManagedPropertyConfig: IGlobalManagedPropertyInfosConfig
    {
        private readonly NavigationManagedPropertyInfos navigationManagedPropertyInfos;

        public NavigationManagedPropertyConfig(NavigationManagedPropertyInfos navigationManagedPropertyInfos)
        {
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
        }

        public IList<ManagedPropertyInfo> ManagedProperties
        {
            get
            {
                var managedProperties = new List<ManagedPropertyInfo>()
                {
                    {this.navigationManagedPropertyInfos.DateSlugManagedProperty},
                    {this.navigationManagedPropertyInfos.TitleSlugManagedProperty}
                };

                return managedProperties;
            }  
        }
    }
}
