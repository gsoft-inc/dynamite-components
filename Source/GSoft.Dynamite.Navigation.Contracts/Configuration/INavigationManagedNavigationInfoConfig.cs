using System.Collections.Generic;
using System.Globalization;

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

        /// <summary>
        /// Gets the managed navigation information by culture from this configuration.
        /// </summary>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>The managed navigation information</returns>
        ManagedNavigationInfo GetManagedNavigationInfoByCulture(CultureInfo cultureInfo);
    }
}
