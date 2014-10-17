using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class BaseNavigationTermDrivenPageSettingsInfoConfig : IBaseNavigationTermDrivenpageSettingsInfoConfig
    {
        private readonly BaseNavigationTermDrivenPageSettingsInfos _basePublishingTermDrivenPageSettingsInfos;

        public BaseNavigationTermDrivenPageSettingsInfoConfig(BaseNavigationTermDrivenPageSettingsInfos baseTermDrivenPageSettingsInfos)
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
