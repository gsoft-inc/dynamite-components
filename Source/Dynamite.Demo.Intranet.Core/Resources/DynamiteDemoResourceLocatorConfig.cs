using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Globalization;

namespace Dynamite.Demo.Intranet.Core.Resources
{
    public class DynamiteDemoResourceLocatorConfig : IResourceLocatorConfig
    {
        private string[] resourceFileKeys = new string[1] { DynamiteDemoResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
         public DynamiteDemoResourceLocatorConfig()
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
