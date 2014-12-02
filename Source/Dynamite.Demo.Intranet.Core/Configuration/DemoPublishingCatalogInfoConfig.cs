using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    /// <summary>
    /// Example of an override of catalogs from the publishing module
    /// </summary>
    public class DemoPublishingCatalogInfoConfig : IPublishingCatalogInfoConfig
    {
        private readonly DemoPublishingCatalogInfos _catalogInfoValues;
        private readonly IPublishingCatalogInfoConfig _publishingCatalogInfoConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingCatalogInfoConfig">The catalogs configuration from the publishing module</param>
        /// <param name="catalogInfoValues">The catalog settings from the Dynamite Demo module</param>
        public DemoPublishingCatalogInfoConfig(IPublishingCatalogInfoConfig publishingCatalogInfoConfig, DemoPublishingCatalogInfos catalogInfoValues)
        {
            this._catalogInfoValues = catalogInfoValues;
            this._publishingCatalogInfoConfig = publishingCatalogInfoConfig;
        }

        /// <summary>
        /// Override catalogs from the publishing module
        /// </summary>
        public IList<CatalogInfo> Catalogs
        {
            get
            {
                var baseCatalogConfig = this._publishingCatalogInfoConfig.Catalogs;

                // Reset the base configuration
                baseCatalogConfig.Clear();

                // A a custom catalog
                baseCatalogConfig.Add(this._catalogInfoValues.DynamiteCatalog());

                return baseCatalogConfig;
            }
        }
    }
}
