using System;
using System.Linq;
using System.Runtime.InteropServices;
using GSoft.Dynamite.Targeting.SP.TimerJobs;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

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
        private static SPSite CentralAdminSite
        {
            get
            {
                return SPAdministrationWebApplication.Local.Sites[0];
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
                if (CentralAdminSite.ID.Equals(site.ID))
                {
                    var jobClassName = typeof(TargetingProfileTaxonomySyncJob).Name;

                    // Delete if it already exists
                    DeleteTimerJobIfExists(site, jobClassName);

                    // Create timer job with scheduling
                    var timerJob = new TargetingProfileTaxonomySyncJob(jobClassName, site.WebApplication)
                    {
                        Schedule = new SPDailySchedule
                        {
                            BeginMinute = 0, 
                            EndMinute = 10, 
                            BeginHour = 2, 
                            EndHour = 2
                        }
                    };

                    // Service accout for the application pool must be set
                    // http://technet.microsoft.com/en-us/library/ee513067.aspx
                    timerJob.Update();
                }
                else
                {
                    throw new SPException("This feature can only be activated on the central administration site collection.");
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
                var jobClassName = typeof(TargetingProfileTaxonomySyncJob).Name;
                DeleteTimerJobIfExists(site, jobClassName); 
            }
        }

        /// <summary>
        /// Delete a Timer Job
        /// </summary>
        /// <param name="site">The site collection.</param>
        /// <param name="jobTitle">The timer job title.</param>
        private static void DeleteTimerJobIfExists(SPSite site, string jobTitle)
        {
            foreach (var timerJob in site.WebApplication.JobDefinitions.Where(jobDef => jobDef.Name == jobTitle))
            {
                timerJob.Delete();
            }
        }
    }
}
