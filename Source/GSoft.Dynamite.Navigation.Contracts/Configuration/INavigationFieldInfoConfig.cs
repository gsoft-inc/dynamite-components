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
    }
}
