using System;
using System.Collections.Generic;
using GSoft.Dynamite.Events;

namespace GSoft.Dynamite.Targeting.Contracts.Configuration
{
    /// <summary>
    /// Event receivers configuration for the targeting module
    /// </summary>
    public interface ITargetingEventReceiverInfoConfig
    {
        /// <summary>
        /// Property that return all the event receivers to create or configure in the navigation module
        /// </summary>
        IList<EventReceiverInfo> EventReceivers { get; }
    }
}
