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

        public EventReceiverInfo BrowsableItemItemEventAdded()
        {
            return new EventReceiverInfo(this.publishingContentTypeInfos.BrowsableItem(),
                SPEventReceiverType.ItemAdded);
        }

        public EventReceiverInfo BrowsableItemEventUpdated()
        {
            return new EventReceiverInfo(this.publishingContentTypeInfos.BrowsableItem(),
                SPEventReceiverType.ItemUpdated);
        }
    }
}
