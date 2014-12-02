using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Catalog connections configuration for the navigation module. Only for Cross Site Publishing based solutions
    /// </summary>
    public class NavigationCatalogConnectionInfoConfig : INavigationCatalogConnectionInfoConfig
    {
        private readonly NavigationCatalogConnectionInfos navigationCatalogConnectionInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="navigationCatalogConnectionInfos">The catalog connections info objects configuration</param>
        public NavigationCatalogConnectionInfoConfig(NavigationCatalogConnectionInfos navigationCatalogConnectionInfos)
        {
            this.navigationCatalogConnectionInfos = navigationCatalogConnectionInfos;
        }

        /// <summary>
        /// Property that return all the catalog connections to create or configure in the publishing module
        /// </summary>
        public IList<CatalogConnectionInfo> CatalogConnections
        {
            get
            {
                return new List<CatalogConnectionInfo>()
                {
                    this.navigationCatalogConnectionInfos.NewsPagesConnection(),
                    this.navigationCatalogConnectionInfos.ContentPagesConnection()
                };
            }         
        }
    }
}
