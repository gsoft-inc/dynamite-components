using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_ContentPagesList
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("ea4f2aab-19d4-4cc6-9a8c-9c38a31bb236")]
    public class CrossSitePublishingCMS_ContentPagesListEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Configures only the content pages catalog to allow the open term creation in the navigation column
        /// </summary>
        /// <param name="properties">Context properties</param>
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

                    // Add only the target content pages list
                    var contentPages = listConfig.FirstOrDefault(p => p.WebRelativeUrl.ToString().Equals("Pages"));

                    if (contentPages != null)
                    {
                        listConfig.Clear();
                        listConfig.Add(contentPages);

                        // Create lists
                        foreach (var list in listConfig)
                        {
                            logger.Info("Configuring list {0} in web {1}", list.WebRelativeUrl, web.Url);
                            listHelper.EnsureList(web, list);
                        }
                    }
                    else
                    {
                        logger.Info("No content pages list information found in the configuration. Please add the content pages list configuration to use this feature");
                    }
                }
            }
        }
    }
}
