using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions
{
    public interface ICustomPublishingCatalogInfoConfig
    {
        /// <summary>
        /// Catalogs definition
        /// </summary>
        /// <returns>The catalog configuration</returns>
        IDictionary<string, CatalogInfo> Catalogs();
    }
}
