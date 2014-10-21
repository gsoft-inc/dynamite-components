using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Multilingualism.Contracts.Resources;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using GSoft.Dynamite.Multilingualism.Core.Configuration;
using GSoft.Dynamite.Multilingualism.Core.Services;


namespace GSoft.Dynamite.Multilingualism.Core.RegistrationModules
{
    public class MultilingualismRegistrationModule: Module
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
            builder.RegisterType<MultilingualismFieldInfos>();
            builder.RegisterType<MultilingualismVariationLabelInfos>();
            builder.RegisterType<MultilingualismVariationSettingsInfos>();
            builder.RegisterType<MultilingualismEventReceiverInfos>();

            // Variations Configuration
            builder.RegisterType<MultilingualismVariationsConfig>().As<IMultilingualismVariationsConfig>();
            builder.RegisterType<MultilingualismVariationsConfig>().Named<IMultilingualismVariationsConfig>("multilingualism");

            // Multilingualism Service
            builder.RegisterType<LanguageSwitcherService>().As<ILanguageSwitcherService>();

            // Content Types
            builder.RegisterType<MultilingualismContentTypeInfoConfig>().As<IMultilingualismContentTypeInfoConfig>();

            // Fields
            builder.RegisterType<MultilingualismFieldInfoConfig>().As<IMultilingualismFieldInfoConfig>();

            // Content Assoiciation Service
            builder.RegisterType<ContentAssociationService>().As<IContentAssocationService>(); 

            // Event Receivers
            builder.RegisterType<MultilingualismEventReceiverInfoConfig>().As<IMultilingualismEventReceiverInfoConfig>();
        }
    }
}
