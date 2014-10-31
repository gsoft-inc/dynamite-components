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

            // Not a problem if you overwrite the existing result source (it doesn't cause broken links)
            singleCatalogItem.Overwrite = true;

            var dateSlug = this.navigationManagedPropertyInfos.DateSlugManagedProperty.Name;
            var titleSlug = this.navigationManagedPropertyInfos.TitleSlugManagedProperty.Name;
            var listItemId = this.publishingManagedPropertyInfos.ListItemId.Name;
            var navigation = this.publishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.Query += 
              " " + navigation + ":{Term}" + " " + titleSlug +":{URLToken.1}" + " " + listItemId + "={URLToken.2}" + " " + dateSlug + ":{URLToken.3}";

            return singleCatalogItem;

        }

        public ResultSourceInfo SingleTargetItem()
        {
            var singleCatalogItem = resultSourceInfos.SingleCatalogItem();

            singleCatalogItem.Overwrite = true;

            var navigation = this.publishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.Query +=
              " " + navigation + ":{Term}";

            return singleCatalogItem;
        }
    }
}
