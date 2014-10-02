using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingCatalogInfoConfig : ICustomPublishingCatalogInfoConfig
    {
        private readonly DynamiteDemoPublishingCatalogInfos _catalogInfoValues;

        public DynamiteDemoPublishingCatalogInfoConfig(DynamiteDemoPublishingCatalogInfos catalogInfoValues)
        {
            _catalogInfoValues = catalogInfoValues;
        }

        public IList<CatalogInfo> Catalogs()
        {
            var catalogs = new List<CatalogInfo>
            {
                {_catalogInfoValues.DynamiteCatalog()},
            };

            return catalogs;
        }
    }
}
