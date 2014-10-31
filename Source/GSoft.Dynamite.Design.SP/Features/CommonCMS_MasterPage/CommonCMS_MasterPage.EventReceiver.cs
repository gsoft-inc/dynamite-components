using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Design.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Design.SP.Features.CommonCMS_MasterPage
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("1540be21-f687-494c-af80-1b8851bc5718")]
    public class CommonCMS_MasterPageEventReceiver : SPFeatureReceiver
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
                    var masterPageHelper = featureScope.Resolve<IMasterPageHelper>();
                    var designConfig = featureScope.Resolve<IDesignConfig>();

                    // Generate masterpage file from HTML design file
                    masterPageHelper.GenerateMasterPage(site, designConfig.MasterPageHTMLFilename);

                    // Set the masterpage on the site
                    masterPageHelper.ApplyRootMasterPage(site, null, designConfig.MasterPageMASTERFilename);
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
                using (var featureScope = DesignContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var masterPageHelper = featureScope.Resolve<IMasterPageHelper>();
                    masterPageHelper.RevertToSeattle(site);
                }
            }
        }
    }
}
