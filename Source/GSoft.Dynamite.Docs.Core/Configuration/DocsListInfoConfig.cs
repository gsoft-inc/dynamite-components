using System;
using System.Collections.Generic;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    /// <summary>
    /// Lists configuration for the document management module
    /// </summary>
    public class DocsListInfoConfig : IDocsListInfoConfig
    {
        /// <summary>
        /// Property that return all the lists to create in the document management module
        /// </summary>
        public IList<ListInfo> DocumentLibraries
        {
            get
            {
                return new List<ListInfo>();
            }
        }
    }
}
