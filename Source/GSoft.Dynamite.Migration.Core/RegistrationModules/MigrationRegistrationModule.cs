using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using GSoft.Dynamite.Migration.Contracts.Constants;
using GSoft.Dynamite.Migration.Contracts.Resources;
using GSoft.Dynamite.Migration.Core.Configuration;

namespace GSoft.Dynamite.Migration.Core.RegistrationModules
{
    /// <summary>
    /// <c>Autofac</c> registration module for the migration module
    /// </summary>
    public class MigrationRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Configuration Values
            builder.RegisterType<MigrationFieldInfos>();

            // Resource locator
            builder.RegisterType<MigrationResourceLocatorConfig>()
                .As<IResourceLocatorConfig>()
                .Named<IResourceLocatorConfig>("migration");

            // Fields Configuration
            builder.RegisterType<MigrationFieldInfoConfig>()
                .As<IMigrationFieldInfoConfig>()
                .Named<IMigrationFieldInfoConfig>("migration");

            // Content Types Configuration
            builder.RegisterType<MigrationContentTypeInfoConfig>()
                .As<IMigrationContentTypeInfoConfig>()
                .Named<IMigrationContentTypeInfoConfig>("migration");

            // Managed Properties
            builder.RegisterType<MigrationManagedPropertyInfoConfig>()
                .As<IMigrationManagedPropertyInfoConfig>()
                .Named<IMigrationManagedPropertyInfoConfig>("migration");
        }
    }
}