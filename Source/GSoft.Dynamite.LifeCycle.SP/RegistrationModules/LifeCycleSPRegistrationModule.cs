using System;
using Autofac;
using GSoft.Dynamite.LifeCycle.Contracts.WebParts;
using GSoft.Dynamite.LifeCycle.SP.WebParts.ContentBySearchSchedule;
using GSoft.Dynamite.LifeCycle.SP.WebParts.SearchResultsSchedule;

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
            builder.RegisterType<SearchResultsSchedule>().As<ISearchResultsSchedule>().ExternallyOwned();
        }
    }
}