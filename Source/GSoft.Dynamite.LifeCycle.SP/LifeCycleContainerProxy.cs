using Autofac;
using GSoft.Dynamite.ServiceLocator;
using GSoft.Dynamite.ServiceLocator.AddOn;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.LifeCycle.SP
{
    /// <summary>
    /// Proxy service locator for the Dynamite Portal Publishing components
    /// </summary>
    internal class LifeCycleContainerProxy
    {
        /// <summary>
        /// This service locator is provided either 
        /// 1) by the only Container class currently available in the GAC 
        /// from the single DLL matching the pattern "*.ServiceLocator.DLL"
        /// or 
        /// 2) by the Container class from the DLL with a file name matching 
        /// the SPSite property bag value for the key "ServiceLocatorAssemblyName"
        /// In other words, Dynamite.Components modules must be loaded by
        /// a container class belonging to some Company.Project.ServiceLocator
        /// assembly.
        /// </summary>
        private static readonly ISharePointServiceLocator InnerLocator = new AddOnProvidedServiceLocator();

        /// <summary>
        /// Exposes the most-nested currently available lifetime scope.
        /// In an HTTP-request context, will return a shared per-request
        /// scope (allowing you to inject InstancePerSite, InstancePerWeb
        /// and InstancePerRequest-registered objects).
        /// Outside an HTTP-request context, will return the root application
        /// container itself (preventing you from injecting InstancePerSite,
        /// InstancePerWeb or InstancePerRequest objects).
        /// Do not dispose this scope, as it will be reused by others.
        /// </summary>
        public static ILifetimeScope Current
        {
            get
            {
                return InnerLocator.Current;
            }
        }

        /// <summary>
        /// Creates a new child lifetime scope that is as nested as possible,
        /// depending on the scope of the specified feature.
        /// In a SPSite or SPWeb-scoped feature context, will return a web-specific
        /// lifetime scope (allowing you to inject InstancePerSite and InstancePerWeb
        /// objects).
        /// In a SPFarm or SPWebApplication feature context, will return a child
        /// container of the root application container (preventing you from injecting
        /// InstancePerSite, InstancePerWeb or InstancePerRequest objects).
        /// Please dispose this lifetime scope when done (E.G. call this method from
        /// a using block).
        /// Prefer usage of this method versus resolving manually from the Current property.
        /// </summary>
        /// <param name="feature">The current feature that is requesting a child lifetime scope</param>
        /// <returns>A new child lifetime scope which should be disposed by the caller.</returns>
        public static ILifetimeScope BeginFeatureLifetimeScope(SPFeature feature)
        {
            return InnerLocator.BeginLifetimeScope(feature);
        }

        /// <summary>
        /// Creates a new child lifetime scope under the scope of the specified web
        /// (allowing you to inject InstancePerSite and InstancePerWeb objects).
        /// Please dispose this lifetime scope when done (E.G. call this method from
        /// a using block).
        /// Prefer usage of this method versus resolving manually from the Current property.
        /// </summary>
        /// <param name="web">The web</param>
        /// <returns>A new child lifetime scope which should be disposed by the caller.</returns>
        public static ILifetimeScope BeginWebLifetimeScope(SPWeb web)
        {
            return InnerLocator.BeginLifetimeScope(web);
        }
    }
}
