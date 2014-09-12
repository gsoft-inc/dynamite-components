using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;
using System.Collections.Generic;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BaseCatalogInfoConfig : IBaseCatalogInfoConfig
    {
        private readonly BaseCatalogInfoValues _catalogInfoValues;

        public BaseCatalogInfoConfig(BaseCatalogInfoValues catalogInfoValues)
        {
            _catalogInfoValues = catalogInfoValues;
        }

        public IDictionary<string, CatalogInfo> Catalogs()
        {
            var catalogs = new Dictionary<string, CatalogInfo>
            {
                {BaseCatalogInfoKeys.NewsPagesCatalog, _catalogInfoValues.NewsPages()},
                {BaseCatalogInfoKeys.ContentPagesCatalog, _catalogInfoValues.ContentPages()}
            };

            return catalogs;
        }
    }
}
