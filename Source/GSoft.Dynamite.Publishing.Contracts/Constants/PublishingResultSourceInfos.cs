using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;
using Microsoft.Office.Server.Search.Administration;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Result Source definitions for the publishing module
    /// </summary>
    public static class PublishingResultSourceInfos
    {
        /// <summary>
        /// A single Catalog Item result source
        /// </summary>
        /// <returns>A ResultSourceInfo object</returns>
        public static ResultSourceInfo SingleCatalogItem
        {
            get
            {
                return new ResultSourceInfo()
                {
                    Name = "Single Catalog Item",
                    Level = SearchObjectLevel.Ssa,
                    UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                    Query = string.Empty,
                };
            }
        }

        /// <summary>
        /// A single target item
        /// </summary>
        /// <returns>A result source info object</returns>
        public static ResultSourceInfo SingleTargetItem
        {
            get
            {
                return new ResultSourceInfo()
                {
                    Name = "Single Target Item",
                    Level = SearchObjectLevel.Ssa,
                    UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                    Query = string.Empty
                };
            }
        }

        /// <summary>
        /// A single target item
        /// </summary>
        /// <returns>A result source info object</returns>
        public static ResultSourceInfo CatalogCategoryItems
        {
            get
            {
                return new ResultSourceInfo()
                {
                    Name = "Catalog Category Items",
                    Level = SearchObjectLevel.Ssa,
                    UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                    Query = "GPP|{Term.IdWithChildren}"
                };
            }
        }
    }
}
