using Autofac;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Multilingualism.Core.Configuration;

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
            builder.RegisterType<BaseMultilingualismVariationLabelInfos>();
            builder.RegisterType<BaseMultilingualismVariationSettingsInfos>();

            // Variations Configuration
            builder.RegisterType<BaseMultilingualismVariationsConfig>().As<IBaseMultilingualismVariationsConfig>();


        }
    }
}
