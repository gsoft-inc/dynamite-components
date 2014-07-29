using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Portal.Contracts.Factories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.SP.Authoring.Features.ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("cec4140d-ced5-4248-b77d-7d049367707f")]
    public class ContentTypesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event handler for feature activation
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            using (var featureScope = AuthoringContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var contentTypeFactory = featureScope.Resolve<IContentTypeFactory>();

                if (site != null)
                {
                    // Create Item Content Types
                    contentTypeFactory.CreateBrowsableItem(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateTranslatableItem(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateSchedulableItem(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateMenuManageableContentItem(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateContentItem(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateNewsItem(site.RootWeb.ContentTypes);
                    contentTypeFactory.CreateNodeDescriptionItem(site.RootWeb.ContentTypes);
                } 
            }
        }
    }
}
