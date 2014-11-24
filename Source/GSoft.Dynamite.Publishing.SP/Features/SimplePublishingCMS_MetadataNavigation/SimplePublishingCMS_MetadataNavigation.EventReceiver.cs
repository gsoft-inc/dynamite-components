using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.SimplePublishingCNS_MetadataNavigation
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("57cc183d-36cf-4514-8fb3-0ea0f7e92dc7")]
    public class SimplePublishingCMS_MetadataNavigationEventReceiver : SPFeatureReceiver
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
                    var logger = featureScope.Resolve<ILogger>();

                    // Select only the page library list setting
                    var pageLibrary =  settings.FirstOrDefault(p => p.List.WebRelativeUrl.ToString().Equals("Pages"));

                    if (pageLibrary != null)
                    {
                        settings.Clear();
                        settings.Add(pageLibrary);

                        foreach (var setting in settings)
                        {
                            logger.Info("Configuring metadata navigation on list {0} in web {1}", setting.List.WebRelativeUrl, web.Url);
                            listHelper.SetMetadataNavigation(web, setting);
                        }
                    }
                    else
                    {
                        logger.Info("No pages library information found in the configuration. Please add the pages library configuration to use this feature");
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
                    var logger = featureScope.Resolve<ILogger>();

                    // Select only the page library list setting
                    var pageLibrary =  settings.FirstOrDefault(p => p.List.WebRelativeUrl.ToString().Equals("Pages"));

                    if (pageLibrary != null)
                    {
                        settings.Clear();
                        settings.Add(pageLibrary);

                        foreach (var setting in settings)
                        {
                            // Reset the configuration
                            logger.Info("Reset metadata navigation on list {0} in web {1}", setting.List.WebRelativeUrl, web.Url);
                            listHelper.SetMetadataNavigation(web, setting);
                        }
                    }
                    else
                    {
                        logger.Info("No pages library information found in the configuration. Please add the pages library configuration to use this feature");
                    }  
                }
            }
        }
    }
}
