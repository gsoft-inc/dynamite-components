using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Metadata navigation setting definitions for the publishing module
    /// </summary>
    public class PublishingMetadataNavigationSettingsInfos
    {
        private readonly PublishingFieldInfos publishingFieldInfos;
        private readonly PublishingCatalogInfos publishingCatalogInfos;
        private readonly PublishingListInfos publishingListInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingFieldInfos">The field info objects configuration</param>
        /// <param name="publishingCatalogInfos">The catalog info objects configuration</param>
        /// <param name="publishingListInfos">The list info objects configuration</param>
        public PublishingMetadataNavigationSettingsInfos(
            PublishingFieldInfos publishingFieldInfos,
            PublishingCatalogInfos publishingCatalogInfos,
            PublishingListInfos publishingListInfos)
        {
            this.publishingFieldInfos = publishingFieldInfos;
            this.publishingCatalogInfos = publishingCatalogInfos;
            this.publishingListInfos = publishingListInfos;
        }

        /// <summary>
        /// Metadata navigation settings for the content pages catalog
        /// </summary>
        public MetadataNavigationSettingsInfo ContentPagesNavigation
        {
            get
            {
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfos.Navigation().InternalName,
                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(this.publishingCatalogInfos.ContentPages(), false, false, false, hierarchies, filters);
            }
        }

        /// <summary>
        /// Metadata navigation settings for the news pages catalog
        /// </summary>
        public MetadataNavigationSettingsInfo NewsPagesNavigation
        {
            get
            {
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfos.Navigation().InternalName,
                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(this.publishingCatalogInfos.NewsPages(), false, false, false, hierarchies, filters);
            }
        }

        /// <summary>
        /// Metadata navigation settings for the OOTB pages library
        /// </summary>
        public MetadataNavigationSettingsInfo PagesLibraryNavigation
        {
            get
            {
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfos.Navigation().InternalName,
                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(this.publishingListInfos.PagesLibrary, false, false, false, hierarchies, filters);
            }
        }
    }
}
