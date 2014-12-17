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
    /// <summary>
    /// The <c>Autofac</c> registration module for the navigation module
    /// </summary>
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
            builder.RegisterType<NavigationTermDrivenPageSettingsInfoConfig>().Named<INavigationTermDrivenpageSettingsInfoConfig>("navigation");

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
            builder.RegisterType<NavigationCatalogConnectionInfoConfig>().Named<INavigationCatalogConnectionInfoConfig>("navigation");

            // Managed Properties
            builder.RegisterType<NavigationManagedPropertyConfig>().As<ICommonManagedPropertyInfosConfig>();
            builder.RegisterType<NavigationManagedPropertyConfig>().Named<ICommonManagedPropertyInfosConfig>("navigation");

            // Managed Navigation
            builder.RegisterType<NavigationManagedNavigationInfoConfig>().As<INavigationManagedNavigationInfoConfig>();
            builder.RegisterType<NavigationManagedNavigationInfoConfig>().Named<INavigationManagedNavigationInfoConfig>("navigation");

            // Lists
            builder.RegisterType<NavigationListInfosConfig>().As<INavigationListInfosConfig>();

            // Catalogs
            builder.RegisterType<NavigationCatalogInfoConfig>().As<INavigationCatalogInfoConfig>();
            builder.RegisterType<NavigationCatalogInfoConfig>().Named<INavigationCatalogInfoConfig>("navigation");

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
            builder.RegisterType<NavigationListInfos>(); 

            // Slug Builder Service
            builder.RegisterType<SlugBuilderService>().As<ISlugBuilderService>();

            // Navigation Term Builder Service
            builder.RegisterType<NavigationTermBuilderService>().As<INavigationTermBuilderService>();
            
            // Navigation Service
            builder.RegisterType<DynamiteNavigationService>().As<IDynamiteNavigationService>();
        }
    }
}
