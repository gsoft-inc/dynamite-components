using System.Collections.Generic;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Navigation.Contracts.Configuration;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationListInfosConfig : INavigationListInfosConfig
    {
        public IList<ListInfo> Lists
        {        
            // The collection in set by features depending on the solution type
            get { return new List<ListInfo>(); }          
        }
    }
}
