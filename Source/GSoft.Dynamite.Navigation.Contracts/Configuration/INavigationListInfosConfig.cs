using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Lists configuration for the navigation module
    /// </summary>
    public interface INavigationListInfosConfig
    {
        /// <summary>
        /// Property that return all the lists to create or configure in the navigation module
        /// </summary>
        IList<ListInfo> Lists { get; } 
    }
}
