using Autofac;
using GSoft.Dynamite.Common.Contracts.Constants;
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
            builder.RegisterType<AuthTargetingContentConfig>()
                .Named<ITargetingContentConfig>(RegistrationNames.Auth);

            builder.RegisterType<DocsTargetingContentConfig>()
                .Named<ITargetingContentConfig>(RegistrationNames.Docs);

            builder.RegisterType<TargetingProfileConfig>()
                .As<ITargetingProfileConfig>()
                .Named<ITargetingProfileConfig>(RegistrationNames.Targeting);

            builder.RegisterType<TargetingSearchConfig>()
                .As<ITargetingSearchConfig>()
                .Named<ITargetingSearchConfig>(RegistrationNames.Targeting);

            // Services
            builder.RegisterType<TargetingProfileTaxonomySyncService>()
                .As<ITargetingProfileTaxonomySyncService>()
                .Named<ITargetingProfileTaxonomySyncService>(RegistrationNames.Targeting);
        }
    }
}
