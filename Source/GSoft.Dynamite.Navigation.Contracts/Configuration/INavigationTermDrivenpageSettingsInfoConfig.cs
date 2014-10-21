using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationTermDrivenpageSettingsInfoConfig
    {
        IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos { get; }
    }
}
