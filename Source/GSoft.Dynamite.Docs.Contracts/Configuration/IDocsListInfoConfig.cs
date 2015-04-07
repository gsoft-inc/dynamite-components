using System;
using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    /// <summary>
    /// Lists configuration for the document management module
    /// </summary>
    public interface IDocsListInfoConfig
    {
        /// <summary>
        /// Property that return all the lists to create in the document management module
        /// </summary>
        IList<ListInfo> DocumentLibraries { get; }
    }
}
