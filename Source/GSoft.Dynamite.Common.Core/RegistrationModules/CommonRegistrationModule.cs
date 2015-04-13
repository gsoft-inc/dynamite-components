using Autofac;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Common.Core.Configuration;

namespace GSoft.Dynamite.Common.Core.RegistrationModules
{
    /// <summary>
    /// Global registration module.
    /// </summary>
    public class CommonRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Taxonomy
            builder.RegisterType<CommonTaxonomyConfig>()
                .As<ICommonTaxonomyConfig>()
                .Named<ICommonTaxonomyConfig>("common");

            // Managed Properties
            builder.RegisterType<ConsolidatedManagedPropertyConfig>()
                .As<IConsolidatedManagedPropertyConfig>()
                .Named<IConsolidatedManagedPropertyConfig>("common");
        }
    }
}
