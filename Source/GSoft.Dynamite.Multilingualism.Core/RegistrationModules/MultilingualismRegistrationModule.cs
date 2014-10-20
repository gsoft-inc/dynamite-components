﻿using Autofac;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using GSoft.Dynamite.Multilingualism.Core.Configuration;
using GSoft.Dynamite.Multilingualism.Core.Services;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

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
            // Configuration Values
            builder.RegisterType<BaseMultilingualismFieldInfos>();
            builder.RegisterType<BaseMultilingualismVariationLabelInfos>();
            builder.RegisterType<BaseMultilingualismVariationSettingsInfos>();

            // Variations Configuration
            builder.RegisterType<BaseMultilingualismVariationsConfig>().As<IBaseMultilingualismVariationsConfig>();
            
            // Multilingualism Service
            builder.RegisterType<LanguageSwitcherService>().As<ILanguageSwitcherService>();

            // 
            builder.Register(c => new BaseMultilingualismContentTypeInfoConfig(
                c.ResolveNamed<IBasePublishingContentTypeInfoConfig>("implementor"),
                c.Resolve<BasePublishingContentTypeInfos>(),
                c.Resolve<BaseMultilingualismFieldInfos>())).As<IBasePublishingContentTypeInfoConfig>();

            builder.Register(c => new BaseMultilingualismFieldInfoConfig(
               c.ResolveNamed<IBasePublishingFieldInfoConfig>("implementor"),
               c.Resolve<BaseMultilingualismFieldInfos>())).As<IBasePublishingFieldInfoConfig>();
        }
    }
}