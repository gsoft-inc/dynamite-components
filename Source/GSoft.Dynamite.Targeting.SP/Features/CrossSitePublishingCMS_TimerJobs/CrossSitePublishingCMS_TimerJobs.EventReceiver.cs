using System;
using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using GSoft.Dynamite.Targeting.SP.TimerJobs;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP.Features.CrossSitePublishingCMS_TimerJobs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("ed22afbc-1e9e-4e95-af78-eb6c62d6650f")]
    public class CrossSitePublishingCmsTimerJobsEventReceiver : SPFeatureReceiver
    {
        private static string JobName
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
            // If you encounter "Access Denied" error on your environnement
            // http://tolgaizgi.wordpress.com/2012/01/24/sharepoint-2010-access-denied-error-message-while-activating-a-timerjob-site-feature/
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                // Delete if it already exists
                DeleteTimerJobIfExists(site, JobName);

                // Register timer job with scheduling
                using (var scope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var config = scope.Resolve<ITargetingProfileConfig>();
                    var timerJob = new TargetingProfileTaxonomySyncJob(JobName, site.WebApplication)
                    {
                        Schedule = config.TimerJobSchedule
                    };

                    // Service accout for the application pool must be set
                    // http://technet.microsoft.com/en-us/library/ee513067.aspx
                    timerJob.Update();
                }
            }
        }

        /// <summary>
        /// Occurs when a Feature is deactivated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPFeatureReceiverProperties" /> object that represents the properties of the event.</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                DeleteTimerJobIfExists(site, JobName); 
            }
        }

        /// <summary>
        /// Delete a Timer Job
        /// </summary>
        /// <param name="site">The site collection.</param>
        /// <param name="jobName">The timer job name.</param>
        private static void DeleteTimerJobIfExists(SPSite site, string jobName)
        {
            foreach (var timerJob in site.WebApplication.JobDefinitions.Where(jobDef => jobDef.Name == jobName))
            {
                timerJob.Delete();
            }
        }
    }
}
