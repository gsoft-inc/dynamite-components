using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationResultSourceInfos
    {
        private readonly PublishingResultSourceInfos resultSourceInfos;
        private readonly  PublishingManagedPropertyInfos publishingManagedPropertyInfos;
        private readonly  NavigationManagedPropertyInfos navigationManagedPropertyInfos;
        private readonly MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos;
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        public NavigationResultSourceInfos(PublishingResultSourceInfos resultSourceInfos, 
            PublishingManagedPropertyInfos publishingManagedPropertyInfos,
            NavigationManagedPropertyInfos navigationManagedPropertyInfos,
            MultilingualismManagedPropertyInfos multilingualismManagedPropertyInfos,
            PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.resultSourceInfos = resultSourceInfos;
            this.publishingManagedPropertyInfos = publishingManagedPropertyInfos;
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
            this.multilingualismManagedPropertyInfos = multilingualismManagedPropertyInfos;
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        public ResultSourceInfo SingleCatalogItem()
        {
            var singleCatalogItem = resultSourceInfos.SingleCatalogItem();

            var dateSlug = this.navigationManagedPropertyInfos.DateSlugManagedProperty.Name;
            var titleSlug = this.navigationManagedPropertyInfos.TitleSlugManagedProperty.Name;
            var listItemId = this.publishingManagedPropertyInfos.ListItemId.Name;
            var navigation = this.publishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.UpdateMode = UpdateBehavior.AppendToQuery;
            singleCatalogItem.Query = 
              navigation + ":{Term}" + " " + titleSlug +":{URLToken.1}" + " " + listItemId + "={URLToken.2}" + " " + dateSlug + ":{URLToken.3}";

            return singleCatalogItem;

        }

        public ResultSourceInfo SingleTargetItem()
        {
            var singleCatalogItem = resultSourceInfos.SingleTargetItem();
            singleCatalogItem.UpdateMode = UpdateBehavior.AppendToQuery;

            var navigation = this.publishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.Query =navigation + ":{Term}";

            return singleCatalogItem;
        }

        public ResultSourceInfo AllMenuItems()
        {
            var itemLanguage  = this.multilingualismManagedPropertyInfos.ItemLanguage.Name;
            var catalogItemContentTypeId = this.publishingContentTypeInfos.CatalogContentItem().ContentTypeId;

            return new ResultSourceInfo()
            {
                Name = "All Menu Items",
                Level = SearchObjectLevel.Ssa,
                UpdateMode = UpdateBehavior.OverwriteResultSource,
                Query = itemLanguage + ":{Page.DynamiteItemLanguage}" + " " + BuiltInManagedProperties.ContentTypeId + ":" + catalogItemContentTypeId + "*"
            };
        }
    }
}
