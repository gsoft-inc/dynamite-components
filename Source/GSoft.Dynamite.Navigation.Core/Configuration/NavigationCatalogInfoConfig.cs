using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Navigation.Contracts.Configuration;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Configuration for the catalogs settings. Catalogs are only used with Cross Site Publishing based solutions
    /// </summary>
    public class NavigationCatalogInfoConfig : INavigationCatalogInfoConfig
    {
        /// <summary>
        /// The catalog configuration  the navigation module
        /// </summary>
        public IList<CatalogInfo> Catalogs
        {
            get 
            {
                return null;
            }
        }
    }
}
