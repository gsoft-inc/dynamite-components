using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Gets the image rendition information by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The image rendition information.
        /// </returns>
        public ImageRenditionInfo GetImageRenditionInfoByName(string name)
        {
            return this.ImageRenditions.Single(
                rendition => rendition.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
