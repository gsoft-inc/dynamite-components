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
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.TimerJobs;
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
                    var timerJobHelper = featureScope.Resolve<ITimerJobHelper>();

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

                    // Make sure the HomePage CT on the Pages library doesn't have a required Navigation field
                    FixHomePageNavigationFieldToBeNonRequired(pagesLibrary, homePage.PageLayout.AssociatedContentTypeId);

                    // Ensure the home page (this should be done on the variation source web)
                    folderHelper.EnsureFolderHierarchy(pagesLibrary, rootFolder);

                    // If we aren't on root web, assume this is a Variations-enabled scenario
                    var site = web.Site;
                    if (web.ID != web.Site.RootWeb.ID)
                    {
                        // Wait for variations to go through (so that the target home pages get created).
                        timerJobHelper.StartAndWaitForJob(site, BuiltInVariationsTimerJobs.VariationsSpawnSites);        // required for new pages to get created
                        timerJobHelper.StartAndWaitForJob(site, BuiltInVariationsTimerJobs.VariationsPropagatePage);     // required for page updates to get variated

                        // Update the target webs' home page URL
                        foreach (SPWeb firstLevelSubWeb in web.Site.RootWeb.Webs)
                        {
                            if (firstLevelSubWeb.ID != web.ID)
                            {
                                var targetWebRootFolder = firstLevelSubWeb.RootFolder;
                                targetWebRootFolder.WelcomePage = homePage.LibraryRelativePageUrl.ToString();    // home page will have same lib-relative URL once variated
                                targetWebRootFolder.Update();

                                // Ensure the content on the newly variated target home pages
                                var targetRootFolder = new FolderInfo();
                                var targetHomePage = homePageConfig.GetHomePageInfoByCulture(firstLevelSubWeb.Locale);

                                targetHomePage.FileName = homePage.FileName;    // make sure that we use the same file name across all variated pairs (the source's filename)

                                targetRootFolder.Pages.Add(targetHomePage);
                                targetRootFolder.WelcomePage = targetHomePage;
                                targetRootFolder.Locale = firstLevelSubWeb.Locale;

                                // Make sure the HomePage CT on the Pages library doesn't have a required Navigation field
                                FixHomePageNavigationFieldToBeNonRequired(pagesLibrary, homePage.PageLayout.AssociatedContentTypeId);

                                // Ensure the home page info on the target web
                                folderHelper.EnsureFolderHierarchy(firstLevelSubWeb.GetPagesLibrary(), targetRootFolder);
                            }
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

        /// <summary>
        /// It makes no sense for the home page to have a required Navigation field
        /// (since it lives as the WelcomePage of its site).
        /// </summary>
        /// <param name="list">The list in which we may need to update the HomePage content type</param>
        /// <param name="homePageContentTypeId">The site content type identifier for the home page content type</param>
        private static void FixHomePageNavigationFieldToBeNonRequired(SPList list, SPContentTypeId homePageContentTypeId)
        {
            var listContentTypes = list.ContentTypes;

            bool foundNavFieldInHomePageCT = false;

            foreach (SPContentType ct in listContentTypes)
            {
                if (ct.Id == homePageContentTypeId || ct.Parent.Id == homePageContentTypeId)
                {
                    foreach (SPFieldLink f in ct.FieldLinks)
                    {
                        if (f.Id == PublishingFieldInfos.Navigation.Id)
                        {
                            f.Required = false;
                            foundNavFieldInHomePageCT = true;
                        }
                    }

                    if (foundNavFieldInHomePageCT)
                    {
                        // Update the list CT only
                        ct.Update();
                    }
                }
            }
        }
    }
}
