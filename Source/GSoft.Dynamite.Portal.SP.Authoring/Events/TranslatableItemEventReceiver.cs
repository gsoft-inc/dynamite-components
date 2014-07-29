using Autofac;
using GSoft.Dynamite.Portal.Contracts.Utils;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.SP.Authoring.Events
{
    /// <summary>
    /// Translatable item content type event receiver
    /// </summary>
    public class TranslatableItemEventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// Asynchronous After event that occurs after a new item has been added to its containing object.
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            this.EventFiringEnabled = false;

            using (var childScope = AuthoringContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                var contentAssociationHelper = childScope.Resolve<IContentAssociation>();

                // Set source association unique identifier
                contentAssociationHelper.SetSourceGuid(properties.ListItem);

                // Set friendly URL slug for navigation
                contentAssociationHelper.SetFriendlyUrlSlug(properties.ListItem);

                // Set the translation language for the detected language managed property
                contentAssociationHelper.SetTranslationLanguage(properties.ListItem);
            }

            this.EventFiringEnabled = true;
        }

        /// <summary>
        /// Asynchronous After event that occurs after an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties" /> object that represents properties of the event handler.</param>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            this.EventFiringEnabled = false;

            using (var childScope = AuthoringContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                var contentAssociationHelper = childScope.Resolve<IContentAssociation>();

                // Set friendly URL slug for navigation
                contentAssociationHelper.SetFriendlyUrlSlug(properties.ListItem);

                // Set the translation language for the detected language managed property
                contentAssociationHelper.SetTranslationLanguage(properties.ListItem);
            }

            this.EventFiringEnabled = true;
        }
    }
}
