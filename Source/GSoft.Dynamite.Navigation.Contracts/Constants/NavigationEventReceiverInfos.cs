using GSoft.Dynamite.Events;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationEventReceiverInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        public NavigationEventReceiverInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        #region Browsable Item events

        public EventReceiverInfo BrowsableItemItemAdded()
        {
            var eventReceiver =  new EventReceiverInfo(this.publishingContentTypeInfos.BrowsableItem(),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsableItemEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo BrowsableItemItemUpdated()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.BrowsableItem(),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsableItemEvents" };

            return eventReceiver;
        }

        #endregion

        #region Target Content Page events

        public EventReceiverInfo TargetContentPageItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo TargetContentPageUpdated()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo TargetContentPageDeleted()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemDeleted) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentPageEvents" };

            return eventReceiver;
        }

        #endregion

        #region Target Content Item events


        public EventReceiverInfo TargetContentItemItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.TargetContentItem(),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo TargetContentItemItemUpdated()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.TargetContentItem(),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo TargetContentItemItemDeleted()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.TargetContentItem(),
                SPEventReceiverType.ItemDeleted) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        #endregion
    }
}
