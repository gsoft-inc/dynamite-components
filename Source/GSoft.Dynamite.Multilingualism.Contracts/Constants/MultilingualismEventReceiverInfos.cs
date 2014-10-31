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
    }
}
