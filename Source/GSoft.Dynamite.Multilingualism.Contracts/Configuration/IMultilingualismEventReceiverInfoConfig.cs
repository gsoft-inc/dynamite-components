using System.Collections.Generic;
using GSoft.Dynamite.Events;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    /// <summary>
    /// Interface for event receivers configuration for the multilingualism module that apply on the <c>TanslatablePage</c> and <c>TranslatableItem</c> content types.
    /// </summary>
    public interface IMultilingualismEventReceiverInfoConfig
    {
        /// <summary>
        /// Property that return all the event receiver definitions to create or configure in the multilingualism module
        /// </summary>
        IList<EventReceiverInfo> EventReceivers { get; } 
    }
}
