using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.ContentTypes;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Search.Contracts.Configuration
{
    /// <summary>
    /// Interface for the base search content type info config.
    /// </summary>
    public interface ISearchContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create in the search module
        /// </summary>
        /// <returns>he fields</returns>
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
