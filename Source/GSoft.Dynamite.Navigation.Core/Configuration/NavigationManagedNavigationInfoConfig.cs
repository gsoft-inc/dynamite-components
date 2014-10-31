using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationManagedNavigationInfoConfig : INavigationManagedNavigationInfoConfig
    {
        private readonly NavigationManagedNavigationInfos navigationManagedNavigationInfos;

        public NavigationManagedNavigationInfoConfig(NavigationManagedNavigationInfos navigationManagedNavigationInfos)
        {
            this.navigationManagedNavigationInfos = navigationManagedNavigationInfos;
        }

        public IList<ManagedNavigationInfo> NavigationSettings
        {
            get
            {
                return new List<ManagedNavigationInfo>()
                {
                    {this.navigationManagedNavigationInfos.ManagedNavigationSettingsEnglish},
                    {this.navigationManagedNavigationInfos.ManagedNavigationSettingsFrench}
                };
            }
        }
    }
}
