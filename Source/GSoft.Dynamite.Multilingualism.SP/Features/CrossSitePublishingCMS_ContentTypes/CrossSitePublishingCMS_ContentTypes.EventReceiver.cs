using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CrossSitePublishingCMS_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("4a54780e-a34c-4d70-bb97-2ff049a57ccd")]
    public class CrossSitePublishingCMS_ContentTypesEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeHelper = featureScope.Resolve<ContentTypeHelper>();
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


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
