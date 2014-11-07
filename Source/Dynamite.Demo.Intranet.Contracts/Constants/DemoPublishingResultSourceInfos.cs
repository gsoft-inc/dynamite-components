using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Search;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public class DemoPublishingResultSourceInfos
    {
        private const string SearchKqlprefix = "{?{searchTerms} -ContentClass=urn:content-class:SPSPeople}";

        public ResultSourceInfo DynamiteDemoResultSource()
        {
            return new ResultSourceInfo()
            {
                Name = "Dynanmite Demo Item",
                Level = SearchObjectLevel.Ssa,
                UpdateMode = UpdateBehavior.OverwriteResultSource,
                Query = SearchKqlprefix,
                SortSettings = new Dictionary<string, SortDirection>()
                {
                    {"ListItemID",SortDirection.Ascending}
                }
            };
        }
    }
}
