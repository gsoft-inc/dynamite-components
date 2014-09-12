using Autofac;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Core.Configuration;
using Dynamite.Demo.Intranet.Core.Resources;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.RegistrationModules
{
    public class DynamiteDemoIntranetRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Dynamite base config overrides
            builder.RegisterType<DynamiteDemoResourceLocatorConfig>().As<IResourceLocatorConfig>();

            // Overridable default Portal config (i.e. plugin hooks and slots, with sensible defaults)
            builder.RegisterType<DynamiteDemoContentTypeInfoConfig>().As<ICustomContentTypeInfoConfig>();
            builder.RegisterType<DynamiteDemoFieldInfoConfig>().As<ICustomFieldInfoConfig>();

            // Configuration Values
            builder.RegisterType<DynamiteDemoFieldInfoValues>();
            builder.RegisterType<DynamiteDemoContentTypeInfoValues>();
        }
    }
}
