using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using GSoft.Dynamite.UserProfile;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP.Features.CrossSitePublishingCMS_ProfileProps
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("2d1e793b-50e7-47ba-b801-465acb2d713a")]
    public class CrossSitePublishingCmsProfilePropsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Occurs after a Feature is activated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPFeatureReceiverProperties" /> object that represents the properties of the event.</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var scope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = scope.Resolve<ILogger>();

                    // Ensure profile properties
                    var userProfilePropertyHelper = scope.Resolve<IUserProfilePropertyHelper>();
                    var profileConfig = scope.Resolve<ITargetingProfileConfig>();
                    foreach (var userProfilePropertyInfo in profileConfig.UserProfileProperties)
                    {
                        logger.Info("Ensuring profile property '{0}'", userProfilePropertyInfo.Name);
                        userProfilePropertyHelper.EnsureProfileProperty(site, userProfilePropertyInfo);
                    }
                }
            }
        }
    }
}
