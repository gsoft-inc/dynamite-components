using System.Collections.Generic;
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

        /// <summary>
        /// Gets the image rendition information by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The image rendition information.</returns>
        ImageRenditionInfo GetImageRenditionInfoByName(string name);
    }
}
