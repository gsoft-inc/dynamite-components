using GSoft.Dynamite.Catalogs;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.Contracts.Config
{
    /// <summary>
    /// Configuration hook for Portal cross-site publishing catalogs
    /// </summary>
    public interface IPortalCatalogConfig
    {
        /// <summary>
        /// The full list of all catalog definitions to provision
        /// </summary>
        IList<Catalog> CatalogDefinitionsForWeb(SPWeb web);
    }
}
