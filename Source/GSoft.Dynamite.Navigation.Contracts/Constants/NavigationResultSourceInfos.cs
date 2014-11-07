using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationResultSourceInfos
    {
        private readonly PublishingResultSourceInfos resultSourceInfos;
        private readonly  PublishingManagedPropertyInfos publishingManagedPropertyInfos;
        private readonly  NavigationManagedPropertyInfos navigationManagedPropertyInfos;

        public NavigationResultSourceInfos(PublishingResultSourceInfos resultSourceInfos, 
            PublishingManagedPropertyInfos publishingManagedPropertyInfos,
            NavigationManagedPropertyInfos navigationManagedPropertyInfos)
        {
            this.resultSourceInfos = resultSourceInfos;
            this.publishingManagedPropertyInfos = publishingManagedPropertyInfos;
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
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
    }
}
