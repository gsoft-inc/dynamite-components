using System.Collections.Generic;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Lists configuration for the navigation module
    /// </summary>
    public class NavigationListInfosConfig : INavigationListInfosConfig
    {
        private readonly NavigationListInfos navigationListInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="navigationListInfos">The list info objects configuration</param>
        public NavigationListInfosConfig(NavigationListInfos navigationListInfos)
        {
            this.navigationListInfos = navigationListInfos;
        }

        /// <summary>
        /// Property that return all the lists to create or configure in the navigation module
        /// </summary>
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
