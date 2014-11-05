using System.Collections;
using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Globalization;

namespace Dynamite.Demo.Intranet.Core.Resources
{
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
