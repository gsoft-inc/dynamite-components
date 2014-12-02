using GSoft.Dynamite.Events;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Event receivers configuration for the navigation module
    /// </summary>
    public class NavigationEventReceiverInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfos">The content types configuration objects from the publishing module</param>
        public NavigationEventReceiverInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        #region Browsable Item events

        /// <summary>
        /// The item added event for the <c>browsable</c> item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo BrowsableItemItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeInfos.BrowsableItem(),
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
                this.publishingContentTypeInfos.BrowsableItem(),
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
                this.publishingContentTypeInfos.BrowsablePage(),
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
                this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

            return eventReceiver;
        }

        /// <summary>
        /// The item deleted event for the target page content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TargetContentPageDeleted()
        {
            var eventReceiver = new EventReceiverInfo(
                this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemDeleted) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

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
                this.publishingContentTypeInfos.TargetContentItem(),
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
                this.publishingContentTypeInfos.TargetContentItem(),
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
                this.publishingContentTypeInfos.TargetContentItem(),
                SPEventReceiverType.ItemDeleted) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        #endregion
    }
}
