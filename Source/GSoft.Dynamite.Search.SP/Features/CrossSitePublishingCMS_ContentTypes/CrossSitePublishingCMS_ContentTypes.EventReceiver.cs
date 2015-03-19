using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Search.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Search.SP.Features.CrossSitePublishingCMS_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("a770c59f-2f95-44b7-8aba-cdc56db528b9")]
    public class CrossSitePublishingCMS_ContentTypesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = SearchContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeHelper = featureScope.Resolve<IContentTypeHelper>();
                    var baseContentTypeConfig = featureScope.Resolve<ISearchContentTypeInfoConfig>();
                    var baseContentTypes = baseContentTypeConfig.ContentTypes;
                    var logger = featureScope.Resolve<ILogger>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();

                    // Create base content types
                    foreach (var contentType in baseContentTypes)
                    {
                        logger.Info("Ensuring content type {0} on site {1}", resourceLocator.Find(contentType.DisplayNameResourceKey), site.Url);
                        contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
                    }
                }
            }
        }
    }
}
