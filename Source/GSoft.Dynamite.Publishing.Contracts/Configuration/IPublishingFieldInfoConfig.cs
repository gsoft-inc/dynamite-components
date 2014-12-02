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
        /// Property that return all the field to create in the publishing module
        /// </summary>
        /// <returns>he fields</returns>
        IList<IFieldInfo> Fields { get; }
    }
}
