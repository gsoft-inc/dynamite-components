using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Core.Resources;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
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
            builder.RegisterType<BasePublishingContentTypeInfoConfig>().As<IBasePublishingContentTypeInfoConfig>();

            // Content Types Factory
            builder.RegisterType<BasePublishingFieldInfoConfig>().As<IBasePublishingFieldInfoConfig>();

            // Term Sets
            builder.RegisterType<BasePublishingTaxonomyConfig>().As<IBasePublishingTaxonomyConfig>();

            // Catalogs
            builder.RegisterType<BasePublishingCatalogInfoConfig>().As<IBasePublishingCatalogInfoConfig>();

            // Result Sources
            builder.RegisterType<BasePublishingResultSourceInfoConfig>().As<IBasePublishingResultSourceInfoConfig>();

            // Folders
            builder.RegisterType<BasePublishingFolderInfoConfig>().As<IBasePublishingFolderInfoConfig>();

            // Display Templates
            builder.RegisterType<BasePublishingDisplayTemplateInfoConfig>().As<IBasePublishingDisplayTemplateInfoConfig>();
            
            // Configuration Values
            builder.RegisterType<BasePublishingContentTypeInfos>();
            builder.RegisterType<BasePublishingFieldInfos>();
            builder.RegisterType<BasePublishingCatalogInfos>();
            builder.RegisterType<BasePublishingTermGroupInfos>();
            builder.RegisterType<BasePublishingTermSetInfos>();
            builder.RegisterType<BasePublishingTermInfos>();
            builder.RegisterType<BasePublishingResultSourceInfos>();
            builder.RegisterType<BasePublishingPageInfos>();
            builder.RegisterType<BasePublishingPageLayoutInfo>();
            builder.RegisterType<BasePublishingFolderInfos>();
            builder.RegisterType<BasePublishingDisplayTemplateInfos>();
            builder.RegisterType<BasePublishingWebPartInfos>();        
        }
    }
}
