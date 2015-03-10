using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace GSoft.Dynamite.Search.SP.RegistrationModules
{
    /// <summary>
    /// Portal Search Registration Module for the dependencies injection engine
    /// </summary>
    public class SearchSPRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}
