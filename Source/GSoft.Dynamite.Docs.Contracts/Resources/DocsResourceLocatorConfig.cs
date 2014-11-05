using System.Collections.Generic;
using GSoft.Dynamite.Docs.Contracts.Constants;
using GSoft.Dynamite.Globalization;

namespace GSoft.Dynamite.Docs.Contracts.Resources
{
    public class DocsResourceLocatorConfig : IResourceLocatorConfig
    {
        private ICollection<string> resourceFileKeys = new List<string>() { DocsResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
        public DocsResourceLocatorConfig()
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
