using Autofac;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using GSoft.Dynamite.Targeting.Contracts.Services;
using GSoft.Dynamite.Targeting.Core.Configuration;
using GSoft.Dynamite.Targeting.Core.Services;

namespace GSoft.Dynamite.Targeting.Core.RegistrationModules
{
    /// <summary>
    /// Portal solution registration module for dependencies injection engine
    /// </summary>
    public class TargetingRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Configurations
            builder.RegisterType<TargetingFieldInfoConfig>()
                .As<ITargetingFieldInfoConfig>()
                .Named<ITargetingFieldInfoConfig>("targeting");
            builder.RegisterType<TargetingContentTypeInfoConfig>()
                .As<ITargetingContentTypeInfoConfig>()
                .Named<ITargetingContentTypeInfoConfig>("targeting");
            builder.RegisterType<TargetingProfileConfig>()
                .As<ITargetingProfileConfig>()
                .Named<ITargetingProfileConfig>("targeting");
            builder.RegisterType<TargetingResultSourceInfoConfig>()
                .As<ITargetingResultSourceInfoConfig>()
                .Named<ITargetingResultSourceInfoConfig>("targeting");
            builder.RegisterType<TargetingEventReceiverInfoConfig>()
                .As<ITargetingEventReceiverInfoConfig>()
                .Named<ITargetingEventReceiverInfoConfig>("targeting");
            builder.RegisterType<TargetingCatalogInfoConfig>()
                .As<ITargetingCatalogInfoConfig>()
                .Named<ITargetingCatalogInfoConfig>("targeting");

            // Services
            builder.RegisterType<TargetingProfileTaxonomySyncService>()
                .As<ITargetingProfileTaxonomySyncService>()
                .Named<ITargetingProfileTaxonomySyncService>("targeting");
        }
    }
}
