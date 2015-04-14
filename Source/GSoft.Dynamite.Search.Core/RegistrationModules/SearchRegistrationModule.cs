using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;
using GSoft.Dynamite.Search.Contracts.Resources;
using GSoft.Dynamite.Search.Contracts.Services;
using GSoft.Dynamite.Search.Core.Configuration;
using GSoft.Dynamite.Search.Core.Services;

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
            // Resource Locator
            builder.RegisterType<SearchResourceLocatorConfig>().As<IResourceLocatorConfig>();
            builder.RegisterType<SearchResourceLocatorConfig>().Named<IResourceLocatorConfig>("search");

            // Fields
            builder.RegisterType<SearchFieldInfoConfig>().As<ISearchFieldInfoConfig>();
            builder.RegisterType<SearchFieldInfoConfig>().Named<ISearchFieldInfoConfig>("search");

            // Content Types
            builder.RegisterType<SearchContentTypeInfoConfig>().As<ISearchContentTypeInfoConfig>();
            builder.RegisterType<SearchContentTypeInfoConfig>().Named<ISearchContentTypeInfoConfig>("search");

            // Managed properties
            builder.RegisterType<SearchManagedPropertyInfoConfig>().As<ICommonManagedPropertyConfig>();
            builder.RegisterType<SearchManagedPropertyInfoConfig>().Named<ICommonManagedPropertyConfig>("search");

            // Events Receivers
            builder.RegisterType<SearchEventReceiverInfoConfig>().As<ISearchEventReceiverInfoConfig>();
            builder.RegisterType<SearchEventReceiverInfoConfig>().Named<ISearchEventReceiverInfoConfig>("search");

            // Configuration Values
            builder.RegisterType<SearchEventReceiverInfos>();

            // Services
            builder.RegisterType<BrowserTitleBuilderService>().As<IBrowserTitleBuilderService>();
        }
    }
}
