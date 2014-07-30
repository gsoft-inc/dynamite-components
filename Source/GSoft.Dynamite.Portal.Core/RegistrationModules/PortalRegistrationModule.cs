using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Contracts.Config;
using GSoft.Dynamite.Portal.Contracts.Factories;
using GSoft.Dynamite.Portal.Contracts.Services;
using GSoft.Dynamite.Portal.Contracts.Utils;
using GSoft.Dynamite.Portal.Core.Config;
using GSoft.Dynamite.Portal.Core.Factories;
using GSoft.Dynamite.Portal.Core.Resources;
using GSoft.Dynamite.Portal.Core.Services;
using GSoft.Dynamite.Portal.Core.Utils;

namespace GSoft.Dynamite.Portal.Core.RegistrationModules
{
    /// <summary>
    /// Portal solution registration module for dependencies injection engine
    /// </summary>
    public class PortalRegistrationModule : Module
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
            builder.RegisterType<PortalResourceLocatorConfig>().As<IResourceLocatorConfig>();

            // Overridable default Portal config (i.e. plugin hooks and slots, with sensible defaults)
            builder.RegisterType<DefaultTermStoreConfig>().As<IPortalTermStoreConfig>();
            builder.RegisterType<DefaultCatalogConfig>().As<IPortalCatalogConfig>();

            // Portal Utils
            builder.RegisterType<ContentTypeFactory>().As<IContentTypeFactory>();
            builder.RegisterType<SchedulingControl>().As<ISchedulingControl>();
            builder.RegisterType<ContentAssociation>().As<IContentAssociation>();
            builder.RegisterType<ListViewFactory>().As<IListViewFactory>();
            builder.RegisterType<WebPartFactory>().As<IWebPartFactory>();
            builder.RegisterType<NavigationBuilder>().As<INavigationBuilder>();
            
            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>();
        }
    }
}
