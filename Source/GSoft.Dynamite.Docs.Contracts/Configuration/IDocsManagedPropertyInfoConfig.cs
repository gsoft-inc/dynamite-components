using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    public interface IDocsManagedPropertyInfoConfig
    {
        IList<ManagedPropertyInfo> ManagedProperties { get; } 
    }
}
