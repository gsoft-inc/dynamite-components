    using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Resources;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Navigation.Core.Configuration;
using GSoft.Dynamite.Navigation.Core.Services;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace GSoft.Dynamite.Navigation.Core.RegistrationModules
{
    public class NavigationRegistrationModule : Module
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
            builder.RegisterType<NavigationResourceLocatorConfig>().As<IResourceLocatorConfig>();

            // Term Driven Pages
            builder.RegisterType<NavigationTermDrivenPageSettingsInfoConfig>().As<INavigationTermDrivenpageSettingsInfoConfig>();

            // Content Types
            builder.RegisterType<NavigationContentTypeInfoConfig>().As<INavigationContentTypeInfoConfig>();
            builder.RegisterType<NavigationContentTypeInfoConfig>().Named<INavigationContentTypeInfoConfig>("navigation");

            // Fields
            builder.RegisterType<NavigationFieldInfoConfig>().As<INavigationFieldInfoConfig>();
            builder.RegisterType<NavigationFieldInfoConfig>().Named<INavigationFieldInfoConfig>("navigation");

            // Event Receivers
            builder.RegisterType<NavigationEventReceiverInfoConfig>().As<INavigationEventReceiverInfoConfig>();

            // Result Sources
            builder.RegisterType<NavigationResultSourceInfoConfig>().As<INavigationResultSourceInfoConfig>();

            // Catalog Connections
            builder.RegisterType<NavigationCatalogConnectionInfoConfig>().As<INavigationCatalogConnectionInfoConfig>();

            // Managed Properties
            builder.RegisterType<NavigationManagedPropertyConfig>().As<IPublishingManagedPropertyInfosConfig>();
            builder.RegisterType<NavigationManagedPropertyConfig>().Named<IPublishingManagedPropertyInfosConfig>("navigation");

            // Managed Navigation
            builder.RegisterType<NavigationManagedNavigationInfoConfig>().As<INavigationManagedNavigationInfoConfig>();

            // Configuration Values
            builder.RegisterType<NavigationTermDrivenPageSettingsInfos>();
            builder.RegisterType<NavigationFieldInfos>();
            builder.RegisterType<NavigationEventReceiverInfos>();
            builder.RegisterType<NavigationResultSourceInfos>();
            builder.RegisterType<NavigationCatalogConnectionInfos>();
            builder.RegisterType<NavigationTermGroupInfos>();
            builder.RegisterType<NavigationTermSetInfos>();
            builder.RegisterType<NavigationManagedPropertyInfos>();
            builder.RegisterType<NavigationManagedNavigationInfos>(); 

            // Slug Builder Service
            builder.RegisterType<SlugBuilderService>().As<ISlugBuilderService>();

            // Navigation Service
            builder.RegisterType<DynamiteNavigationService>().As<IDynamiteNavigationService>();
        }
    }
}
