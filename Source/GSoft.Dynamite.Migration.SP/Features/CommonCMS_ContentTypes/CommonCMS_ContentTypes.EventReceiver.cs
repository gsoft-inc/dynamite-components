using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Migration.SP.Features.CommonCMS_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("2c752030-db72-4040-a4f8-f9d8a87f924d")]
    public class CommonCMS_ContentTypesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Ensures content types for the document management module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MigrationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeHelper = featureScope.Resolve<IContentTypeHelper>();
                    var baseContentTypeConfig = featureScope.Resolve<IMigrationContentTypeInfoConfig>();
                    var baseContentTypes = baseContentTypeConfig.ContentTypes;
                    var logger = featureScope.Resolve<ILogger>();

                    foreach (var contentType in baseContentTypes)
                    {
                        logger.Info("Creating content type {0} in site {1}", contentType.ContentTypeId, site.Url);
                        contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
                    }
                }
            }
        }
    }
}
