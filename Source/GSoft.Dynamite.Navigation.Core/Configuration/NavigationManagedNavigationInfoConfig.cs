using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// The taxonomy managed navigation configuration for the navigation module
    /// </summary>
    public class NavigationManagedNavigationInfoConfig : INavigationManagedNavigationInfoConfig
    {
        private readonly NavigationManagedNavigationInfos navigationManagedNavigationInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="navigationManagedNavigationInfos">The managed navigation info objects configuration</param>
        public NavigationManagedNavigationInfoConfig(NavigationManagedNavigationInfos navigationManagedNavigationInfos)
        {
            this.navigationManagedNavigationInfos = navigationManagedNavigationInfos;
        }

        /// <summary>
        /// Property that return all the taxonomy navigation settings to configure in the navigation module
        /// </summary>
        public IList<ManagedNavigationInfo> NavigationSettings
        {
            get
            {
                return new List<ManagedNavigationInfo>()
                {
                    this.navigationManagedNavigationInfos.ManagedNavigationSettingsEnglish,
                    this.navigationManagedNavigationInfos.ManagedNavigationSettingsFrench
                };
            }
        }
    }
}
