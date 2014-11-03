using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationTermDrivenPageSettingsInfoConfig : INavigationTermDrivenpageSettingsInfoConfig
    {
        private readonly NavigationTermDrivenPageSettingsInfos _basePublishingTermDrivenPageSettingsInfos;

        public NavigationTermDrivenPageSettingsInfoConfig(NavigationTermDrivenPageSettingsInfos baseTermDrivenPageSettingsInfos)
        {
            this._basePublishingTermDrivenPageSettingsInfos = baseTermDrivenPageSettingsInfos;
        }

        public IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos
        {
            get {
                return new List<TermDrivenPageSettingInfo>()
                {
                    // Be careful, put TermSets configuration before Terms 
                    {this._basePublishingTermDrivenPageSettingsInfos.NavigationTermSet()},
                    {this._basePublishingTermDrivenPageSettingsInfos.NavigationTermSetFrench()},
                    {this._basePublishingTermDrivenPageSettingsInfos.NewsTerm()},
                    {this._basePublishingTermDrivenPageSettingsInfos.AboutTerm()},
                };

            }        
        }
    }
}
