using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;

namespace GSoft.Dynamite.Search.Core.Configuration
{
    /// <summary>
    /// Event receivers configuration for the search module
    /// </summary>
    public class SearchEventReceiverInfoConfig : ISearchEventReceiverInfoConfig
    {
        private readonly SearchEventReceiverInfos searchEventReceiverInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="searchEventReceiverInfos">The event receivers info objects configuration</param>
        public SearchEventReceiverInfoConfig(SearchEventReceiverInfos searchEventReceiverInfos)
        {
            this.searchEventReceiverInfos = searchEventReceiverInfos;
        }

        /// <summary>
        /// Property that return all the event receivers to create or configure in the search module
        /// </summary>
        public IList<EventReceiverInfo> EventReceivers
        {
            // The collection in set by features depending on the solution type
            get { return new List<EventReceiverInfo>(); }
        }
    }
}
