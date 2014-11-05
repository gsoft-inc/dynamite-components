using System.Collections.Generic;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Resources
{
    public class NavigationResourceLocatorConfig: IResourceLocatorConfig
    {
        private ICollection<string> resourceFileKeys = new List<string> { NavigationResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationResourceLocatorConfig()
        {
        }

        /// <summary>
        /// File Keys
        /// </summary>
        public ICollection<string> ResourceFileKeys
        {
            get { return this.resourceFileKeys; }
        }
    }
}
