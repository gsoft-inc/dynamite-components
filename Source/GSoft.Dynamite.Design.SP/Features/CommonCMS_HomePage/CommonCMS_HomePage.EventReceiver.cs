using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Features;
using GSoft.Dynamite.Folders;
using GSoft.Dynamite.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Design.SP.Features.CommonCMS_HomePage
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("55e3a044-1cbc-4128-b254-4bd582571215")]
    public class CommonCmsHomePageEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            using (var featureScope = DesignContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var logger = featureScope.Resolve<ILogger>();

                if (web != null && PublishingWeb.IsPublishingWeb(web))
                {
                    var folderHelper = featureScope.Resolve<IFolderHelper>();
                    var homePageConfig = featureScope.Resolve<IHomePageConfig>();

                    // Resolve feature dependency activator
                    // Note: Need to pass the site and web objects to support site and web scoped features.
                    var featureDependencyActivator =
                        featureScope.Resolve<IFeatureDependencyActivator>(
                            new TypedParameter(typeof(SPSite), web.Site),
                            new TypedParameter(typeof(SPWeb), web));

                    // Activate feature dependencies defined in this configuration
                    featureDependencyActivator.EnsureFeatureActivation(homePageConfig as IFeatureDependencyConfig);

                    var pagesLibrary = web.GetPagesLibrary();

                    // Put home page in dummy folder
                    var rootFolder = new FolderInfo();
                    var homePage = homePageConfig.GetHomePageInfoByCulture(web.Locale);

                    rootFolder.Pages.Add(homePage);
                    rootFolder.WelcomePage = homePage;
                    rootFolder.Locale = web.Locale; 

                    // Ensure
                    folderHelper.EnsureFolderHierarchy(pagesLibrary, rootFolder);
                }
                else
                {
                    logger.Warn("The web {0} is not a Publishing Web. This feature can only be activated on a SharePoint Publishing Web", web.Url);
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

            using (var featureScope = DesignContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                if (web != null && PublishingWeb.IsPublishingWeb(web))
                {
                    var folderHelper = featureScope.Resolve<IFolderHelper>();

                    folderHelper.ResetWelcomePageToDefault(web);
                }
            }
        }
    }
}
