using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationCatalogConnectionInfoConfig
    {
        IList<CatalogConnectionInfo> CatalogConnections { get; }
    }
}
