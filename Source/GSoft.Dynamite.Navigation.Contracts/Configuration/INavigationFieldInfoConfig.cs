using System;
using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Fields configuration for the navigation module
    /// </summary>
    public interface INavigationFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the fields to create or configure in the navigation module
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
