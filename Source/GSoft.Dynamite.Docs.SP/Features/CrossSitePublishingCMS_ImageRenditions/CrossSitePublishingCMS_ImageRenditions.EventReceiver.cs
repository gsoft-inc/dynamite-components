using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Features;
using GSoft.Dynamite.Logging;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Docs.SP.Features.CrossSitePublishingCMS_ImageRenditions
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("6e03c332-1c57-420f-80b1-7868191f1364")]
    public class CrossSitePublishingCMS_ImageRenditionsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Ensure Image Renditions for the document management module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = DocsContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var imageRenditionHelper = featureScope.Resolve<IImageRenditionHelper>();
                    var imageRenditionInfoConfig = featureScope.Resolve<IDocsImageRenditionInfoConfig>();
                    var imageRenditions = imageRenditionInfoConfig.ImageRenditions;
                    var logger = featureScope.Resolve<ILogger>();

                    // Resolve feature dependency activator
                    // Note: Need to pass the site and web objects to support site and web scoped features.
                    var featureDependencyActivator =
                        featureScope.Resolve<IFeatureDependencyActivator>(
                            new TypedParameter(typeof(SPSite), site),
                            new TypedParameter(typeof(SPWeb), site.RootWeb));

                    // Activate feature dependencies defined in this configuration
                    featureDependencyActivator.EnsureFeatureActivation(imageRenditionInfoConfig as IFeatureDependencyConfig);

                    // Create base image renditions
                    foreach (var imageRendition in imageRenditions)
                    {
                        logger.Info("Creating field {0} in site {1}", imageRendition.Name, site.Url);

                        // Removes all the default image renditions configuration
                        imageRenditionHelper.RemoveImageRendition(site, "Display Template");

                        // Adds Image Renditions configuration
                        imageRenditionHelper.EnsureImageRendition(site, imageRendition);
                    }
                }
            }
        }
    }
}
