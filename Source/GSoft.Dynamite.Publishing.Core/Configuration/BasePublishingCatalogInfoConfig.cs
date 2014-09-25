using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;
using System.Collections.Generic;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingCatalogInfoConfig : IBasePublishingCatalogInfoConfig
    {
        private readonly BasePublishingCatalogInfos _catalogInfoValues;

        public BasePublishingCatalogInfoConfig(BasePublishingCatalogInfos catalogInfoValues)
        {
            _catalogInfoValues = catalogInfoValues;
        }

        public IDictionary<string, CatalogInfo> Catalogs()
        {
            var catalogs = new Dictionary<string, CatalogInfo>
            {
                {BasePublishingCatalogInfoKeys.NewsPagesCatalog, _catalogInfoValues.NewsPages()},
                {BasePublishingCatalogInfoKeys.ContentPagesCatalog, _catalogInfoValues.ContentPages()}
            };

            return catalogs;
        }
    }
}
