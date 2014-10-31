using System.Collections.Generic;
using GSoft.Dynamite.Fields;

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
