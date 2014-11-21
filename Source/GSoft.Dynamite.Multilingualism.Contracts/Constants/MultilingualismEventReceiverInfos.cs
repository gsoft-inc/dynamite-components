using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    public class MultilingualismEventReceiverInfos
    {
        public readonly PublishingContentTypeInfos publishingContentTypeInfos;

        public MultilingualismEventReceiverInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        public EventReceiverInfo TranslatableItemEventAdded()
        {
            return new EventReceiverInfo(this.publishingContentTypeInfos.TranslatableItem(),
                SPEventReceiverType.ItemAdded);
        }

        public EventReceiverInfo TranslatableItemEventUpdated()
        {
            return new EventReceiverInfo(this.publishingContentTypeInfos.TranslatableItem(),
                SPEventReceiverType.ItemUpdated);
        }


        public EventReceiverInfo TranslatablePageEventAddded()
        {
            return new EventReceiverInfo(this.publishingContentTypeInfos.TranslatablePage(),
                SPEventReceiverType.ItemAdded);
        }

        public EventReceiverInfo TranslatablePageEventUpdated()
        {
            // To avoid save conflicts, page events must be synchronous because of the method EnsurePage (PageHelper) which fires the ItemUpdated event.
            // When a page is added (by UI or by code) the fired event is the ItemUpdated event. The ItemAdded event is fired when page metadata have been filled.
            return new EventReceiverInfo(this.publishingContentTypeInfos.TranslatablePage(),
                SPEventReceiverType.ItemUpdated, SPEventReceiverSynchronization.Synchronous);
        }
    }
}
