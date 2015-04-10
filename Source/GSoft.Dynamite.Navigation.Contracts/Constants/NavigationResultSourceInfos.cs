using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;
using Microsoft.Office.Server.Search.Administration;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Result sources configuration for the navigation module
    /// </summary>
    public class NavigationResultSourceInfos
    {
        private readonly PublishingResultSourceInfos resultSourceInfos;
        private readonly PublishingManagedPropertyInfos publishingManagedPropertyInfos;
        private readonly NavigationManagedPropertyInfos navigationManagedPropertyInfos;
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="resultSourceInfos">The result sources configuration objects from the publishing module</param>
        /// <param name="publishingManagedPropertyInfos">The search managed properties configuration objects from the publishing module</param>
        /// <param name="navigationManagedPropertyInfos">The search managed properties configuration objects from the navigation module</param>
        /// <param name="publishingContentTypeInfos">The content types properties configuration objects from the publishing module</param>
        public NavigationResultSourceInfos(
            PublishingResultSourceInfos resultSourceInfos, 
            PublishingManagedPropertyInfos publishingManagedPropertyInfos,
            NavigationManagedPropertyInfos navigationManagedPropertyInfos,
            PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.resultSourceInfos = resultSourceInfos;
            this.publishingManagedPropertyInfos = publishingManagedPropertyInfos;
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        /// <summary>
        /// The search result source to get a single catalog item according to the current taxonomy navigation context
        /// </summary>
        /// <returns>The result source info</returns>
        public ResultSourceInfo SingleCatalogItem()
        {
            var singleCatalogItem = this.resultSourceInfos.SingleCatalogItem();

            var dateSlug = this.navigationManagedPropertyInfos.DateSlugManagedProperty.Name;
            var titleSlug = this.navigationManagedPropertyInfos.TitleSlugManagedProperty.Name;
            var listItemId = this.publishingManagedPropertyInfos.ListItemId.Name;
            var navigation = this.publishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;
            singleCatalogItem.Query = 
              string.Format("{0}:{{Term}}" + " {1}:{{URLToken.1}}" + " {2}={{URLToken.2}}" + " {3}:{{URLToken.3}}", navigation, titleSlug, listItemId, dateSlug);

            return singleCatalogItem;
        }

        /// <summary>
        /// The search result source to get a single item according to the current taxonomy navigation context
        /// </summary>
        /// <returns>The result source info</returns>
        public ResultSourceInfo SingleTargetItem()
        {
            var singleCatalogItem = this.resultSourceInfos.SingleTargetItem();
            singleCatalogItem.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;

            var navigation = this.publishingManagedPropertyInfos.Navigation.Name;
            var targetContentTypeId = this.publishingContentTypeInfos.TargetContentItem().ContentTypeId;

            // Extend the existing query 
            singleCatalogItem.Query = navigation + ":{Term}" + " " + "ContentTypeId:" + targetContentTypeId + "*";

            return singleCatalogItem;
        }

        /// <summary>
        /// The search result source to get all items in the menu
        /// </summary>
        /// <returns>The result source info</returns>
        public ResultSourceInfo AllMenuItems()
        {
            return new ResultSourceInfo()
            {
                Name = "All Menu Items",
                Level = SearchObjectLevel.Ssa,
                UpdateMode = ResultSourceUpdateBehavior.OverwriteResultSource,
                Query = NavigationResultSourceInfos.AppendToSearchKqlPrefix(string.Empty)
            };
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
