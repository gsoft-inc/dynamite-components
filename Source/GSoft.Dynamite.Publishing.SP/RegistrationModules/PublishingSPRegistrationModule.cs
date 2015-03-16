using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Publishing.Contracts.WebParts;
using GSoft.Dynamite.Publishing.SP.WebParts.FilteredProductShowcaseWebPart;
using GSoft.Dynamite.Publishing.SP.WebParts.ReusableContentWebPart;

namespace GSoft.Dynamite.Publishing.SP.RegistrationModules
{  
    /// <summary>
    /// Portal Publishing Registration Module for the dependencies injection engine
    /// </summary>
    public class PublishingSPRegistrationModule : Module
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
            builder.RegisterType<FilteredProductShowcaseWebPart>().As<IFilteredProductShowcaseWebPart>().ExternallyOwned();
            builder.RegisterType<ReusableContentWebPart>().As<IReusableContentWebPart>().ExternallyOwned();
        }
    }
}
