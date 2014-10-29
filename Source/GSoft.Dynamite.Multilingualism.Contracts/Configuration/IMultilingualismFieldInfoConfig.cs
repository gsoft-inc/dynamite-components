using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.FieldTypes;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    public interface IMultilingualismFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<IFieldInfo> Fields { get; }
    }
}
