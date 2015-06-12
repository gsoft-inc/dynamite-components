using System;
using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Targeting.Contracts.Configuration
{
    /// <summary>
    /// Interface for the base targeting field info config.
    /// </summary>
    public interface ITargetingFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the field to create in the publishing module
        /// </summary>
        /// <returns>he fields</returns>
        IList<BaseFieldInfo> Fields { get; }

        /// <summary>
        /// Gets the field by identifier.
        /// </summary>
        /// <param name="fieldId">The field identifier.</param>
        /// <returns>The base field information.</returns>
        BaseFieldInfo GetFieldById(Guid fieldId);
    }
}
