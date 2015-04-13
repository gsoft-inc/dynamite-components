using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Catalog connections configuration for the navigation module. Only for Cross Site Publishing based solutions
    /// </summary>
    public interface INavigationCatalogConnectionInfoConfig
    {
        /// <summary>
        /// Property that return all the catalog connections to create or configure in the navigation module
        /// </summary>
        IList<CatalogConnectionInfo> CatalogConnections { get; }

        /// <summary>
        /// Gets the catalog connection information by catalog information from this configuration.
        /// </summary>
        /// <param name="catalog">The catalog information.</param>
        /// <returns>The catalog connection information</returns>
        CatalogConnectionInfo GetCatalogConnectionInfoByCatalog(CatalogInfo catalog);
    }
}
