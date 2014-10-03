using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Helpers;
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
    public class CommonCMS_PageLayoutsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null && PublishingWeb.IsPublishingWeb(web))
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var folderHelper = featureScope.Resolve<FolderHelper>();

                    var baseFoldersConfig = featureScope.Resolve<IBasePublishingFolderInfoConfig>();
                    var rootFolderHierarchy = baseFoldersConfig.RootFolderHierarchy();

                    // Create folder hierarchy starting by the root folder
                    // NOTE: All pages are created through folders hierachy
                    var pagesLibrary = web.GetPagesLibrary();
                    folderHelper.EnsureFolderHierarchy(pagesLibrary, rootFolderHierarchy);                    
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            // TODO
        }
    }
}
