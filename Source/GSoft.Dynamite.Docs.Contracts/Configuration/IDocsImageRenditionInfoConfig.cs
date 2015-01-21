using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Branding;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    /// <summary>
    /// Image Renditions configuration for the document management module
    /// </summary>
    public interface IDocsImageRenditionInfoConfig
    {
        /// <summary>
        /// Property that return all the image renditions to create or configure in the document management module
        /// </summary>
        IList<ImageRenditionInfo> ImageRenditions { get; }
    }
}
