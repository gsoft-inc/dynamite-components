using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the migration module
    /// </summary>
    public class TargetingContentTypeInfoConfig : ITargetingContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create or configure in the migration module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                return new List<ContentTypeInfo>();
            }
        }

        /// <summary>
        /// Gets the content type from the ContentTypes property where the id of that content type is passed by parameter.
        /// </summary>
        /// <param name="contentTypeId">The unique identifier of the content type we are looking for.</param>
        /// <returns>
        /// The content type information.
        /// </returns>
        public ContentTypeInfo GetContentTypeById(SPContentTypeId contentTypeId)
        {
            return this.ContentTypes.Single(c => c.ContentTypeId.Equals(contentTypeId));
        }
    }
}
