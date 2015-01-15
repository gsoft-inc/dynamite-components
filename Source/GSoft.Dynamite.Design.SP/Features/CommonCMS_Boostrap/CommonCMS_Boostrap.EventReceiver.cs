using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Design.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Design.SP.Features.Boostrap_MasterPage
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("5a827e3f-c8e0-4b70-879a-0e6408efbb99")]
    public class Boostrap_MasterPageEventReceiver : SPFeatureReceiver
    {
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
        /// Event that is triggered when the feature is deactivated
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = DesignContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    // Revert to SP 2013 out of the box masterpage (seattle)
                    var masterPageHelper = featureScope.Resolve<IMasterPageHelper>();
                    masterPageHelper.RevertToSeattle(site);
                }
            }
        }
    }
}
