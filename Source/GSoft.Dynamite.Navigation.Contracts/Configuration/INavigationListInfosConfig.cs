using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationListInfosConfig
    {
        IList<ListInfo> Lists { get; } 
    }
}
