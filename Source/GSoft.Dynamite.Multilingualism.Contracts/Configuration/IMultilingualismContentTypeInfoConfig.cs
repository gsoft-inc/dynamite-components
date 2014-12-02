using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    /// <summary>
    /// Interface for content types settings for the multilingualism module. Override the configuration from the publishing module.
    /// </summary>
    public interface IMultilingualismContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create or configure in the multilingualism module
        /// </summary>
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
