using GSoft.Dynamite.Events;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Search.Contracts.Constants
{
    /// <summary>
    /// The info about the event receivers for the search module.
    /// </summary>
    public class SearchEventReceiverInfos
    {
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeConfig">The content types configuration objects from the publishing module</param>
        public SearchEventReceiverInfos(IPublishingContentTypeInfoConfig publishingContentTypeConfig)
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
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Search.SP.Events.BrowsableItemEvents" };

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
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Search.SP.Events.BrowsableItemEvents" };

            return eventReceiver;
        }

        #endregion
    }
}
