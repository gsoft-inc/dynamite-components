using System;
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

namespace GSoft.Dynamite.Design.SP.Features.CommonCMS_HomePages
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("55e3a044-1cbc-4128-b254-4bd582571215")]
    public class CommonCmsHomePagesEventReceiver : SPFeatureReceiver
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
                    var baseFoldersConfig = featureScope.Resolve<IDesignFolderInfoConfig>();

                    // Get only the home pages configuration
                    var folders = baseFoldersConfig.RootFolderHierarchies.ToList();

                    // Resolve feature dependency activator
                    // Note: Need to pass the site and web objects to support site and web scoped features.
                    var featureDependencyActivator =
                        featureScope.Resolve<IFeatureDependencyActivator>(
                            new TypedParameter(typeof(SPSite), web.Site),
                            new TypedParameter(typeof(SPWeb), web));

                    // Activate feature dependencies defined in this configuration
                    featureDependencyActivator.EnsureFeatureActivation(baseFoldersConfig as IFeatureDependencyConfig);

                    foreach (var rootFolderHierarchy in folders)
                    {
                        var pagesLibrary = web.GetPagesLibrary();

                        if (rootFolderHierarchy.Locale != null)
                        {
                            if (web.Locale.TwoLetterISOLanguageName == rootFolderHierarchy.Locale.TwoLetterISOLanguageName)
                            {
                                // Create folder hierarchy starting by the root folder
                                // NOTE: All pages are created through folders hierachy
                                folderHelper.EnsureFolderHierarchy(pagesLibrary, rootFolderHierarchy);
                            }
                            else
                            {
                                logger.Info("The root folder {0} does not apply on this web according to its locale {1}", rootFolderHierarchy.Name, rootFolderHierarchy.Locale.TwoLetterISOLanguageName);
                            }
                        }
                        else
                        {
                            folderHelper.EnsureFolderHierarchy(pagesLibrary, rootFolderHierarchy);
                        }
                    }
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
