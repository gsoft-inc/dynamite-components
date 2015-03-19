using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.ContentTypes;

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
    }
}
