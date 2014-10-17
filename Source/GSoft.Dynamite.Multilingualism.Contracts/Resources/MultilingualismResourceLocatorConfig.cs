using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Contracts.Resources
{
    public class MultilingualismResourceLocatorConfig: IResourceLocatorConfig
    {
        private string[] resourceFileKeys = new string[1] { BaseMultilingualismResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
        public MultilingualismResourceLocatorConfig()
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
