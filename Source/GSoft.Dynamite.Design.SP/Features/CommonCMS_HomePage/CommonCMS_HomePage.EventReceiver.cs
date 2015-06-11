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

                    FixHomePageNavigationFieldToBeNonRequiredEverywhere(web, homePage.PageLayout.AssociatedContentTypeId);

                    rootFolder.Pages.Add(homePage);
                    rootFolder.WelcomePage = homePage;
                    rootFolder.Locale = web.Locale; 

                    // Ensure the home page (this should be done on the variation source web)
                    folderHelper.EnsureFolderHierarchy(pagesLibrary, rootFolder);

                    // If we aren't on root web, assume this is a Variations-enabled scenario
                    var site = web.Site;
                    if (web.ID != web.Site.RootWeb.ID)
                    {
                        // Wait for variations to go through (so that the target home pages get created).
                        // Launch all the timer jobs because we still haven't figured out the magic sequence yet.
                        timerJobHelper.StartAndWaitForJob(site, "VariationsCreateHierarchies");
                        timerJobHelper.StartAndWaitForJob(site, "VariationsSpawnSites");
                        timerJobHelper.StartAndWaitForJob(site, "VariationsPropagatePage");
                        timerJobHelper.StartAndWaitForJob(site, "VariationsPropagateListItem");

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
        /// <param name="web">The current web</param>
        /// <param name="homePageContentTypeId">The home page CT id</param>
        private static void FixHomePageNavigationFieldToBeNonRequiredEverywhere(SPWeb web, SPContentTypeId homePageContentTypeId)
        {
            var siteCollection = web.Site;

            var rootContentTypes = siteCollection.RootWeb.ContentTypes;

            bool foundNavFieldInHomePageCT = false;

            foreach (SPContentType ct in rootContentTypes)
            {
                if (ct.Id == homePageContentTypeId || ct.Id.IsChildOf(homePageContentTypeId))
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
                        // Update all child content types across all lists as well to make sure
                        // the non-required Navigation field config gets propagated.
                        ct.Update(true);
                    }
                }
            }
        }
    }
}
