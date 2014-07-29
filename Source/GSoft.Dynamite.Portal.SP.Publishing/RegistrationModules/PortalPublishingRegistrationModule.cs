using Autofac;
using GSoft.Dynamite.Navigation;
using GSoft.Dynamite.Portal.Contracts.Services;
using GSoft.Dynamite.Portal.Contracts.WebParts;
using GSoft.Dynamite.Portal.SP.Publishing.WebParts.ChildNodes;
using GSoft.Dynamite.Portal.SP.Publishing.WebParts.ContentBySearchSchedule;
using GSoft.Dynamite.Portal.SP.Publishing.WebParts.ContextualNavigation;
using GSoft.Dynamite.Portal.SP.Publishing.WebParts.ResultScriptSchedule;

namespace GSoft.Dynamite.Portal.SP.Publishing.RegistrationModules
{
    /// <summary>
    /// Portal Publishing Registration Module for the dependencies injection engine
    /// </summary>
    public class PortalPublishingRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // WebParts
            builder.RegisterType<ContentBySearchSchedule>().As<IContentBySearchSchedule>().ExternallyOwned();
            builder.RegisterType<ResultScriptSchedule>().As<IResultScriptSchedule>().ExternallyOwned();
            builder.RegisterType<ContextualNavigation>().As<IContextualNavigation>().ExternallyOwned();
            builder.RegisterType<ChildNodes>().As<IChildNodes>().ExternallyOwned();
        }
    }
}
