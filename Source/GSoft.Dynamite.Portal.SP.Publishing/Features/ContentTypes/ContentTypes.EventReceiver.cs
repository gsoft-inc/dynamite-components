using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Portal.Contracts.Factories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.SP.Publishing.Features.ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("433b9665-c8a9-40ba-b505-7cbcc2e6ab75")]
    public class ContentTypesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event handler for feature activation
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeFactory = featureScope.Resolve<IContentTypeFactory>();

                    // Create Page Content Types
                    contentTypeFactory.CreateTranslatablePage(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateContentPage(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateNewsPage(site.RootWeb.ContentTypes);
                }
            }
        }
    }
}
