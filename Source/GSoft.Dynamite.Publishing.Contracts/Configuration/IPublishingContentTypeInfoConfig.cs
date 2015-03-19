using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration for the creation of the Content Types
    /// </summary>
    public interface IPublishingContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create in the publishing module
        /// </summary>
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
