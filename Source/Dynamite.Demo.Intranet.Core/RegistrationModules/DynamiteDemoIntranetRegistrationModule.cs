using Autofac;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Core.Configuration;
using Dynamite.Demo.Intranet.Core.Resources;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
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
            builder.RegisterType<DemoMultilingualismVariationsConfig>().As<IMultilingualismVariationsConfig>();

            // Catalogs Override
            builder.Register(c => new DemoMultilingualismVariationsConfig(
               c.ResolveNamed<IMultilingualismVariationsConfig>("multilingualism")
               )).As<IMultilingualismVariationsConfig>().Named<IMultilingualismVariationsConfig>("demo");


            // Catalogs Override
            builder.Register(c => new DemoPublishingCatalogInfoConfig(
               c.ResolveNamed<IPublishingCatalogInfoConfig>("publishing"),
               c.Resolve<DemoPublishingCatalogInfos>())).As<IPublishingCatalogInfoConfig>().Named<IPublishingCatalogInfoConfig>("demo");

            // Result Sources Override
            builder.Register(c => new DemoPublishingResultSourceInfoConfig(
               c.ResolveNamed<IPublishingResultSourceInfoConfig>("publishing"),
               c.Resolve<DemoPublishingResultSourceInfos>())).As<IPublishingResultSourceInfoConfig>().Named<IPublishingResultSourceInfoConfig>("demo");

            // Content Type Base Override
            builder.Register(c => new DemoPublishingContentTypeInfoConfig(
                c.ResolveNamed<IPublishingContentTypeInfoConfig>("publishing"),
                c.Resolve<PublishingContentTypeInfos>(),
                c.Resolve<DemoPublishingFieldInfos>(), c.Resolve<DemoPublishingContentTypeInfos>())).As<IPublishingContentTypeInfoConfig>().Named<IPublishingContentTypeInfoConfig>("demo");

            // Fields Base Override
            builder.Register(c => new DemoPublishingFieldInfoConfig(
               c.ResolveNamed<IPublishingFieldInfoConfig>("publishing"),
               c.Resolve<DemoPublishingFieldInfos>())).As<IPublishingFieldInfoConfig>().Named<IPublishingFieldInfoConfig>("demo");

            
            // Configuration Values
            builder.RegisterType<DemoPublishingFieldInfos>();
            builder.RegisterType<DemoPublishingContentTypeInfos>();
            builder.RegisterType<DemoPublishingCatalogInfos>();
            builder.RegisterType<DemoPublishingResultSourceInfos>(); 
        }
    }
}
