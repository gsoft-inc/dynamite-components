using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;

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
    }
}
