using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Default Constructor
        /// </summary>
        public DocsImageRenditionInfoConfig()
        {
        }

        /// <summary>
        /// Property that return all the image renditions to create or configure in the document management module
        /// </summary>
        public IList<ImageRenditionInfo> ImageRenditions
        {
            get
            {
                var baseDocsImageRenditions = new List<ImageRenditionInfo>();

                // TODO: Add the image renditions info
                return baseDocsImageRenditions;
            }
        }
    }
}
