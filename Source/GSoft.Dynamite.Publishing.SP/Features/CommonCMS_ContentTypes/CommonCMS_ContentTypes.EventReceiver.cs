using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.Item_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("9448f2f7-011f-4104-a38e-492fba043a2f")]
    public class Publishing_ContentTypesEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeHelper = featureScope.Resolve<ContentTypeHelper>();
                    var baseContentTypeConfig = featureScope.Resolve<IBasePublishingContentTypeInfoConfig>();
                    var baseContentTypes = baseContentTypeConfig.ContentTypes;
                    var logger = featureScope.Resolve<ILogger>();

                    // Create base content types
                    foreach (var contentType in baseContentTypes)
                    {   
                        contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
                    }

                    // Create additionnal custom content types
                    ICustomPublishingContentTypeInfoConfig customContentTypeConfig = null;
                    if (featureScope.TryResolve(out customContentTypeConfig))
                    {
                        var customContentTypes = customContentTypeConfig.ContentTypes;
                        
                        foreach (var contentType in customContentTypes)
                        {
                            contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
                        }
                    }
                    else
                    {
                        logger.Info("No custom content types override found!");
                    }
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {   
            // TODO: To implement
        }
    }
}
