using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Docs.Contracts.Configuration;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the document management module
    /// </summary>
    public class DocsContentTypeInfoConfig : IDocsContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create or configure in the document management module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var baseDocsContentTypes = new List<ContentTypeInfo>();
                return baseDocsContentTypes;
            }
        }
    }
}
