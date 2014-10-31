using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationCatalogConnectionInfoConfig : INavigationCatalogConnectionInfoConfig
    {
        private readonly NavigationCatalogConnectionInfos navigationCatalogConnectionInfos;

        public NavigationCatalogConnectionInfoConfig(NavigationCatalogConnectionInfos navigationCatalogConnectionInfos)
        {
            this.navigationCatalogConnectionInfos = navigationCatalogConnectionInfos;
        }

        public IList<CatalogConnectionInfo> CatalogConnections
        {
            get
            {
                return new List<CatalogConnectionInfo>()
                {
                    {this.navigationCatalogConnectionInfos.NewsPagesConnection()},
                    {this.navigationCatalogConnectionInfos.ContentPagesConnection()}
                };
            }         
        }
    }
}
