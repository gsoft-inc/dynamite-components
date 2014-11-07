using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingManagedPropertyInfosConfig
    {
        IList<ManagedPropertyInfo> ManagedProperties { get; } 
    }
}
