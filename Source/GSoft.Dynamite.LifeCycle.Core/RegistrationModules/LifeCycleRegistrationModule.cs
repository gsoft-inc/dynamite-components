using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.LifeCycle.Contracts.Controls;
using GSoft.Dynamite.LifeCycle.Core.Controls;

namespace GSoft.Dynamite.LifeCycle.Core.RegistrationModules
{
    /// <summary>
    /// Life Cycle Registration Module
    /// </summary>
    public class LifeCycleRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Control Configuration
            builder.RegisterType<SchedulingControl>().As<ISchedulingControl>();
        }
    }
}
