using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;
using GSoft.Dynamite.Search.Core.Configuration;

namespace GSoft.Dynamite.Search.Core.RegistrationModules
{
    /// <summary>
    /// Portal solution registration module for dependencies injection engine
    /// </summary>
    public class SearchRegistrationModule : Module
    {
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Fields
            builder.RegisterType<SearchFieldInfoConfig>().As<ISearchFieldInfoConfig>();
            builder.RegisterType<SearchFieldInfoConfig>().Named<ISearchFieldInfoConfig>("search");

            // Configuration Values
            builder.RegisterType<SearchFieldInfos>();
        }
    }
}
