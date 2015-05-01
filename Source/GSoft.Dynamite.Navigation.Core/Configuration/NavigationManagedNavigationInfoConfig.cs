using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// The taxonomy managed navigation configuration for the navigation module
    /// </summary>
    public class NavigationManagedNavigationInfoConfig : INavigationManagedNavigationInfoConfig
    {
        private readonly ICommonTaxonomyConfig commonTaxonomyConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="commonTaxonomyConfig">The managed navigation info objects configuration</param>
        public NavigationManagedNavigationInfoConfig(ICommonTaxonomyConfig commonTaxonomyConfig)
        {
            this.commonTaxonomyConfig = commonTaxonomyConfig;
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
                    this.ManagedNavigationSettingsEnglish,
                    this.ManagedNavigationSettingsFrench
                };
            }
        }

        private ManagedNavigationInfo ManagedNavigationSettingsEnglish
        {
            get
            {
                return new ManagedNavigationInfo(
                    this.commonTaxonomyConfig.GetTermSetInfoById(CommonTermSetInfo.EnglishNavigation.Id),
                    this.commonTaxonomyConfig.GetTermGroupInfoById(CommonTermGroupInfo.Navigation.Id),
                    new CultureInfo(1033));
            }
        }

        private ManagedNavigationInfo ManagedNavigationSettingsFrench
        {
            get
            {
                return new ManagedNavigationInfo(
                    this.commonTaxonomyConfig.GetTermSetInfoById(CommonTermSetInfo.FrenchNavigation.Id),
                    this.commonTaxonomyConfig.GetTermGroupInfoById(CommonTermGroupInfo.Navigation.Id),
                    new CultureInfo(1036));
            }
        }

        /// <summary>
        /// Gets the managed navigation information by culture from this configuration.
        /// </summary>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>
        /// The managed navigation information
        /// </returns>
        public ManagedNavigationInfo GetManagedNavigationInfoByCulture(CultureInfo cultureInfo)
        {
            return this.NavigationSettings.Single(s => s.AssociatedLanguage.Equals(cultureInfo));
        }
    }
}
