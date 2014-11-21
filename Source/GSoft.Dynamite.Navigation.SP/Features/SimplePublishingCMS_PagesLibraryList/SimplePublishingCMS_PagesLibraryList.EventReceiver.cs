using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_PagesLibraryList
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("be776369-6764-4959-8980-2224c8fbe8a4")]
    public class SimpleCMS_PagesLibraryListEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var listConfig = featureScope.Resolve<INavigationListInfosConfig>().Lists;
                    var logger = featureScope.Resolve<ILogger>();

                    var navigationListInfos = featureScope.Resolve<NavigationListInfos>();

                    // Add only the pages library
                    listConfig.Clear();
                    listConfig.Add(navigationListInfos.PagesLibrary);

                    // Create lists
                    foreach (var list in listConfig)
                    {
                        logger.Info("Configuring list {0} in web {1}", list.WebRelativeUrl, web.Url);
                        listHelper.EnsureList(web, list);
                    }
                }
            }
        }
    }
}
