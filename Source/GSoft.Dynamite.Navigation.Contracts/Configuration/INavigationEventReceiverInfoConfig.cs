using System.Collections.Generic;
using GSoft.Dynamite.Events;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Event receivers configuration for the navigation module
    /// </summary>
    public interface INavigationEventReceiverInfoConfig
    {
        /// <summary>
        /// Property that return all the event receivers to create or configure in the navigation module
        /// </summary>
        IList<EventReceiverInfo> EventReceivers { get; }
    }
}
