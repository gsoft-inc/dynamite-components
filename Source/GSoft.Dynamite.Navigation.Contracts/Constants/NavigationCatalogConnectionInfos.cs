using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationCatalogConnectionInfos
    {
        private readonly PublishingCatalogInfos publishingCatalogInfos;
        private readonly PublishingManagedPropertyInfos publishingManagedPropertyInfos;
        private readonly NavigationManagedPropertyInfos navigationManagedPropertyInfos;

        public NavigationCatalogConnectionInfos(PublishingCatalogInfos publishingCatalogInfos, 
            PublishingManagedPropertyInfos publishingManagedPropertyInfos, NavigationManagedPropertyInfos navigationManagedPropertyInfos)
        {
            this.publishingCatalogInfos = publishingCatalogInfos;
            this.publishingManagedPropertyInfos = publishingManagedPropertyInfos;
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
        }

        public CatalogConnectionInfo NewsPagesConnection()
        {
            // Friendly URL format
            var itemSlug = "/[" + this.navigationManagedPropertyInfos.DateSlugManagedProperty.Name + "]/[" +
                           this.publishingManagedPropertyInfos.ListItemId.Name + "]/[" + this.navigationManagedPropertyInfos.TitleSlugManagedProperty.Name +
                           "]";     

            // The SPWeb will be populated during the feature activation
            return new CatalogConnectionInfo(
                
                this.publishingCatalogInfos.NewsPages(),

                this.publishingManagedPropertyInfos.Navigation.Name,
                true,
                false,
                false,
                itemSlug            
                );
        }

        public CatalogConnectionInfo ContentPagesConnection()
        {
            // Friendly URL format
            var itemSlug = "/[" + this.navigationManagedPropertyInfos.DateSlugManagedProperty.Name + "]/[" +
                           this.publishingManagedPropertyInfos.ListItemId.Name + "]/[" + this.navigationManagedPropertyInfos.TitleSlugManagedProperty.Name +
                           "]";

            // The SPWeb will be populated during the feature activation
            return new CatalogConnectionInfo(

                this.publishingCatalogInfos.ContentPages(),
                this.publishingManagedPropertyInfos.Navigation.Name,
                true,
                false,
                false,
                itemSlug
                );
        }
    }
}
