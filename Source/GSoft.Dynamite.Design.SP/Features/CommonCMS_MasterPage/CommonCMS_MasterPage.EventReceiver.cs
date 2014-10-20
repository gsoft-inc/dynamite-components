using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.MasterPages;
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

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = DesignContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var masterPageHelper = featureScope.Resolve<MasterPageHelper>();

                    // Generate masterpage file from HTML design file
                    var htmlFilename = "Chad.WebSite.html";
                    masterPageHelper.GenerateMasterPage(site, htmlFilename);

                    // Set the masterpage on the site
                    var masterPageFilename = "Chad.WebSite.master";
                    masterPageHelper.ApplyRootMasterPage(site, null, masterPageFilename);
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
        }
    }
}
