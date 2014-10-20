using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("40703643-5222-448d-afb1-28894ee59aa5")]
    public class CrossSitePublishingCMS_ContentTypesEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeHelper = featureScope.Resolve<ContentTypeHelper>();
                    var baseContentTypeConfig  = featureScope.Resolve<IBaseNavigationContentTypeInfoConfig>();
                    var baseContentTypes = baseContentTypeConfig.ContentTypes;
                    var logger = featureScope.Resolve<ILogger>();

                    // Create base content types
                    foreach (var contentType in baseContentTypes)
                    {
                        contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
                    }

                    // Create additionnal custom content types
                    /*   ICustomPublishingContentTypeInfoConfig customContentTypeConfig = null;
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
                       }*/
                }
            }
        }
    }
}
