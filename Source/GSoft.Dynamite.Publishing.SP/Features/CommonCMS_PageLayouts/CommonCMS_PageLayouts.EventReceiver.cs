using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CommonCMS_PageLayouts
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("5c015b00-d06c-4362-84d1-b69a20f1d0f5")]
    public class CommonCMS_PageLayoutsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var pageHelper = featureScope.Resolve<IPageHelper>();
                    var pageLayoutInfos = featureScope.Resolve<IPublishingPageLayoutInfoConfig>().PageLayouts;

                    // Configures page layouts
                    foreach (var pageLayout in pageLayoutInfos)
                    {
                        logger.Info("Configuring page layout {0}", pageLayout.Name);
                        pageHelper.EnsurePageLayout(site, pageLayout);
                    }
                }
            }
        }
    }
}
