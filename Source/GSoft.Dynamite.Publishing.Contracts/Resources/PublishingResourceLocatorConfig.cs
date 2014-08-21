using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Portal.Core.Resources
{
    /// <summary>
    /// Configuration to know how to find the Portal Resources files
    /// </summary>
    public class PublishingResourceLocatorConfig : IResourceLocatorConfig
    {
        private string[] resourceFileKeys = new string[1] { BaseResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
        public PublishingResourceLocatorConfig()
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
