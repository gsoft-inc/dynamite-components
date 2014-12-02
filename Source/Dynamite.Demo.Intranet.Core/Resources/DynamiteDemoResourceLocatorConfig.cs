using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Globalization;

namespace Dynamite.Demo.Intranet.Core.Resources
{
    /// <summary>
    /// Resource locator for the Dynamite demo module. It's not an override of existing modules resources!
    /// </summary>
    public class DynamiteDemoResourceLocatorConfig : IResourceLocatorConfig
    {
        private ICollection<string> resourceFileKeys = new List<string>() { DynamiteDemoResources.Global };

        /// <summary>
        /// Default constructor
        /// </summary>
        public DynamiteDemoResourceLocatorConfig()
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
