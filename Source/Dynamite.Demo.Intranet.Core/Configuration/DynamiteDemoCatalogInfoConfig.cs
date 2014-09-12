using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Core.Keys;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoCatalogInfoConfig : ICustomCatalogInfoConfig
    {
        private readonly DynamiteDemoCatalogInfoValues _catalogInfoValues;

        public DynamiteDemoCatalogInfoConfig(DynamiteDemoCatalogInfoValues catalogInfoValues)
        {
            _catalogInfoValues = catalogInfoValues;
        }

        public IDictionary<string, CatalogInfo> Catalogs()
        {
            var catalogs = new Dictionary<string, CatalogInfo>
            {
                {DynamiteDemoCatalogInfoKeys.DynamiteDemoPagesCatalog, _catalogInfoValues.DynamiteCatalog()},
            };

            return catalogs;
        }
    }
}
