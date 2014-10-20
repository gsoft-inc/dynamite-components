using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationTermDrivenPageSettingsInfoConfig : INavigationTermDrivenpageSettingsInfoConfig
    {
        private readonly NavigationTermDrivenPageSettingsInfos _basePublishingTermDrivenPageSettingsInfos;

        public NavigationTermDrivenPageSettingsInfoConfig(NavigationTermDrivenPageSettingsInfos baseTermDrivenPageSettingsInfos)
        {
            this._basePublishingTermDrivenPageSettingsInfos = baseTermDrivenPageSettingsInfos;
        }

        public IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos()
        {
            return new List<TermDrivenPageSettingInfo>()
            {
                {this._basePublishingTermDrivenPageSettingsInfos.NavigationTermSet()},
                {this._basePublishingTermDrivenPageSettingsInfos.NewsTerm()},
                {this._basePublishingTermDrivenPageSettingsInfos.AboutTerm()},
            };
        }
    }
}
