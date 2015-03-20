using GSoft.Dynamite.Events;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Event receivers configuration for the multilingualism module
    /// </summary>
    public class MultilingualismEventReceiverInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfos">The content types settings form the publishing module</param>
        public MultilingualismEventReceiverInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        #region Translatable Item events

        /// <summary>
        /// The item added event for the translatable item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TranslatableItemEventAdded()
        {
            return new EventReceiverInfo(
                
                this.publishingContentTypeInfos.TranslatableItem(),
                SPEventReceiverType.ItemAdded);
        }

        /// <summary>
        /// The item updated event for the translatable item content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TranslatableItemEventUpdated()
        {
            return new EventReceiverInfo(
                this.publishingContentTypeInfos.TranslatableItem(),
                SPEventReceiverType.ItemUpdated);
        }

        #endregion

        #region Translatable Page items

        /// <summary>
        /// The item added event for the translatable page content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TranslatablePageEventAddded()
        {
            return new EventReceiverInfo(
                this.publishingContentTypeInfos.TranslatablePage(),
                SPEventReceiverType.ItemAdded);
        }

        /// <summary>
        /// The item updated event for the translatable page content type
        /// </summary>
        /// <returns>The event receiver info</returns>
        public EventReceiverInfo TranslatablePageEventUpdated()
        {
            // To avoid save conflicts, page events must be synchronous because of the method EnsurePage (PageHelper) which fires the ItemUpdated event.
            // When a page is added (by UI or by code) the fired event is the ItemUpdated event. The ItemAdded event is fired when page metadata have been filled.
            return new EventReceiverInfo(
                this.publishingContentTypeInfos.TranslatablePage(),
                SPEventReceiverType.ItemUpdated,
                SPEventReceiverSynchronization.Synchronous);
        }

        #endregion
    }
}
