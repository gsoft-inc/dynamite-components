using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingMetadataNavigationSettingsInfos
    {
        private readonly PublishingFieldInfos publishingFieldInfos;
        private readonly PublishingCatalogInfos publishingCatalogInfos;
        private readonly PublishingListInfos publishingListInfos;

        public PublishingMetadataNavigationSettingsInfos(PublishingFieldInfos publishingFieldInfos, PublishingCatalogInfos publishingCatalogInfos, PublishingListInfos publishingListInfos)
        {
            this.publishingFieldInfos = publishingFieldInfos;
            this.publishingCatalogInfos = publishingCatalogInfos;
            this.publishingListInfos = publishingListInfos;
        }

        public MetadataNavigationSettingsInfo ContentPagesNavigation
        {
            get
            {
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfos.Navigation().InternalName,

                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(publishingCatalogInfos.ContentPages(), false, false, false, hierarchies, filters);
            }
        }

        public MetadataNavigationSettingsInfo NewsPagesNavigation
        {
            get
            {
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfos.Navigation().InternalName,

                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(publishingCatalogInfos.NewsPages(), false, false, false, hierarchies, filters);
            }
        }

        public MetadataNavigationSettingsInfo PagesLibraryNavigation
        {
            get
            {
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfos.Navigation().InternalName,

                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(publishingListInfos.PagesLibrary, false, false, false, hierarchies, filters);
            }
        }
    }
}
