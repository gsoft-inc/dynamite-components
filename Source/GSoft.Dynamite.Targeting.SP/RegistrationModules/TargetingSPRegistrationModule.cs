using System;
using Autofac;
using GSoft.Dynamite.Targeting.SP.TimerJobs;
using Microsoft.SharePoint.Administration;

namespace GSoft.Dynamite.Targeting.SP.RegistrationModules
{
    /// <summary>
    /// Portal Targeting Registration Module for the dependencies injection engine
    /// </summary>
    public class TargetingSPRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Timer Jobs
            builder.RegisterType<TargetingProfileTaxonomySyncJob>().As<SPJobDefinition>();
        }
    }
}
