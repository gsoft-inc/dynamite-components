using System.Collections.Generic;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// The taxonomy managed navigation configuration for the navigation module
    /// </summary>
    public interface INavigationManagedNavigationInfoConfig
    {
        /// <summary>
        /// Property that return all the taxonomy navigation settings to configure in the navigation module
        /// </summary>
        IList<ManagedNavigationInfo> NavigationSettings { get; }
    }
}
