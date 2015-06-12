using System;
using Autofac;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using GSoft.Dynamite.Targeting.Core.Configuration;

namespace GSoft.Dynamite.Targeting.Core.RegistrationModules
{
    /// <summary>
    /// <c>Autofac</c> registration module for the targeting module
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
            // Fields Configuration
            builder.RegisterType<TargetingFieldInfoConfig>()
                .As<ITargetingFieldInfoConfig>()
                .Named<ITargetingFieldInfoConfig>("targeting");

            // Content Types Configuration
            builder.RegisterType<TargetingContentTypeInfoConfig>()
                .As<ITargetingContentTypeInfoConfig>()
                .Named<ITargetingContentTypeInfoConfig>("targeting");
        }
    }
}
