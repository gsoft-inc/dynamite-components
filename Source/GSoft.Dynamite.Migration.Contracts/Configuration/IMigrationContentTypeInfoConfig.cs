using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;

namespace GSoft.Dynamite.Migration.Contracts.Configuration
{
    /// <summary>
    /// Content types configuration for the migration module
    /// </summary>
    public interface IMigrationContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create or configure in the document management module
        /// </summary>
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
