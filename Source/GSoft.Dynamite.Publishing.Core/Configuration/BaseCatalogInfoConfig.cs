using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BaseCatalogInfoConfig : IBaseCatalogInfoConfig
    {
        public IDictionary<string, CatalogInfo> Catalogs()
        {
            #region News Pages

            var catalogs = new Dictionary<string, CatalogInfo>
            {
                {BaseCatalogInfoKeys.NewsPagesCatalog, BaseCatalogInfoValues.NewsPages}
            };

            return catalogs;

            #endregion
        }
    }
}
