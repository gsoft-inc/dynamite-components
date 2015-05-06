using GSoft.Dynamite.Events;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Event receivers configuration for the navigation module
    /// </summary>
    public class NavigationEventReceiverInfos
    {
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeConfig">The content types configuration objects from the publishing module</param>
        public NavigationEventReceiverInfos(IPublishingContentTypeInfoConfig publishingContentTypeConfig)
        {
            this.publishingContentTypeConfig = publishingContentTypeConfig;
        }

        #region Browsable Item events

        /// <summary>
        /// The item added event for the <c>browsable</c> item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo BrowsableItemItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.BrowsableItem.ContentTypeId),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsableItemEvents" };

            return eventReceiver;
        }

        /// <summary>
        /// The item updated event for the <c>browsable</c> item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo BrowsableItemItemUpdated()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.BrowsableItem.ContentTypeId),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsableItemEvents" };

            return eventReceiver;
        }

        #endregion

        #region Target Content Page events

        /// <summary>
        /// The item added event for the target page content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TargetContentPageItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.BrowsablePage.ContentTypeId),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

            return eventReceiver;
        }

        /// <summary>
        /// The item updated event for the target page content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TargetContentPageUpdated()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.BrowsablePage.ContentTypeId),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

            return eventReceiver;
        }

        /// <summary>
        /// The item deleting event for the target page content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TargetContentPageDeleting()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.BrowsablePage.ContentTypeId),
                SPEventReceiverType.ItemDeleting) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

            return eventReceiver;
        }

        #endregion

        #region Target Content Item events

        /// <summary>
        /// The item added event for the target content item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TargetContentItemItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.TargetContentItem.ContentTypeId),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        /// <summary>
        /// The item updated event for the target content item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TargetContentItemItemUpdated()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.TargetContentItem.ContentTypeId),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        /// <summary>
        /// The item deleted event for the target content item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TargetContentItemItemDeleted()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.TargetContentItem.ContentTypeId),
                SPEventReceiverType.ItemDeleted) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        #endregion
    }
}
