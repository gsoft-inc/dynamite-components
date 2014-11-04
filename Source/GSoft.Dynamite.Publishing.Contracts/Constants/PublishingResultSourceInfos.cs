using System.Collections.Generic;
using GSoft.Dynamite.Search;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Holds the Result Source infos for the Publishing module
    /// </summary>
    public class PublishingResultSourceInfos
    {
        private static readonly string SearchKqlprefix = "{?{searchTerms} -ContentClass=urn:content-class:SPSPeople}";

        /// <summary>
        /// A single Catalog Item result source
        /// </summary>
        /// <returns>A ResultSourceInfo object</returns>
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

        /// <summary>
        /// A single target item
        /// </summary>
        /// <returns>A result source info object</returns>
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

        /// <summary>
        /// Method to Append a query to the Search KQL prefix
        /// </summary>
        /// <param name="queryToAppend"></param>
        /// <returns>The string prefixed with the Search KQL</returns>
        public static string AppendToSearchKqlPrefix(string queryToAppend)
        {
            return string.Format("{0} {1}", SearchKqlprefix, queryToAppend);
        }
    }
}
