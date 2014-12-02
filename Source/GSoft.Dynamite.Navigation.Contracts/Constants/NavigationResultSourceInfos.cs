using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
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

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="resultSourceInfos">The result sources configuration objects from the publishing module</param>
        /// <param name="publishingManagedPropertyInfos">The search managed properties configuration objects from the publishing module</param>
        /// <param name="navigationManagedPropertyInfos">The search managed properties configuration objects from the navigation module</param>
        public NavigationResultSourceInfos(
            PublishingResultSourceInfos resultSourceInfos, 
            PublishingManagedPropertyInfos publishingManagedPropertyInfos,
            NavigationManagedPropertyInfos navigationManagedPropertyInfos)
        {
            this.resultSourceInfos = resultSourceInfos;
            this.publishingManagedPropertyInfos = publishingManagedPropertyInfos;
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
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
            singleCatalogItem.UpdateMode = UpdateBehavior.AppendToQuery;
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
            singleCatalogItem.UpdateMode = UpdateBehavior.AppendToQuery;

            var navigation = this.publishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.Query = navigation + ":{Term}";

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
                UpdateMode = UpdateBehavior.OverwriteResultSource,
                Query = PublishingResultSourceInfos.AppendToSearchKqlPrefix(string.Empty)
            };
        }
    }
}
