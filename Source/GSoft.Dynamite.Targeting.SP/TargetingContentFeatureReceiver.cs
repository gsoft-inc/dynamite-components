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
        private ILogger logger;
        private IFieldHelper fieldHelper;
        private ICatalogHelper catalogHelper;
        private ITargetingContentConfig config;
        private IResourceLocator resourceLocator;
        private IContentTypeHelper contentTypeHelper;
        private IEventReceiverHelper eventReceiverHelper;

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
                    this.ResolveDependencies(scope);

                    // Fields, content types and event receivers are ensure on the site collection level
                    this.EnsureFields(web.Site);
                    this.EnsureContentTypes(web.Site);
                    this.EnsureEventReceivers(web.Site);

                    // Catalogs are ensured on the web level
                    this.EnsureCatalogs(web);
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
                    this.ResolveDependencies(scope);

                    // Event receivers are removed on the site collection level
                    this.RemoveEventReceivers(web.Site);
                }
            }
        }

        private void ResolveDependencies(IComponentContext scope)
        {
            this.logger = scope.Resolve<ILogger>();
            this.fieldHelper = scope.Resolve<IFieldHelper>();
            this.catalogHelper = scope.Resolve<ICatalogHelper>();
            this.resourceLocator = scope.Resolve<IResourceLocator>();
            this.contentTypeHelper = scope.Resolve<IContentTypeHelper>();
            this.eventReceiverHelper = scope.Resolve<IEventReceiverHelper>();
            this.config = scope.ResolveNamed<ITargetingContentConfig>(this.RegistrationName);
        }

        private void EnsureFields(SPSite site)
        {
            using (new Unsafe(site.RootWeb))
            {
                foreach (var field in this.config.Fields)
                {
                    this.logger.Info(
                        "Creating field '{0}' on URL '{1}'", 
                        field.InternalName, 
                        site.Url);

                    this.fieldHelper.EnsureField(site.RootWeb.Fields, field);
                }
            }
        }

        private void EnsureContentTypes(SPSite site)
        {
            foreach (var contentType in this.config.ContentTypes)
            {
                this.logger.Info(
                    "Creating content type {0} on site {1}", 
                    this.resourceLocator.Find(contentType.DisplayNameResourceKey), 
                    site.Url);

                this.contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, contentType);
            }
        }

        private void EnsureEventReceivers(SPSite site)
        {
            foreach (var eventReceiver in this.config.EventReceivers)
            {
                this.logger.Info(
                    "Provisioning event receiver for content type {0}",
                    this.resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                // If no assembly defined, assume it's in the executing assembly
                if (string.IsNullOrEmpty(eventReceiver.AssemblyName))
                {
                    eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                }

                this.eventReceiverHelper.AddContentTypeEventReceiverDefinition(site, eventReceiver);
            }
        }

        private void EnsureCatalogs(SPWeb web)
        {
            foreach (var catalog in this.config.Catalogs)
            {
                this.logger.Info(
                    "Creating catalog {0} on web {1}", 
                    catalog.WebRelativeUrl, 
                    web.Url);

                this.catalogHelper.EnsureCatalog(web, catalog);
            }
        }

        private void RemoveEventReceivers(SPSite site)
        {
            foreach (var eventReceiver in this.config.EventReceivers)
            {
                this.logger.Info(
                    "Deleting event receiver for content type {0}", 
                    this.resourceLocator.Find(eventReceiver.ContentType.DisplayNameResourceKey));

                // If no assembly defined, assume it's in the executing assembly
                if (string.IsNullOrEmpty(eventReceiver.AssemblyName))
                {
                    eventReceiver.AssemblyName = Assembly.GetExecutingAssembly().FullName;
                }

                this.eventReceiverHelper.DeleteContentTypeEventReceiverDefinition(site, eventReceiver);
            }
        }
    }
}
