using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Search.Contracts.Constants;

namespace GSoft.Dynamite.Search.Contracts.Resources
{
    /// <summary>
    /// Resource locator for the search module.
    /// </summary>
    public class SearchResourceLocatorConfig : IResourceLocatorConfig
    {
         private ICollection<string> resourceFileKeys = new List<string>() { SearchResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
         public SearchResourceLocatorConfig()
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
