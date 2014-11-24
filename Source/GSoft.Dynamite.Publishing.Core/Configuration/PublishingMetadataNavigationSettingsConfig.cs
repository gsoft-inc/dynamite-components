using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingMetadataNavigationSettingsConfig : IPublishingMetadataNavigationSettingsConfig
    {
        private readonly PublishingMetadataNavigationSettingsInfos publishingMetadataNavigationSettingsInfos;

        public PublishingMetadataNavigationSettingsConfig(
            PublishingMetadataNavigationSettingsInfos publishingMetadataNavigationSettingsInfos)
        {
            this.publishingMetadataNavigationSettingsInfos = publishingMetadataNavigationSettingsInfos;
        }


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
