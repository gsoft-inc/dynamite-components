using Autofac;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Core.Resources;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Entities;
using GSoft.Dynamite.Publishing.Contracts.Repositories;
using GSoft.Dynamite.Publishing.Contracts.Services;
using GSoft.Dynamite.Publishing.Core.Configuration;
using GSoft.Dynamite.Publishing.Core.Repositories;
using GSoft.Dynamite.Publishing.Core.Services;

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
            builder.RegisterType<PublishingResourceLocatorConfig>().Named<IResourceLocatorConfig>("publishing");

            // Content Types
            builder.RegisterType<PublishingContentTypeInfoConfig>().As<IPublishingContentTypeInfoConfig>();
            builder.RegisterType<PublishingContentTypeInfoConfig>().Named<IPublishingContentTypeInfoConfig>("publishing");

            // Fields
            builder.RegisterType<PublishingFieldInfoConfig>().As<IPublishingFieldInfoConfig>();
            builder.RegisterType<PublishingFieldInfoConfig>().Named<IPublishingFieldInfoConfig>("publishing");

            // Term Sets
            builder.RegisterType<PublishingTaxonomyConfig>().As<IPublishingTaxonomyConfig>();
            builder.RegisterType<PublishingTaxonomyConfig>().Named<IPublishingTaxonomyConfig>("publishing");

            // Catalogs
            builder.RegisterType<PublishingCatalogInfoConfig>().As<IPublishingCatalogInfoConfig>();
            builder.RegisterType<PublishingCatalogInfoConfig>().Named<IPublishingCatalogInfoConfig>("publishing");

            // Result Sources
            builder.RegisterType<PublishingResultSourceInfoConfig>().As<IPublishingResultSourceInfoConfig>();
            builder.RegisterType<PublishingResultSourceInfoConfig>().Named<IPublishingResultSourceInfoConfig>("publishing");

            // Page instances
            builder.RegisterType<PublishingPageInfoConfig>().As<IPublishingPageInfoConfig>();
            builder.RegisterType<PublishingPageInfoConfig>().Named<IPublishingPageInfoConfig>("publishing");

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
            builder.RegisterType<PublishingManagedPropertyConfig>().As<ICommonManagedPropertyConfig>();
            builder.RegisterType<PublishingManagedPropertyConfig>().Named<ICommonManagedPropertyConfig>("publishing");

            // Page Layouts
            builder.RegisterType<PublishingPageLayoutInfoConfig>().As<IPublishingPageLayoutInfoConfig>();
            builder.RegisterType<PublishingPageLayoutInfoConfig>().Named<IPublishingPageLayoutInfoConfig>("publishing");

            // Page Layouts
            builder.RegisterType<PublishingListInfoConfig>().As<IPublishingListInfoConfig>();
            builder.RegisterType<PublishingListInfoConfig>().Named<IPublishingListInfoConfig>("publishing");

            // Faceted navigation
            builder.RegisterType<PublishingFacetedNavigationInfoConfig>().As<IPublishingFacetedNavigationInfoConfig>();
            builder.RegisterType<PublishingFacetedNavigationInfoConfig>().Named<IPublishingFacetedNavigationInfoConfig>("publishing");

            // Metadata navigation
            builder.RegisterType<PublishingMetadataNavigationSettingsConfig>().As<IPublishingMetadataNavigationSettingsConfig>();
            builder.RegisterType<PublishingMetadataNavigationSettingsConfig>().Named<IPublishingMetadataNavigationSettingsConfig>("publishing");
     
            // Reusable Content
            builder.RegisterType<PublishingReusableContentInfoConfig>().As<IPublishingReusableContentInfoConfig>();
            builder.RegisterType<PublishingReusableContentInfoConfig>().Named<IPublishingReusableContentInfoConfig>("publishing");

            // WebPart
            builder.RegisterType<PublishingWebPartInfoConfig>().As<IPublishingWebPartInfoConfig>();
            builder.RegisterType<PublishingWebPartInfoConfig>().Named<IPublishingWebPartInfoConfig>("publishing");
        }
    }
}
