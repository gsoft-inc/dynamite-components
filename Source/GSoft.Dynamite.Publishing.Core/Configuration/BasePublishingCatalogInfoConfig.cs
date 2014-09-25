using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
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

        public IList<CatalogInfo> Catalogs()
        {
            var catalogs = new List<CatalogInfo>
            {
                {_catalogInfoValues.NewsPages()},
                {_catalogInfoValues.ContentPages()}
            };

            return catalogs;
        }
    }
}
