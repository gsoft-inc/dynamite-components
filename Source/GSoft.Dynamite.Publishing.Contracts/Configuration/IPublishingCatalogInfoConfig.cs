using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingCatalogInfoConfig
    {
        IList<CatalogInfo> Catalogs();
    }
}