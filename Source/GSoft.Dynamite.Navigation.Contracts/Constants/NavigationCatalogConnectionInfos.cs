using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationCatalogConnectionInfos
    {
        private readonly PublishingCatalogInfos publishingCatalogInfos;

        public NavigationCatalogConnectionInfos(PublishingCatalogInfos publishingCatalogInfos)
        {
            this.publishingCatalogInfos = publishingCatalogInfos;
        }

        public CatalogConnectionInfo NewsPagesConnection()
        {
            // Friendly URL format
            var itemSlug = "/[" + NavigationManagedPropertyInfos.DateSlugManagedProperty.Name + "]/[" +
                           PublishingManagedPropertyInfos.ListItemId.Name + "]/[" + NavigationManagedPropertyInfos.TitleSlugManagedProperty.Name +
                           "]";     

            // The SPWeb will be populated during the feature activation
            return new CatalogConnectionInfo(
                
                this.publishingCatalogInfos.NewsPages(),
                
                PublishingManagedPropertyInfos.Navigation.Name,
                true,
                false,
                false,
                itemSlug            
                );
        }

        public CatalogConnectionInfo ContentPagesConnection()
        {
            // Friendly URL format
            var itemSlug = "/[" + NavigationManagedPropertyInfos.DateSlugManagedProperty.Name + "]/[" +
                           PublishingManagedPropertyInfos.ListItemId.Name + "]/[" + NavigationManagedPropertyInfos.TitleSlugManagedProperty.Name +
                           "]";

            // The SPWeb will be populated during the feature activation
            return new CatalogConnectionInfo(

                this.publishingCatalogInfos.ContentPages(),
                PublishingManagedPropertyInfos.Navigation.Name,
                true,
                false,
                false,
                itemSlug
                );
        }
    }
}
