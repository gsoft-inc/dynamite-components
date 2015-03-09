using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Result Source definitions for the multilingualism module
    /// </summary>
    public class MultilingualismResultSourceInfos
    {
        private readonly PublishingResultSourceInfos publishingResultSourceInfos;
        private readonly MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingResultSourceInfos">The result source settings from the publishing module</param>
        /// <param name="multilingualismManagedPropertyInfos">The managed property settings from the multilingualism module</param>
        public MultilingualismResultSourceInfos(
            PublishingResultSourceInfos publishingResultSourceInfos, 
            MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos)
        {
            this.publishingResultSourceInfos = publishingResultSourceInfos;
            this.multilingualismManagedPropertyInfos = multilingualismManagedPropertyInfos;
        }

        /// <summary>
        /// Override the single catalog item result source query by appending the language condition
        /// </summary>
        /// <returns>The updated result source info</returns>
        public ResultSourceInfo SingleCatalogItem()
        {
            var singleCatalogItem = this.publishingResultSourceInfos.SingleCatalogItem();

            var itemLanguage = this.multilingualismManagedPropertyInfos.ItemLanguage.Name;

            // Extend the existing query 
            singleCatalogItem.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;
            singleCatalogItem.Query =
                itemLanguage + ":{Page.DynamiteItemLanguage}";

            return singleCatalogItem;
        }

        /// <summary>
        /// Override the single target item result source query by appending the language condition
        /// </summary>
        /// <returns>The updated result source info</returns>
        public ResultSourceInfo SingleTargetItem()
        {
            var singleCatalogItem = this.publishingResultSourceInfos.SingleTargetItem();
            singleCatalogItem.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;

            var itemLanguage = this.multilingualismManagedPropertyInfos.ItemLanguage.Name;

            // Extend the existing query 
            singleCatalogItem.Query = itemLanguage + ":{Page.DynamiteItemLanguage}";

            return singleCatalogItem;
        }

        /// <summary>
        /// Override the catalog category items result source query by appending the language condition
        /// </summary>
        /// <returns>The updated result source info</returns>
        public ResultSourceInfo CatalogCategoryItems()
        {
            var singleCatalogItem = this.publishingResultSourceInfos.CatalogCategoryItems();
            singleCatalogItem.UpdateMode = ResultSourceUpdateBehavior.AppendToQuery;

            var itemLanguage = this.multilingualismManagedPropertyInfos.ItemLanguage.Name;

            // Extend the existing query 
            singleCatalogItem.Query = itemLanguage + ":{Page.DynamiteItemLanguage}";

            return singleCatalogItem;
        }
    }
}
