using System.Collections.Generic;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Docs.Contracts.Configuration;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    /// <summary>
    /// Image Renditions configuration for the document management module
    /// </summary>
    public class DocsImageRenditionInfoConfig : IDocsImageRenditionInfoConfig
    {
        /// <summary>
        /// Property that return all the image renditions to create or configure in the document management module
        /// </summary>
        public IList<ImageRenditionInfo> ImageRenditions
        {
            get
            {
                return new List<ImageRenditionInfo>();
            }
        }
    }
}
