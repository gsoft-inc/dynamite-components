using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.LifeCycle.Contracts.WebParts;
using GSoft.Dynamite.LifeCycle.SP.WebParts.ContentBySearchSchedule;

namespace GSoft.Dynamite.LifeCycle.SP.RegistrationModules
{
    /// <summary>
    /// Portal Publishing Registration Module for the dependencies injection engine
    /// </summary>
    public class LifeCycleSPRegistrationModule : Module
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
        }
    }
}