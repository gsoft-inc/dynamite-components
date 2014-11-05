using System.Collections.Generic;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class MultilingualismEventReceiverInfoConfig : IMultilingualismEventReceiverInfoConfig
    {
        private readonly MultilingualismEventReceiverInfos eventEventReceiverInfos;

        public MultilingualismEventReceiverInfoConfig(MultilingualismEventReceiverInfos eventEventReceiverInfos)
        {
            this.eventEventReceiverInfos = eventEventReceiverInfos;
        }

        public IList<EventReceiverInfo> EventReceivers
        {
            get
            {
                return new List<EventReceiverInfo>()
                {
                    {this.eventEventReceiverInfos.TranslatableItemEventAdded()},
                    {this.eventEventReceiverInfos.TranslatableItemEventUpdated()},
                    {this.eventEventReceiverInfos.TranslatablePageEventAdded()},
                    {this.eventEventReceiverInfos.TranslatablePageEventUpdated()},
                };
            }
        }
    }
}
