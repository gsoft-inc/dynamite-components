using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Features;
using GSoft.Dynamite.Security;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Design.SP.Features.CommonCMS_Theme
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("a0c45050-1e06-492b-a48f-17dfe3920583")]
    public class CommonCMS_ThemeEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event Receiver for Feature Activated
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = DesignContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var designConfig = featureScope.Resolve<IDesignConfig>();

                    // Resolve feature dependency activator
                    // Note: Need to pass the site and web objects to support site and web scoped features.
                    var featureDependencyActivator =
                        featureScope.Resolve<IFeatureDependencyActivator>(
                            new TypedParameter(typeof(SPSite), site),
                            new TypedParameter(typeof(SPWeb), site.RootWeb));

                    // Activate feature dependencies defined in this configuration
                    featureDependencyActivator.EnsureFeatureActivation(designConfig as IFeatureDependencyConfig);

                    // Set the Site Logo and theme
                    foreach (SPWeb web in site.AllWebs)
                    {
                        using (new Unsafe(web))
                        {
                            // Set Logo
                            web.SiteLogoUrl = SPUtility.ConcatUrls(site.ServerRelativeUrl, designConfig.LogoUrl);
                            web.SiteLogoDescription = designConfig.LogoUrlDescription;
                            web.Update();

                            // Set theme
                            web.ApplyTheme(
                                SPUtility.ConcatUrls(site.ServerRelativeUrl, designConfig.SPColorUrl),
                                SPUtility.ConcatUrls(site.ServerRelativeUrl, designConfig.SPFontUrl), 
                                null, 
                                true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when table Feature is deactivated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPFeatureReceiverProperties" /> object that represents the properties of the event.</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                // TODO
            }
        }
    }
}
