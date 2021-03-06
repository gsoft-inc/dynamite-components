using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CommonCMS_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("9448f2f7-011f-4104-a38e-492fba043a2f")]
    public class PublishingContentTypesEventReceiver : SPFeatureReceiver
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
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeHelper = featureScope.Resolve<IContentTypeHelper>();
                    var baseContentTypeConfig = featureScope.Resolve<IPublishingContentTypeInfoConfig>();
                    var baseContentTypes = baseContentTypeConfig.ContentTypes;
                    var logger = featureScope.Resolve<ILogger>();
                    var resourceLocator = featureScope.Resolve<IResourceLocator>();

                    // Create base content types
                    foreach (var contentType in baseContentTypes)
                    {
                        logger.Info("Creating content type {0} on site {1}", resourceLocator.Find(contentType.DisplayNameResourceKey), site.Url);
                        contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
                    }
                }
            }
        }
    }
}
