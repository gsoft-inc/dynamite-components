using System.Collections.Generic;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Contracts.Resources
{
    /// <summary>
    /// The resource locator configuration for the multilingualism module
    /// </summary>
    public class MultilingualismResourceLocatorConfig : IResourceLocatorConfig
    {
        private ICollection<string> resourceFileKeys = new List<string>() { MultilingualismResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
        public MultilingualismResourceLocatorConfig()
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
