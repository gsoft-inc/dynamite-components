using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    public interface IMultilingualismEventReceiverInfoConfig
    {
        IList<EventReceiverInfo> EventReceivers { get; } 
    }
}
