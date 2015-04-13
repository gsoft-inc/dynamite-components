using System;
using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    /// <summary>
    /// Interface for re-implementation of the base publishing field info config to add multilingualism site column
    /// </summary>
    public interface IMultilingualismFieldInfoConfig
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
