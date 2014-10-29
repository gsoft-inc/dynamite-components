using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using FolderInfo = GSoft.Dynamite.Definitions.FolderInfo;

namespace GSoft.Dynamite.Publishing.SP.Features.CommonCMS_PageLayouts
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("19227a43-dcb0-4a6d-b91a-f1963f819050")]
    public class CommonCmsPageLayoutsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var logger = featureScope.Resolve<ILogger>();

                if (web != null && PublishingWeb.IsPublishingWeb(web))
                {

                    var folderHelper = featureScope.Resolve<IFolderHelper>();

                    var baseFoldersConfig = featureScope.Resolve<IPublishingFolderInfoConfig>();

                    foreach (var rootFolderHierarchy in baseFoldersConfig.RootFolderHierarchies())
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

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var logger = featureScope.Resolve<ILogger>();

                if (web != null && PublishingWeb.IsPublishingWeb(web))
                {
                    var folderHelper = featureScope.Resolve<IFolderHelper>();
                    var baseFoldersConfig = featureScope.Resolve<IPublishingFolderInfoConfig>();

                    folderHelper.ResetHomePageToDefault(web);
                }
            }
            // Reset HomePage
        }
    }
}
