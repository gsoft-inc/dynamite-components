using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;
using Microsoft.Office.Server.Search.Administration;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Result sources configuration for the navigation module
    /// </summary>
    public static class NavigationResultSourceInfos
    {
        /// <summary>
        /// The search result source to get all items in the menu
        /// </summary>
        /// <returns>The result source info</returns>
        public static ResultSourceInfo AllMenuItems
        {
            get
            {
                return new ResultSourceInfo()
                {
                    Name = "All Menu Items",
                    Level = SearchObjectLevel.Ssa,
                    UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                    Query = NavigationResultSourceInfos.AppendToSearchKqlPrefix(string.Empty)
                };
            }
        }

        /// <summary>
        /// Method to Append a query to the Search KQL prefix
        /// </summary>
        /// <param name="queryToAppend">Query text to append to the existing query</param>
        /// <returns>The string prefixed with the Search KQL</returns>
        private static string AppendToSearchKqlPrefix(string queryToAppend)
        {
            string SearchKqlprefix = "{?{searchTerms} -ContentClass=urn:content-class:SPSPeople}";
            return string.Format("{0} {1}", SearchKqlprefix, queryToAppend);
        }
    }
}
