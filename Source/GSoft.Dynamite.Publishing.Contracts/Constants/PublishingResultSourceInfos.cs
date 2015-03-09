using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;
using Microsoft.Office.Server.Search.Administration;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Result Source definitions for the publishing module
    /// </summary>
    public class PublishingResultSourceInfos
    {
        private const string SearchKqlprefix = "{?{searchTerms} -ContentClass=urn:content-class:SPSPeople}";

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
                UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                Query = string.Empty,
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
                UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                Query = string.Empty
            };
        }

        /// <summary>
        /// A single target item
        /// </summary>
        /// <returns>A result source info object</returns>
        public ResultSourceInfo CatalogCategoryItems()
        {
            return new ResultSourceInfo()
            {
                Name = "Catalog Category Items",
                Level = SearchObjectLevel.Ssa,
                UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                Query = "GPP|{Term.IdWithChildren}"
            };
        }

        /// <summary>
        /// Method to Append a query to the Search KQL prefix
        /// </summary>
        /// <param name="queryToAppend">Query text to append to the existing query</param>
        /// <returns>The string prefixed with the Search KQL</returns>
        public static string AppendToSearchKqlPrefix(string queryToAppend)
        {
            return string.Format("{0} {1}", SearchKqlprefix, queryToAppend);
        }
    }
}
