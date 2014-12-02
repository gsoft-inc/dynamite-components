using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.StandardPublishingCMS_PagesLibraryList
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
        /// <summary>
        /// Configures the pages library to allow open term creation in the navigation column. Only used with Standard Publishing CMS based solutions.
        /// </summary>
        /// <param name="properties">The event properties</param>
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

                    // Add only the pages library
                    var pageLibrary = listConfig.FirstOrDefault(p => p.WebRelativeUrl.ToString().Equals("Pages"));

                    if (pageLibrary != null)
                    {
                        listConfig.Clear();
                        listConfig.Add(pageLibrary);

                        // Create lists
                        foreach (var list in listConfig)
                        {
                            logger.Info("Configuring list {0} in web {1}", list.WebRelativeUrl, web.Url);
                            listHelper.EnsureList(web, list);
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
