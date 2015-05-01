using System.Collections.Generic;
using GSoft.Dynamite.Docs.Contracts.Constants;
using GSoft.Dynamite.Globalization;

namespace GSoft.Dynamite.Docs.Contracts.Resources
{
    /// <summary>
    /// Resource locator configuration for the document management module
    /// </summary>
    public class DocsResourceLocatorConfig : IResourceLocatorConfig
    {
        private readonly ICollection<string> resourceFileKeys = new List<string>() { DocsResources.Global };
             
        /// <summary>
        /// File Keys
        /// </summary>
        public ICollection<string> ResourceFileKeys
        {
            get { return this.resourceFileKeys; }
        }
    }
}
