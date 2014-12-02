using Autofac;
using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Design.Core.Configuration;

namespace GSoft.Dynamite.Design.Core.RegistrationModules
{
    /// <summary>
    /// <c>Autofac</c> registration module for the design module
    /// </summary>
    public class DesignRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Variations Configuration
            builder.RegisterType<DesignConfig>().As<IDesignConfig>();
            builder.RegisterType<DesignConfig>().Named<IDesignConfig>("design");
        }
    }
}
