using System.Collections.Generic;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationTermDrivenpageSettingsInfoConfig
    {
        IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos { get; }
    }
}
