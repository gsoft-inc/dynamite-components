using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_Lists
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("73545a7e-36d3-4b36-98b0-fcd15ea5b445")]
    public class CrossSitePublishingCMS_ListsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var baseListInfos = featureScope.Resolve<IPublishingListInfoConfig>().Lists;

                    var logger = featureScope.Resolve<ILogger>();

                    // Create lists
                    foreach (var list in baseListInfos)
                    {
                        logger.Info("Creating list {0} in web {1}", list.RootFolderUrl, web.Url);
                        listHelper.EnsureList(web, list);
                    }
                }
            }
        }
    }
}
