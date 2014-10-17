using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Resources
{
    public class NavigationResourceLocatorConfig: IResourceLocatorConfig
    {
        private string[] resourceFileKeys = new string[1] { BaseNavigationResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationResourceLocatorConfig()
        {
        }

        /// <summary>
        /// File Keys
        /// </summary>
        public string[] ResourceFileKeys
        {
            get { return this.resourceFileKeys; }
        }
    }
}
