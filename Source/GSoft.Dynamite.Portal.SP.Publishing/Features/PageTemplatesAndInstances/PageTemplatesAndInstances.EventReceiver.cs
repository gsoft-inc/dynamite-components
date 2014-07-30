using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using GSoft.Dynamite.Portal.Contracts.Factories;
using Microsoft.SharePoint.Publishing;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Contracts.Constants;
using System.Globalization;

namespace GSoft.Dynamite.Portal.SP.Publishing.Features.PageTemplates
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("88530a02-c5be-4a3a-89f4-3d4208c374e0")]
    public class PageTemplatesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event receiver for Feature Activation event
        /// </summary>
        /// <param name="properties">Event arguments</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null && PublishingSite.IsPublishingSite(web.Site) && PublishingWeb.IsPublishingWeb(web))
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var pageFactory = featureScope.Resolve<IPortalPageFactory>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();

                    // Create Home Page
                    var homePageFileName = resourceLocator.Find(PortalResources.PageInstanceHomeFileName, (int)web.Language);
                    var homePage = pageFactory.CreateHomePageInstance(web, homePageFileName);
                    var allNewsPage = pageFactory.CreateAllNewsPageInstance(web, resourceLocator.Find(PortalResources.PageInstanceAllNewsFileName, (int)web.Language));
                    var contentPage = pageFactory.CreateStaticContentPageTemplate(web, resourceLocator.Find(PortalResources.PageTemplateStaticContentFileName, (int)web.Language));
                    var newsPage = pageFactory.CreateNewsPageTemplate(web, resourceLocator.Find(PortalResources.PageTemplateNewsFileName, (int)web.Language));
                    var nodePage = pageFactory.CreateNodeDescriptionPageTemplate(web, resourceLocator.Find(PortalResources.PageTemplateNodeDescriptionFileName, (int)web.Language));
                    var searchResultsPage = pageFactory.CreateSearchResultsPageInstance(web, resourceLocator.Find(PortalResources.PageInstanceSearchFileName, (int)web.Language));

                    // Set as Home Page
                    var rootFolder = web.RootFolder;
                    rootFolder.WelcomePage = string.Format(CultureInfo.InvariantCulture, "Pages/{0}.aspx", homePageFileName);
                    rootFolder.Update();
                }
            }
        }

        /// <summary>
        /// Event receiver for feature deactivating event
        /// </summary>
        /// <param name="properties">Event arguments</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                var rootFolder = web.RootFolder;
                rootFolder.WelcomePage = "Pages/default.aspx";
                rootFolder.Update();
            }
        }
    }
}
