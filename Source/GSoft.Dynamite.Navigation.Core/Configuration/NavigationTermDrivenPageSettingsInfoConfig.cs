using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Term driven pages settings configuration for the navigation module
    /// </summary>
    public class NavigationTermDrivenPageSettingsInfoConfig : INavigationTermDrivenpageSettingsInfoConfig
    {
        private readonly NavigationTermDrivenPageSettingsInfos _basePublishingTermDrivenPageSettingsInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="baseTermDrivenPageSettingsInfos">The term driven info objects configuration</param>
        public NavigationTermDrivenPageSettingsInfoConfig(NavigationTermDrivenPageSettingsInfos baseTermDrivenPageSettingsInfos)
        {
            this._basePublishingTermDrivenPageSettingsInfos = baseTermDrivenPageSettingsInfos;
        }

        /// <summary>
        /// Property that return all the term driven page settings in the navigation module
        /// </summary>
        public IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos
        {
            get
            {               
                return new List<TermDrivenPageSettingInfo>()
                {
                    // Be careful, put TermSets configuration before Terms 
                    this._basePublishingTermDrivenPageSettingsInfos.NavigationTermSet(),
                    this._basePublishingTermDrivenPageSettingsInfos.NavigationTermSetFrench(),
                    this._basePublishingTermDrivenPageSettingsInfos.NewsTerm(),
                };
            }        
        }
    }
}
