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
            // Base CSS Configuration
            builder.RegisterType<BaseCssConfig>().As<IBaseCssConfig>();
            builder.RegisterType<BaseCssConfig>().Named<IBaseCssConfig>("design");

            // Design Configuration
            builder.RegisterType<DesignConfig>().As<IDesignConfig>();
            builder.RegisterType<DesignConfig>().Named<IDesignConfig>("design");

            // Home page instances
            builder.RegisterType<HomePageConfig>().As<IHomePageConfig>();
            builder.RegisterType<HomePageConfig>().Named<IHomePageConfig>("design");
        }
    }
}
