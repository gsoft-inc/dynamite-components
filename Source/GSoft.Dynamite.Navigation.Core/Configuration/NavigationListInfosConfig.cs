using System.Collections.Generic;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationListInfosConfig : INavigationListInfosConfig
    {
        private readonly NavigationListInfos navigationListInfos;

        public NavigationListInfosConfig(NavigationListInfos navigationListInfos)
        {
            this.navigationListInfos = navigationListInfos;
        }

        public IList<ListInfo> Lists
        {        
            // The collection in set by features depending on the solution type
            get
            {
                return new List<ListInfo>()
                {
                    this.navigationListInfos.ContentPages,
                    this.navigationListInfos.PagesLibrary
                };
            }          
        }
    }
}
