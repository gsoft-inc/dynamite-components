using Autofac;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Social.Contracts.Configuration;
using GSoft.Dynamite.Social.Core.Configuration;
using GSoft.Dynamite.Social.Core.Repositories;

namespace GSoft.Dynamite.Social.Core.RegistrationModules
{
    /// <summary>
    /// Portal solution registration module for dependencies injection engine
    /// </summary>
    public class SocialRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Repositories
            builder.RegisterType<DiscussionRepository>();

            // Configurations
            builder.RegisterType<SocialDiscussionsConfig>().As<ISocialDiscussionsConfig>();
            builder.RegisterType<SocialDiscussionsConfig>().Named<ISocialDiscussionsConfig>(RegistrationNames.Social);
        }
    }
}
