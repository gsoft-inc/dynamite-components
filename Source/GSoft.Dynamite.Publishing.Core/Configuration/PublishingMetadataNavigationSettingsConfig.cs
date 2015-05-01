using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the metadata navigation settings (Tree View panel based on list or library fields)
    /// </summary>
    public class PublishingMetadataNavigationSettingsConfig : IPublishingMetadataNavigationSettingsConfig
    {
        private readonly IPublishingFieldInfoConfig publishingFieldInfoConfig;
        private readonly IPublishingCatalogInfoConfig publishingCatalogInfoConfig;
        private readonly IPublishingListInfoConfig publishingListInfoConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishingMetadataNavigationSettingsConfig"/> class.
        /// </summary>
        /// <param name="publishingFieldInfoConfig">The publishing field information configuration.</param>
        /// <param name="publishingCatalogInfoConfig">The publishing catalog information configuration.</param>
        /// <param name="publishingListInfoConfig">The publishing list information configuration.</param>
        public PublishingMetadataNavigationSettingsConfig(
            IPublishingFieldInfoConfig publishingFieldInfoConfig,
            IPublishingCatalogInfoConfig publishingCatalogInfoConfig,
            IPublishingListInfoConfig publishingListInfoConfig)
        {
            this.publishingFieldInfoConfig = publishingFieldInfoConfig;
            this.publishingCatalogInfoConfig = publishingCatalogInfoConfig;
            this.publishingListInfoConfig = publishingListInfoConfig;
        }

        /// <summary>
        /// Property that return all the metadata types navigation settings to create in the publishing module
        /// </summary>
        public IList<MetadataNavigationSettingsInfo> MetadataNavigationSettings
        {
            get
            {
                // Configurations are set into features depending the solution type
                var settings = new List<MetadataNavigationSettingsInfo>()
                {
                    this.ContentPagesNavigation,
                    this.NewsPagesNavigation,
                    this.PagesLibraryNavigation
                };

                return settings;
            }
        }

        private MetadataNavigationSettingsInfo ContentPagesNavigation
        {
            get
            {
                var listInfo = this.publishingCatalogInfoConfig.GetCatalogInfoByWebRelativeUrl(PublishingCatalogInfos.ContentPages.WebRelativeUrl);
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id).InternalName,
                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(listInfo, false, false, false, hierarchies, filters);
            }
        }

        private MetadataNavigationSettingsInfo NewsPagesNavigation
        {
            get
            {
                var listInfo = this.publishingCatalogInfoConfig.GetCatalogInfoByWebRelativeUrl(PublishingCatalogInfos.NewsPages.WebRelativeUrl);
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id).InternalName,
                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(listInfo, false, false, false, hierarchies, filters);
            }
        }

        private MetadataNavigationSettingsInfo PagesLibraryNavigation
        {
            get
            {
                var listInfo = this.publishingListInfoConfig.GetListInfoByWebRelativeUrl(PublishingListInfos.PagesLibrary.WebRelativeUrl);
                var hierarchies = new List<string>()
                {
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id).InternalName,
                };

                var filters = new List<string>();

                return new MetadataNavigationSettingsInfo(listInfo, false, false, false, hierarchies, filters);
            }
        }

        /// <summary>
        /// Gets the metadata navigation settings information by list information from this configuration.
        /// </summary>
        /// <param name="list">The list information.</param>
        /// <returns>
        /// The Managed navigation settings
        /// </returns>
        public MetadataNavigationSettingsInfo GetMetadataNavigationSettingsInfoByListInfo(ListInfo list)
        {
            return this.MetadataNavigationSettings.Single(s => s.List.Equals(list));
        }
    }
}
