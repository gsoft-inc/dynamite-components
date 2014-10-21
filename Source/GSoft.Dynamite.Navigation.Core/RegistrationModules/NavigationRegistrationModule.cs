using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Resources;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Navigation.Core.Configuration;
using GSoft.Dynamite.Navigation.Core.Services;

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

            // Content Type Base Override
            builder.RegisterType<NavigationContentTypeInfoConfig>().As<INavigationContentTypeInfoConfig>();

            // Fields Base Override
            builder.RegisterType<NavigationFieldInfoConfig>().As<INavigationFieldInfoConfig>();

            // Event Receivers
            builder.RegisterType<NavigationEventReceiverInfoConfig>().As<INavigationEventReceiverInfoConfig>();

            // Result Sources
            builder.RegisterType<NavigationResultSourceInfoConfig>().As<INavigationResultSourceInfoConfig>();

            // Configuration Values
            builder.RegisterType<NavigationTermDrivenPageSettingsInfos>();
            builder.RegisterType<NavigationFieldInfos>();
            builder.RegisterType<NavigationEventReceiverInfos>();
            builder.RegisterType<NavigationResultSourceInfos>(); 

            // Slug Builder Service
            builder.RegisterType<SlugBuilderService>().As<ISlugBuilderService>();
        }
    }
}
