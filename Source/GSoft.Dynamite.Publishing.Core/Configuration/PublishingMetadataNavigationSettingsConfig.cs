using System.Collections.Generic;
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
        private readonly PublishingMetadataNavigationSettingsInfos publishingMetadataNavigationSettingsInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingMetadataNavigationSettingsInfos">The metadata navigation settings info configuration objects</param>
        public PublishingMetadataNavigationSettingsConfig(
            PublishingMetadataNavigationSettingsInfos publishingMetadataNavigationSettingsInfos)
        {
            this.publishingMetadataNavigationSettingsInfos = publishingMetadataNavigationSettingsInfos;
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
                    this.publishingMetadataNavigationSettingsInfos.ContentPagesNavigation,
                    this.publishingMetadataNavigationSettingsInfos.NewsPagesNavigation,
                    this.publishingMetadataNavigationSettingsInfos.PagesLibraryNavigation
                };

                return settings;
            }
        }
    }
}
