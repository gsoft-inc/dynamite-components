using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CommonCMS_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("4a54780e-a34c-4d70-bb97-2ff049a57ccd")]
    public class CommonCmsContentTypesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Creates content types for the multilingualism module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeHelper = featureScope.Resolve<IContentTypeHelper>();
                    var baseContentTypeConfig = featureScope.Resolve<IMultilingualismContentTypeInfoConfig>();
                    var baseContentTypes = baseContentTypeConfig.ContentTypes;
                    var logger = featureScope.Resolve<ILogger>();

                    // Create base content types
                    foreach (var contentType in baseContentTypes)
                    {
                        contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
                    }
                }
            }
        }
    }
}
