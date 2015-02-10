using Autofac;

namespace GSoft.Dynamite.Common.Contract.RegistrationModules
{
    /// <summary>
    /// Global registration module.
    /// </summary>
    public class GlobalRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}
