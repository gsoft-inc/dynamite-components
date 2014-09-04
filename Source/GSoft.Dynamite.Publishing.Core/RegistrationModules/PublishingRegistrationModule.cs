using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Core.Resources;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Core.Configuration;

namespace GSoft.Dynamite.Publishing.Core.RegistrationModules
{
    /// <summary>
    /// Portal solution registration module for dependencies injection engine
    /// </summary>
    public class PublishingRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Resource Locator
            builder.RegisterType<PublishingResourceLocatorConfig>().As<IResourceLocatorConfig>();

            // Content Types
            builder.RegisterType<BaseContentTypeInfoConfig>().As<IBaseContentTypeInfoConfig>();

            // Content Types Factory
            builder.RegisterType<BaseFieldInfoConfig>().As<IBaseFieldInfoConfig>();

            // Term Sets
            builder.RegisterType<BaseTaxonomyConfig>().As<IBaseTaxonomyConfig>();

        }
    }
}
