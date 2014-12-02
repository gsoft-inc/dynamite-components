using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Catalog connections configuration for the navigation module. Only used with Cross Site Publishing based solutions.
    /// </summary>
    public class NavigationCatalogConnectionInfos
    {
        private readonly PublishingCatalogInfos publishingCatalogInfos;
        private readonly PublishingManagedPropertyInfos publishingManagedPropertyInfos;
        private readonly NavigationManagedPropertyInfos navigationManagedPropertyInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingCatalogInfos">The catalogs configuration objects from the publishing module</param>
        /// <param name="publishingManagedPropertyInfos">The search managed properties configuration objects from the publishing module</param>
        /// <param name="navigationManagedPropertyInfos">The search managed properties configuration objects from the navigation module</param>
        public NavigationCatalogConnectionInfos(
            PublishingCatalogInfos publishingCatalogInfos, 
            PublishingManagedPropertyInfos publishingManagedPropertyInfos,
            NavigationManagedPropertyInfos navigationManagedPropertyInfos)
        {
            this.publishingCatalogInfos = publishingCatalogInfos;
            this.publishingManagedPropertyInfos = publishingManagedPropertyInfos;
            this.navigationManagedPropertyInfos = navigationManagedPropertyInfos;
        }

        /// <summary>
        /// Catalog connection for the news pages catalog
        /// </summary>
        /// <returns>The catalog connection info</returns>
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
                itemSlug);
        }

        /// <summary>
        /// Catalog connection for the content pages catalog
        /// </summary>
        /// <returns>The catalog connection info</returns>
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
                itemSlug);
        }
    }
}
