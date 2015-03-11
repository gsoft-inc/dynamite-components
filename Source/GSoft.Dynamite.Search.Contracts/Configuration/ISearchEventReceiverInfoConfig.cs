using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Events;

namespace GSoft.Dynamite.Search.Contracts.Configuration
{
    /// <summary>
    /// Event receivers configuration for the search module
    /// </summary>
    public interface ISearchEventReceiverInfoConfig
    {
        /// <summary>
        /// Property that return all the event receivers to create or configure in the navigation module
        /// </summary>
        IList<EventReceiverInfo> EventReceivers { get; }
    }
}
