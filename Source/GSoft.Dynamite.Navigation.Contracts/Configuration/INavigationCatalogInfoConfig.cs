using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Catalogs;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Configuration interface for the catalogs settings. Catalogs are only used with Cross Site Publishing based solutions
    /// </summary>
    public interface INavigationCatalogInfoConfig
    {
        /// <summary>
        /// Property that return all the catalogs to use in the navigation module
        /// </summary>
        IList<CatalogInfo> Catalogs { get; }
    }
}
