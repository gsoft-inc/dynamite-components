using System;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using GSoft.Dynamite.Targeting.Contracts.Constants;
using GSoft.Dynamite.Targeting.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace GSoft.Dynamite.Targeting.SP.TimerJobs
{
    /// <summary>
    /// Targeting profile taxonomy synchronization job.
    /// </summary>
    public class TargetingProfileTaxonomySyncJob : SPJobDefinition
    {
        private ILogger logger;
        private ITargetingProfileConfig targetingConfiguration;
        private ITargetingProfileTaxonomySyncService targetingService;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TargetingProfileTaxonomySyncJob()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetingProfileTaxonomySyncJob"/> class.
        /// </summary>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="webApplication">The web application.</param>
        public TargetingProfileTaxonomySyncJob(string jobName, SPWebApplication webApplication)
            : base(jobName, webApplication, null, SPJobLockType.Job)
        {
            this.Title = TargetingConstants.TargetingTimerJobName;
        }

        /// <summary>
        /// Timer job description
        /// </summary>
        public override string Description
        {
            get
            {
                return TargetingConstants.TargetingTimerJobDescription;
            }
        }

        private static SPSite CentralAdminSite
        {
            get
            {
                return SPAdministrationWebApplication.Local.Sites[0];
            }
        }

        /// <summary>
        /// Execute method of the timer job.
        /// </summary>
        /// <param name="targetInstanceId">The target instance Id.</param>
        public override void Execute(Guid targetInstanceId)
        {
            using (var scope = TargetingContainerProxy.BeginWebLifetimeScope(CentralAdminSite.RootWeb))
            {
                this.logger = scope.Resolve<ILogger>();
                try
                {
                    this.targetingConfiguration = scope.Resolve<ITargetingProfileConfig>();
                    this.targetingService = scope.Resolve<ITargetingProfileTaxonomySyncService>();

                    // Synchronize targeting taxonomy fields for changed users
                    this.targetingService.SyncTaxonomyFieldsForChangedUsers(
                        CentralAdminSite,
                        this.targetingConfiguration.UserProfileChangeTimespan,
                        this.targetingConfiguration.UserProfilePropertySyncMappings);
                }
                catch (SPException ex)
                {
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
