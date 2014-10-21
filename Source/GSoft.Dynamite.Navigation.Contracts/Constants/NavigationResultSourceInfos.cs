using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationResultSourceInfos
    {
        private readonly PublishingResultSourceInfos resultSourceInfos;

        public NavigationResultSourceInfos(PublishingResultSourceInfos resultSourceInfos)
        {
            this.resultSourceInfos = resultSourceInfos;
        }

        public ResultSourceInfo SingleCatalogItem()
        {
            var singleCatalogItem = resultSourceInfos.SingleCatalogItem();

            // Not a problem if you overwrite the existing result source (it doesn't cause broken links)
            singleCatalogItem.Overwrite = true;

            var dateSlug = NavigationManagedPropertyInfos.DateSlugManagedProperty.Name;
            var titleSlug = NavigationManagedPropertyInfos.TitleSlugManagedProperty.Name;
            var listItemId = PublishingManagedPropertyInfos.ListItemId.Name;
            var navigation = PublishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.Query += 
              " " + navigation + ":{Term}" + " " + titleSlug +":{URLToken.1}" + " " + listItemId + "={URLToken.2}" + " " + dateSlug + ":{URLToken.3}";

            return singleCatalogItem;

        }

        public ResultSourceInfo SingleTargetItem()
        {
            var singleCatalogItem = resultSourceInfos.SingleCatalogItem();

            singleCatalogItem.Overwrite = true;

            var navigation = PublishingManagedPropertyInfos.Navigation.Name;

            // Extend the existing query 
            singleCatalogItem.Query +=
              " " + navigation + ":{Term}";

            return singleCatalogItem;
        }
    }
}
