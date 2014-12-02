using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_MetadataNavigation
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
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var settings = featureScope.Resolve<IPublishingMetadataNavigationSettingsConfig>().MetadataNavigationSettings;
                    var logger = featureScope.Resolve<ILogger>();

                    // Remove the page library list setting
                    var pageLibrary = settings.FirstOrDefault(p => p.List.WebRelativeUrl.ToString().Equals("Pages"));
                    if (pageLibrary != null)
                    {
                        settings.Remove(pageLibrary);
                    }

                    foreach (var setting in settings)
                    {
                        logger.Info("Configuring metadata navigation on list {0} in web {1}", setting.List.WebRelativeUrl, web.Url);
                        listHelper.SetMetadataNavigation(web, setting);
                    }
                }
            }
        }

        /// <summary>
        /// Feature deactivating event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var settings = featureScope.Resolve<IPublishingMetadataNavigationSettingsConfig>().MetadataNavigationSettings;
                    var logger = featureScope.Resolve<ILogger>();

                    // Remove the page library list setting
                    var pageLibrary = settings.FirstOrDefault(p => p.List.WebRelativeUrl.ToString().Equals("Pages"));
                    if (pageLibrary != null)
                    {
                        settings.Remove(pageLibrary);
                    }

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
