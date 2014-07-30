using Autofac;
using GSoft.Dynamite.Portal.Contracts.Factories;
using GSoft.Dynamite.Portal.SP.Authoring.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.SP.Authoring
{
    public class AuthoringRegistrationModule : Module
    {  
        /// <summary>
        /// Registers the modules type bindings
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            // Provide the translatable item event receiver class info to Portal.Core utils
            builder.RegisterType<TranslatableItemEventReceiverAssemblyDetails>().As<ITranslatableItemEventReceiverAssemblyDetails>();
        }
    }
}
