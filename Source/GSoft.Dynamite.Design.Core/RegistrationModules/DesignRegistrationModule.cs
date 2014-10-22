﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Design.Core.Configuration;

namespace GSoft.Dynamite.Design.Core.RegistrationModules
{
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
