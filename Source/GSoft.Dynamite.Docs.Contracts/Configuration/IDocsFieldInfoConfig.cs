using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    /// <summary>
    /// Fields configuration for the document management module
    /// </summary>
    public interface IDocsFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<IFieldInfo> Fields { get; }
    }
}
