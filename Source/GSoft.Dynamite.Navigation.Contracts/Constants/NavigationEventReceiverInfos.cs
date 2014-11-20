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

        public EventReceiverInfo BrowsablePageItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsablePageEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo BrowsablePageItemUpdated()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemUpdated) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsablePageEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo BrowsablePageItemDeleted()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.BrowsablePage(),
                SPEventReceiverType.ItemDeleted) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.BrowsablePageEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo TargetContentItemItemDeleted()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.TargetContentItem(),
                SPEventReceiverType.ItemDeleted) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo TargetContentItemItemAdded()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.TargetContentItem(),
                SPEventReceiverType.ItemAdded) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }

        public EventReceiverInfo TargetContentItemItemDeleting()
        {
            var eventReceiver = new EventReceiverInfo(this.publishingContentTypeInfos.TargetContentItem(),
                SPEventReceiverType.ItemDeleting) { ClassName = "GSoft.Dynamite.Navigation.SP.Events.TargetContentItemEvents" };

            return eventReceiver;
        }
    }
}
