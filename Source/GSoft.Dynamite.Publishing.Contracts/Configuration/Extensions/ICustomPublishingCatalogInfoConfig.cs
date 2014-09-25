using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions
{
    public interface ICustomPublishingCatalogInfoConfig
    {
        /// <summary>
        /// Catalogs definition
        /// </summary>
        IList<CatalogInfo> Catalogs();
    }
}
