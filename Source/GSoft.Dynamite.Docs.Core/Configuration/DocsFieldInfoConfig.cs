using System.Collections.Generic;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    /// <summary>
    /// Fields configuration for the document management module
    /// </summary>
    public class DocsFieldInfoConfig : IDocsFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the fields to create or configure in the document management module
        /// </summary>
        public IList<BaseFieldInfo> Fields 
        {
            get
            {
                return new List<BaseFieldInfo>();
            }
        }
    }
}
