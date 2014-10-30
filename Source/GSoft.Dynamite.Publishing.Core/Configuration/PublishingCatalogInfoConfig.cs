using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingCatalogInfoConfig : IPublishingCatalogInfoConfig
    {
        private readonly PublishingCatalogInfos _catalogInfoValues;

        public PublishingCatalogInfoConfig(PublishingCatalogInfos catalogInfoValues)
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
