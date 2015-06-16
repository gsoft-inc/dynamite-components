using System.Reflection;
using Autofac;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Security;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    public abstract class TargetingContentFeatureReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Gets the name of the registration for the 'ITargetingContentConfig' implementation.
        /// </summary>
        /// <value>
        /// The name of the registration.
        /// </value>
        public abstract string RegistrationName { get; }

        /// <summary>
        /// Feature activated event deploying catalogs (targeting module)
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;
            if (web != null)
            {
                using (var scope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var config = scope.ResolveNamed<ITargetingContentConfig>(this.RegistrationName);
                    EnsureFields(scope, config, web.Site);
                    EnsureContentTypes(scope, config, web.Site);
                    EnsureEventReceivers(scope, config, web.Site);
                    EnsureCatalogs(scope, config, web);
                }
            }
        }

        /// <summary>
        /// Removes event receivers for the targeting module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;
            if (web != null)
            {
                using (var scope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var config = scope.ResolveNamed<ITargetingContentConfig>(this.RegistrationName);
                    RemoveEventReceivers(scope, config, web.Site);
                }
            }
        }

        private static void EnsureFields(IComponentContext scope, ITargetingContentConfig config, SPSite site)
        {
            using (new Unsafe(site.RootWeb))
            {
                var logger = scope.Resolve<ILogger>();
                var fieldHelper = scope.Resolve<IFieldHelper>();

                foreach (var field in config.Fields)
                {
                    logger.Info("Creating field '{0}' on URL '{1}'", field.InternalName, site.Url);
                    fieldHelper.EnsureField(site.RootWeb.Fields, field);
                }
            }
        }

        private static void EnsureContentTypes(IComponentContext scope, ITargetingContentConfig config, SPSite site)
        {
            var logger = scope.Resolve<ILogger>();
            var resourceLocator = scope.Resolve<IResourceLocator>();
            var contentTypeHelper = scope.Resolve<IContentTypeHelper>();

            foreach (var contentType in config.ContentTypes)
            {
                logger.Info("Creating content type {0} on site {1}", resourceLocator.Find(contentType.DisplayNameResourceKey), site.Url);
                contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
            }
        }

        private static void EnsureEventReceivers(IComponentContext scope, ITargetingContentConfig config, SPSite site)
        {
            var logger = scope.Resolve<ILogger>();
            var resourceLocator = scope.Resolve<IResourceLocator>();
            var eventReceiverHelper = scope.Resolve<IEventReceiverHelper>();

            foreach (var eventReceiver in config.EventReceivers)
            {
                eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                eventReceiverHelper.AddContentTypeEventReceiverDefinition(site, eventReceiver);

                logger.Info("Provisioning event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));
            }
        }

        private static void EnsureCatalogs(IComponentContext scope, ITargetingContentConfig config, SPWeb web)
        {
            var logger = scope.Resolve<ILogger>();
            var catalogHelper = scope.Resolve<ICatalogHelper>();

            foreach (var catalog in config.Catalogs)
            {
                logger.Info("Creating catalog {0} on web {1}", catalog.WebRelativeUrl, web.Url);
                catalogHelper.EnsureCatalog(web, catalog);
            }
        }

        private static void RemoveEventReceivers(IComponentContext scope, ITargetingContentConfig config, SPSite site)
        {
            var logger = scope.Resolve<ILogger>();
            var resourceLocator = scope.Resolve<IResourceLocator>();
            var eventReceiverHelper = scope.Resolve<IEventReceiverHelper>();

            foreach (var eventReceiver in config.EventReceivers)
            {
                eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                eventReceiverHelper.DeleteContentTypeEventReceiverDefinition(site, eventReceiver);

                logger.Info("Deleting event receiver for content type {0}", resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));
            }
        }
    }
}
