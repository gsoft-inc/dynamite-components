using System.Collections.Generic;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Event receivers configuration for the multilingualism module that apply on the <c>TanslatablePage</c> and <c>TranslatableItem</c> content types.
    /// </summary>
    public class MultilingualismEventReceiverInfoConfig : IMultilingualismEventReceiverInfoConfig
    {
        private readonly MultilingualismEventReceiverInfos eventEventReceiverInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="eventEventReceiverInfos">The event receivers settings from the multilingualism module</param>
        public MultilingualismEventReceiverInfoConfig(MultilingualismEventReceiverInfos eventEventReceiverInfos)
        {
            this.eventEventReceiverInfos = eventEventReceiverInfos;
        }

        /// <summary>
        /// Property that return all the event receiver definitions to create or configure in the multilingualism module
        /// </summary>
        public IList<EventReceiverInfo> EventReceivers
        {
            get
            {
                return new List<EventReceiverInfo>()
                {
                    this.eventEventReceiverInfos.TranslatableItemEventAdded(),
                    this.eventEventReceiverInfos.TranslatableItemEventUpdated(),
                    this.eventEventReceiverInfos.TranslatablePageEventAddded(),
                    this.eventEventReceiverInfos.TranslatablePageEventUpdated(),
                };
            }
        }
    }
}
