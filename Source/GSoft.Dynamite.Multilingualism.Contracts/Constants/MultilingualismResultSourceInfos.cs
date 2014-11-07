using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    public class MultilingualismResultSourceInfos
    {
        private readonly PublishingResultSourceInfos publishingResultSourceInfos;
        private readonly MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos;

        public MultilingualismResultSourceInfos(PublishingResultSourceInfos publishingResultSourceInfos, MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos)
        {
            this.publishingResultSourceInfos = publishingResultSourceInfos;
            this.multilingualismManagedPropertyInfos = multilingualismManagedPropertyInfos;
        }

        public ResultSourceInfo SingleCatalogItem()
        {
            var singleCatalogItem = publishingResultSourceInfos.SingleCatalogItem();

            var itemLanguage = multilingualismManagedPropertyInfos.ItemLanguage.Name;

            // Extend the existing query 
            singleCatalogItem.UpdateMode = UpdateBehavior.AppendToQuery;
            singleCatalogItem.Query =
                itemLanguage + ":{Page.DynamiteItemLanguage}";

            return singleCatalogItem;
        }

        public ResultSourceInfo SingleTargetItem()
        {
            var singleCatalogItem = publishingResultSourceInfos.SingleTargetItem();
            singleCatalogItem.UpdateMode = UpdateBehavior.AppendToQuery;

            var itemLanguage = multilingualismManagedPropertyInfos.ItemLanguage.Name;

            // Extend the existing query 
            singleCatalogItem.Query = itemLanguage + ":{Page.DynamiteItemLanguage}";

            return singleCatalogItem;
        }

        public ResultSourceInfo CatalogCategoryItems()
        {
            var singleCatalogItem = publishingResultSourceInfos.CatalogCategoryItems();
            singleCatalogItem.UpdateMode = UpdateBehavior.AppendToQuery;

            var itemLanguage = multilingualismManagedPropertyInfos.ItemLanguage.Name;

            // Extend the existing query 
            singleCatalogItem.Query = itemLanguage + ":{Page.DynamiteItemLanguage}";

            return singleCatalogItem;
        }
    }
}
