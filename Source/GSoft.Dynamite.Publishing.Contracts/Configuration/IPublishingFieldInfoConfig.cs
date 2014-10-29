using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.FieldTypes;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Interface for the base publishing field info config.
    /// </summary>
    public interface IPublishingFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<IFieldInfo> Fields { get; }
    }
}
