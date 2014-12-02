using System.Collections.Generic;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Event receivers configuration for the navigation module
    /// </summary>
    public class NavigationEventReceiverInfoConfig : INavigationEventReceiverInfoConfig
    {
        private readonly NavigationEventReceiverInfos navigationEventReceiverInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="navigationEventReceiverInfos">The event receivers info objects configuration</param>
        public NavigationEventReceiverInfoConfig(NavigationEventReceiverInfos navigationEventReceiverInfos)
        {
            this.navigationEventReceiverInfos = navigationEventReceiverInfos;
        }

        /// <summary>
        /// Property that return all the event receivers to create or configure in the navigation module
        /// </summary>
        public IList<EventReceiverInfo> EventReceivers
        {
            // The collection in set by features depending on the solution type
            get { return new List<EventReceiverInfo>(); }
        }
    }
}
