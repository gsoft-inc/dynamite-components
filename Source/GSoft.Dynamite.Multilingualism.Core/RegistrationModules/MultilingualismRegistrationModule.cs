using Autofac;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Multilingualism.Contracts.Resources;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using GSoft.Dynamite.Multilingualism.Core.Configuration;
using GSoft.Dynamite.Multilingualism.Core.Services;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace GSoft.Dynamite.Multilingualism.Core.RegistrationModules
{
    /// <summary>
    /// Multilingualism <c>Autofac</c> module
    /// </summary>
    public class MultilingualismRegistrationModule : Module
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
            builder.RegisterType<MultilingualismResourceLocatorConfig>().As<IResourceLocatorConfig>();

            // Configuration Values
            builder.RegisterType<MultilingualismEventReceiverInfos>();
                      
            // Variations Configuration
            builder.RegisterType<MultilingualismVariationsConfig>().As<IMultilingualismVariationsConfig>();
            builder.RegisterType<MultilingualismVariationsConfig>().Named<IMultilingualismVariationsConfig>("multilingualism");

            // Content Types
            builder.RegisterType<MultilingualismContentTypeInfoConfig>().As<IMultilingualismContentTypeInfoConfig>();

            // Fields
            builder.RegisterType<MultilingualismFieldInfoConfig>().As<IMultilingualismFieldInfoConfig>();

            // Content Assoiciation Service
            builder.RegisterType<ContentAssociationService>().As<IContentAssocationService>(); 

            // Event Receivers
            builder.RegisterType<MultilingualismEventReceiverInfoConfig>().As<IMultilingualismEventReceiverInfoConfig>();
            builder.RegisterType<MultilingualismEventReceiverInfoConfig>().Named<IMultilingualismEventReceiverInfoConfig>("multilingualism");

            // Managed Properties
            builder.RegisterType<MultilingualismManagedPropertyInfoConfig>().As<ICommonManagedPropertyConfig>();

            // Result Sources
            builder.RegisterType<MultilingualismResultSourceInfoConfig>().As<IMultilingualismResultSourceInfoConfig>();
        }
    }
}
