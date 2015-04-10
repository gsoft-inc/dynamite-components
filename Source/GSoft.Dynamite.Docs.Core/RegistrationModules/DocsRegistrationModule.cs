using Autofac;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Docs.Contracts.Constants;
using GSoft.Dynamite.Docs.Contracts.Resources;
using GSoft.Dynamite.Docs.Core.Configuration;
using GSoft.Dynamite.Globalization;

namespace GSoft.Dynamite.Docs.Core.RegistrationModules
{
    /// <summary>
    /// <c>Autofac</c> registration module for the document management module
    /// </summary>
    public class DocsRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Resource locator
            builder.RegisterType<DocsResourceLocatorConfig>().As<IResourceLocatorConfig>();

            // Fields Configuration
            builder.RegisterType<DocsFieldInfoConfig>().As<IDocsFieldInfoConfig>();

            // Content Types Configuration
            builder.RegisterType<DocsContentTypeInfoConfig>().As<IDocsContentTypeInfoConfig>();

            // Lists Configuration
            builder.RegisterType<DocsListInfoConfig>().As<IDocsListInfoConfig>();

            // Image Renditions
            builder.RegisterType<DocsImageRenditionInfoConfig>().As<IDocsImageRenditionInfoConfig>();
            builder.RegisterType<DocsImageRenditionInfoConfig>().Named<IDocsImageRenditionInfoConfig>("docs");
        }
    }
}