using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DemoPublishingCatalogInfoConfig : IPublishingCatalogInfoConfig
    {
        private readonly DemoPublishingCatalogInfos _catalogInfoValues;
        private readonly IPublishingCatalogInfoConfig _publishingCatalogInfoConfig;

        public DemoPublishingCatalogInfoConfig(IPublishingCatalogInfoConfig publishingCatalogInfoConfig, DemoPublishingCatalogInfos catalogInfoValues)
        {
            this._catalogInfoValues = catalogInfoValues;
            this._publishingCatalogInfoConfig = publishingCatalogInfoConfig;
        }

        public IList<CatalogInfo> Catalogs()
        {
            var baseCatalogConfig = this._publishingCatalogInfoConfig.Catalogs();

            // Reset the base configuration
            baseCatalogConfig.Clear();

            // A a custom catalog
            baseCatalogConfig.Add(this._catalogInfoValues.DynamiteCatalog());

            return baseCatalogConfig;
        }
    }
}
