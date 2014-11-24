using System.Collections.Generic;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationEventReceiverInfoConfig : INavigationEventReceiverInfoConfig
    {
        private readonly NavigationEventReceiverInfos navigationEventReceiverInfos;

        public NavigationEventReceiverInfoConfig(NavigationEventReceiverInfos navigationEventReceiverInfos)
        {
            this.navigationEventReceiverInfos = navigationEventReceiverInfos;
        }

        public IList<EventReceiverInfo> EventReceivers
        {
            // The collection in set by features depending on the solution type
            get { return new List<EventReceiverInfo>(); }
        }
    }
}
