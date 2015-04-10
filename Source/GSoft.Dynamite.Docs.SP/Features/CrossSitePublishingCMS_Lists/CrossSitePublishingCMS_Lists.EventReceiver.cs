using System;
using System.Runtime.InteropServices;

using Autofac;
using Autofac.Core.Registration;

using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;

using Microsoft.SharePoint;

namespace GSoft.Dynamite.Docs.SP.Features.CrossSitePublishingCMS_Lists
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("be2bcad5-73fc-42dd-8950-4dc52a17c039")]
    public class CrossSitePublishingCMS_ListsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Ensure lists for the document management module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = DocsContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var listHelper = featureScope.Resolve<IListHelper>();
                    IDocsListInfoConfig baseListInfoConfig;

                    // Try to resolve the service based on the web's server-relative URL
                    // If no service has been resolved using the server-relative URL as a key, resolve using the default implementation
                    try
                    {
                        baseListInfoConfig = featureScope.ResolveKeyed<IDocsListInfoConfig>(new Uri(web.ServerRelativeUrl, UriKind.Relative));
                        logger.Info("Resolved the DocsListInfoConfig service based on the context given by the web URL");
                    }
                    catch (ComponentNotRegisteredException)
                    {
                        baseListInfoConfig = featureScope.Resolve<IDocsListInfoConfig>();
                        logger.Info("Couldn't resolve the DocsListInfoConfig service using the web URL as a key to get the context-specific implementation. Resolving the default service.");
                    }

                    var baseDocLibs = baseListInfoConfig.DocumentLibraries;

                    // Create the document libraries
                    foreach (var docLib in baseDocLibs)
                    {
                        logger.Info("Creating list {0} in web {1}", docLib.DisplayNameResourceKey, web.Url);
                        listHelper.EnsureList(web, docLib);
                    }
                }
            }
        }
    }
}
