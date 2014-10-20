using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Resources;
using GSoft.Dynamite.Navigation.Core.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

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
            builder.RegisterType<BaseNavigationTermDrivenPageSettingsInfoConfig>().As<IBaseNavigationTermDrivenpageSettingsInfoConfig>();

            // Content Type Base Override
            builder.RegisterType<BaseNavigationContentTypeInfoConfig>().As<IBaseNavigationContentTypeInfoConfig>();

            // Fields Base Override
            builder.RegisterType<BaseNavigationFieldInfoConfig>().As<IBaseNavigationFieldInfoConfig>();

            // Configuration Values
            builder.RegisterType<BaseNavigationTermDrivenPageSettingsInfos>();
            builder.RegisterType<BaseNavigationFieldInfos>(); 
        }
    }
}
