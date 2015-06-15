using System;
using System.Collections.Generic;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Targeting.Contracts.Configuration;

namespace GSoft.Dynamite.Targeting.Core.Configuration
{
    /// <summary>
    /// Event receivers configuration for the targeting module
    /// </summary>
    public class TargetingEventReceiverInfoConfig : ITargetingEventReceiverInfoConfig
    {
        /// <summary>
        /// Property that return all the event receivers to create or configure in the targeting module
        /// </summary>
        public IList<EventReceiverInfo> EventReceivers
        {
            get
            {
                return new List<EventReceiverInfo>();
            }
        }
    }
}
