using System;
using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Targeting.Contracts.Configuration
{
    /// <summary>
    /// Fields configuration for the targeting module
    /// </summary>
    public interface ITargetingFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<BaseFieldInfo> Fields { get; }

        /// <summary>
        /// Gets the field by identifier.
        /// </summary>
        /// <param name="fieldId">The field identifier.</param>
        /// <returns>The base field information.</returns>
        BaseFieldInfo GetFieldById(Guid fieldId);
    }
}
