using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.SP.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("d73aef21-e570-4694-b472-2aee3803347d")]
    public class CrossSitePublishingCMSEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var settings = featureScope.Resolve<IPublishingMetadataNavigationSettingsConfig>().MetadataNavigationSettings;
                    var metadataNavigationInfos = featureScope.Resolve<PublishingMetadataNavigationSettingsInfos>();
                    var logger = featureScope.Resolve<ILogger>();

                    settings.Clear();
                    settings.Add(metadataNavigationInfos.ContentPagesNavigation);
                    settings.Add(metadataNavigationInfos.NewsPagesNavigation);

                    foreach (var setting in settings)
                    {
                        logger.Info("Configuring metadata navigation on list {0} in web {1}", setting.List.WebRelativeUrl, web.Url);
                        listHelper.SetMetadataNavigation(web, setting);
                    }
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var settings = featureScope.Resolve<IPublishingMetadataNavigationSettingsConfig>().MetadataNavigationSettings;
                    var metadataNavigationInfos = featureScope.Resolve<PublishingMetadataNavigationSettingsInfos>();
                    var logger = featureScope.Resolve<ILogger>();

                    settings.Clear();
                    // Create new objects with basic settings
                    settings.Add(new MetadataNavigationSettingsInfo(metadataNavigationInfos.ContentPagesNavigation.List, true, false, false));
                    settings.Add(new MetadataNavigationSettingsInfo(metadataNavigationInfos.NewsPagesNavigation.List, true, false, false));

                    foreach (var setting in settings)
                    {
                        // Reset the configuration
                        logger.Info("Reset metadata navigation on list {0} in web {1}", setting.List.WebRelativeUrl, web.Url);
                        listHelper.SetMetadataNavigation(web, setting);
                    }
                }
            }
        }
    }
}
