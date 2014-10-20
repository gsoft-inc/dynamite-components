using Autofac;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Core.Configuration;
using Dynamite.Demo.Intranet.Core.Resources;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using GSoft.Dynamite.Publishing.Contracts.Constants;

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
            //builder.RegisterType<DynamiteDemoPublishingContentTypeInfoConfig>().As<ICustomPublishingContentTypeInfoConfig>();
            //builder.RegisterType<DynamiteDemoPublishingFieldInfoConfig>().As<ICustomPublishingFieldInfoConfig>();
            builder.RegisterType<DynamiteDemoPublishingCatalogInfoConfig>().As<ICustomPublishingCatalogInfoConfig>();
            builder.RegisterType<DynamiteDemoMultilingualismVariationsConfig>().As<IBaseMultilingualismVariationsConfig>();
            builder.RegisterType<DynamiteDemoPublishingResultSourceInfoConfig>().As<ICustomPublishingResultSourceInfoConfig>();


            // Content Type Base Override
            builder.Register(c => new DynamiteDemoPublishingContentTypeInfoConfig(
                c.ResolveNamed<IBasePublishingContentTypeInfoConfig>("publishing"),
                c.Resolve<BasePublishingContentTypeInfos>(),
                c.Resolve<DynamiteDemoPublishingFieldInfos>(), c.Resolve<DynamiteDemoPublishingContentTypeInfos>())).As<IBasePublishingContentTypeInfoConfig>().Named<IBasePublishingContentTypeInfoConfig>("demo");

            // Fields Base Override
            builder.Register(c => new DynamiteDemoPublishingFieldInfoConfig(
               c.ResolveNamed<IBasePublishingFieldInfoConfig>("publishing"),
               c.Resolve<DynamiteDemoPublishingFieldInfos>())).As<IBasePublishingFieldInfoConfig>().Named<IBasePublishingFieldInfoConfig>("demo");

            
            // Configuration Values
            builder.RegisterType<DynamiteDemoPublishingFieldInfos>();
            builder.RegisterType<DynamiteDemoPublishingContentTypeInfos>();
            builder.RegisterType<DynamiteDemoPublishingCatalogInfos>();
            builder.RegisterType<DynamiteDemoPublishingResultSourceInfos>(); 
        }
    }
}
