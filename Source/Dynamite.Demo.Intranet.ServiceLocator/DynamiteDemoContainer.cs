using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.ServiceLocator;
using Microsoft.SharePoint;

namespace Dynamite.Demo.Intranet.ServiceLocator
{
    public class DynamiteDemoContainer : ISharePointServiceLocatorAccessor
    {
        private const string AppName = "Dynamite.Demo.Intranet";

        private static readonly ISharePointServiceLocator innerServiceLocator = new SharePointServiceLocator(AppName, fileName => fileName.Contains(AppName) || fileName.Contains("GSoft.Dynamite.Publishing") || fileName.Contains("GSoft.Dynamite.Multilingualism"));

        /// <summary>
        /// Exposes the inner service locator through the ISharePointServiceLocatorAccessor interface,
        /// providing this locator as THE container to use for Dynamite component modules.
        /// </summary>
        public static ISharePointServiceLocator ServiceLocatorInstance
        {
            get
            {
                return innerServiceLocator;
            }
        }

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
                return innerServiceLocator.Current;
            }
        }

        /// <summary>
        /// Creates a new child lifetime scope that is as nested as possible,
        /// depending on the scope of the specified feature.
        /// In a SPSite or SPWeb-scoped feature context, will return a web-specific
        /// lifetime scope (allowing you to inject InstancePerSite and InstancePerWeb
        /// objects).
        /// In a SPFarm or SPWebApplication feature context, this method will throw
        /// an exception of type <see cref="InvalidOperationException"/>. Dynamite components
        /// must be configured under a specific SPSite's scope.
        /// Please dispose this lifetime scope when done (E.G. call this method from
        /// a using block).
        /// Prefer usage of this method versus resolving individual dependencies from the 
        /// ISharePointServiceLocator.Current property.
        /// </summary>
        /// <param name="feature">The current feature that is requesting a child lifetime scope</param>
        /// <returns>A new child lifetime scope which should be disposed by the caller.</returns>
        public static ILifetimeScope BeginFeatureLifetimeScope(SPFeature feature)
        {
            return innerServiceLocator.BeginLifetimeScope(feature);
        }

        /// <summary>
        /// Creates a new child lifetime scope under the scope of the specified web
        /// (allowing you to inject InstancePerSite and InstancePerWeb objects).
        /// Please dispose this lifetime scope when done (E.G. call this method from
        /// a using block).
        /// Prefer usage of this method versus resolving manually from the Current property.
        /// </summary>
        /// <param name="web">The current web from which we are requesting a child lifetime scope</param>
        /// <returns>A new child lifetime scope which should be disposed by the caller.</returns>
        public static ILifetimeScope BeginWebLifetimeScope(SPWeb web)
        {
            return innerServiceLocator.BeginLifetimeScope(web);
        }

        ISharePointServiceLocator ISharePointServiceLocatorAccessor.ServiceLocatorInstance
        {
            get { return ServiceLocatorInstance; }
        }
    }
}
