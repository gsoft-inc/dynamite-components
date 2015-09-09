using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    /// <summary>
    /// Content types configuration for the document management module
    /// </summary>
    public interface IDocsContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create or configure in the document management module
        /// </summary>
        IList<ContentTypeInfo> ContentTypes { get; }

        /// <summary>
        /// Gets the content type from the ContentTypes property where the id of that content type is passed by parameter.
        /// </summary>
        /// <param name="contentTypeId">The unique identifier of the content type we are looking for.</param>
        /// <returns>
        /// The content type information.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">When the ContentTypes collection of this configuration does not have a content type with the proper identifier.</exception>
        ContentTypeInfo GetContentTypeById(SPContentTypeId contentTypeId);
    }
}
