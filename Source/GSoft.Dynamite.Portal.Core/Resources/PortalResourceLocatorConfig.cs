using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Contracts.Constants;

namespace GSoft.Dynamite.Portal.Core.Resources
{
    /// <summary>
    /// Configuration to know how to find the Portal Resources files
    /// </summary>
    public class PortalResourceLocatorConfig : IResourceLocatorConfig
    {
        private string[] resourceFileKeys = new string[1] { PortalResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
        public PortalResourceLocatorConfig()
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
