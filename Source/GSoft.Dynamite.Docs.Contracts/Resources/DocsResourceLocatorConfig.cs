using GSoft.Dynamite.Docs.Contracts.Constants;
using GSoft.Dynamite.Globalization;

namespace GSoft.Dynamite.Docs.Contracts.Resources
{
    public class DocsResourceLocatorConfig : IResourceLocatorConfig
    {
         private string[] resourceFileKeys = new string[1] { DocsResources.Global };
             
        /// <summary>
        /// Default constructor
        /// </summary>
         public DocsResourceLocatorConfig()
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
