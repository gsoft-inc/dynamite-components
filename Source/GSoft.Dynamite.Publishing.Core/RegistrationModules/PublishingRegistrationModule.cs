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
            builder.RegisterType<PublishingContentTypeInfoConfig>().As<IPublishingContentTypeInfoConfig>();
            builder.RegisterType<PublishingContentTypeInfoConfig>().Named<IPublishingContentTypeInfoConfig>("publishing");

            // Fields
            builder.RegisterType<PublishingFieldInfoConfig>().As<IPublishingFieldInfoConfig>();
            builder.RegisterType<PublishingFieldInfoConfig>().Named<IPublishingFieldInfoConfig>("publishing");

            // Term Sets
            builder.RegisterType<PublishingTaxonomyConfig>().As<IPublishingTaxonomyConfig>();

            // Catalogs
            builder.RegisterType<PublishingCatalogInfoConfig>().As<IPublishingCatalogInfoConfig>();
            builder.RegisterType<PublishingCatalogInfoConfig>().Named<IPublishingCatalogInfoConfig>("publishing");

            // Result Sources
            builder.RegisterType<PublishingResultSourceInfoConfig>().As<IPublishingResultSourceInfoConfig>();
            builder.RegisterType<PublishingResultSourceInfoConfig>().Named<IPublishingResultSourceInfoConfig>("publishing");

            // Folders
            builder.RegisterType<PublishingFolderInfoConfig>().As<IPublishingFolderInfoConfig>();
            builder.RegisterType<PublishingFolderInfoConfig>().Named<IPublishingFolderInfoConfig>("publishing");

            // Display Templates
            builder.RegisterType<PublishingDisplayTemplateInfoConfig>().As<IPublishingDisplayTemplateInfoConfig>();
            builder.RegisterType<PublishingDisplayTemplateInfoConfig>().Named<IPublishingDisplayTemplateInfoConfig>("publishing");

            // Result Types
            builder.RegisterType<PublishingResultTypeInfoConfig>().As<IPublishingResultTypeInfoConfig>();
            builder.RegisterType<PublishingResultTypeInfoConfig>().Named<IPublishingResultTypeInfoConfig>("publishing");

            // Managed Properties
            builder.RegisterType<PublishingManagedPropertyConfig>().As<ICommonManagedPropertyInfosConfig>();

            // Page Layouts
            builder.RegisterType<PublishingPageLayoutInfoConfig>().As<IPublishingPageLayoutInfoConfig>();

            // Page Layouts
            builder.RegisterType<PublishingListInfoConfig>().As<IPublishingListInfoConfig>();

            // Faceted navigation
            builder.RegisterType<PublishingFacetedNavigationInfoConfig>().As<IPublishingFacetedNavigationInfoConfig>();

            // Metadata navigation
            builder.RegisterType<PublishingMetadataNavigationSettingsConfig>().As<IPublishingMetadataNavigationSettingsConfig>();
            builder.RegisterType<PublishingMetadataNavigationSettingsConfig>().Named<IPublishingMetadataNavigationSettingsConfig>("publishing");
     
            // Configuration Values
            builder.RegisterType<PublishingContentTypeInfos>();
            builder.RegisterType<PublishingFieldInfos>();
            builder.RegisterType<PublishingCatalogInfos>();
            builder.RegisterType<PublishingTermGroupInfos>();
            builder.RegisterType<PublishingTermSetInfos>();
            builder.RegisterType<PublishingTermInfos>();
            builder.RegisterType<PublishingResultSourceInfos>();
            builder.RegisterType<PublishingPageInfos>();
            builder.RegisterType<PublishingPageLayoutInfos>();
            builder.RegisterType<PublishingFolderInfos>();
            builder.RegisterType<PublishingDisplayTemplateInfos>();
            builder.RegisterType<PublishingWebPartInfos>();
            builder.RegisterType<PublishingResultTypeInfos>();
            builder.RegisterType<PublishingManagedPropertyInfos>();
            builder.RegisterType<PublishingListInfos>();
            builder.RegisterType<PublishingFacetedNavigationInfos>();
            builder.RegisterType<PublishingMetadataNavigationSettingsInfos>();
        }
    }
}
