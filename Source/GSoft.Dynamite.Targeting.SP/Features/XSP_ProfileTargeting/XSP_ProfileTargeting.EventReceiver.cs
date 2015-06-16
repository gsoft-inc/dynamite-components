using System;
using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using GSoft.Dynamite.Targeting.SP.TimerJobs;
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
        private static string TimerJobName
        {
            get
            {
                return typeof(TargetingProfileTaxonomySyncJob).FullName;
            }
        }

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
                    var config = scope.Resolve<ITargetingProfileConfig>();
                    this.EnsureProfileProperties(scope, config, site);
                    this.EnsureProfileSyncTimerJob(scope, config, site);
                }
            }
        }

        private void EnsureProfileProperties(ILifetimeScope scope, ITargetingProfileConfig config, SPSite site)
        {
            var logger = scope.Resolve<ILogger>();
            var userProfilePropertyHelper = scope.Resolve<IUserProfilePropertyHelper>();
            foreach (var userProfilePropertyInfo in config.UserProfileProperties)
            {
                logger.Info("Ensuring profile property '{0}'", userProfilePropertyInfo.Name);
                userProfilePropertyHelper.EnsureProfileProperty(site, userProfilePropertyInfo);
            }
        }

        private void EnsureProfileSyncTimerJob(ILifetimeScope scope, ITargetingProfileConfig config, SPSite site)
        {
            // Delete if it already exists
            DeleteTimerJobIfExists(site, TimerJobName);

            // Register timer job with scheduling
            var timerJob = new TargetingProfileTaxonomySyncJob(TimerJobName, site.WebApplication)
            {
                Schedule = config.TimerJobSchedule
            };

            // Service accout for the application pool must be set
            // http://technet.microsoft.com/en-us/library/ee513067.aspx
            timerJob.Update();
        }

        private static void DeleteTimerJobIfExists(SPSite site, string jobName)
        {
            foreach (var timerJob in site.WebApplication.JobDefinitions.Where(jobDef => jobDef.Name == jobName))
            {
                timerJob.Delete();
            }
        }
    }
}
