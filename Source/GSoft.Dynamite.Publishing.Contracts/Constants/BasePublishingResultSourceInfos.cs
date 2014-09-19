using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingResultSourceInfos
    {
        private const string SearchKqlprefix = "{?{searchTerms} -ContentClass=urn:content-class:SPSPeople}";

        public ResultSourceInfo SingleCatalogItem()
        {
            return new ResultSourceInfo()
            {
                Name = "Single Catalog Item",
                Level = SearchObjectLevel.Ssa,
                Overwrite = false,
                Query = SearchKqlprefix,
                SortSettings = new Dictionary<string, SortDirection>()
                {
                    {"ListItemID",SortDirection.Ascending}
                }
            };
        }

        public ResultSourceInfo SingleTargetItem()
        {
            return new ResultSourceInfo()
            {
                Name = "Single Target Item",
                Level = SearchObjectLevel.Ssa,
                Overwrite = false,
                Query = SearchKqlprefix
            };
        }
    }
}
