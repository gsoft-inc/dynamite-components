using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface ICommonManagedPropertyInfosConfig
    {
        IList<ManagedPropertyInfo> ManagedProperties { get; } 
    }
}
