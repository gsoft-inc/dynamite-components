using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    public interface IDocsFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<IFieldInfo> Fields { get; }
    }
}
