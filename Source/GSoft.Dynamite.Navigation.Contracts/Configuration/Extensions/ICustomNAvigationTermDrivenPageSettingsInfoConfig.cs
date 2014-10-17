using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration.Extensions
{
    public interface ICustomNavigationTermDrivenPageSettingsInfoConfig
    {
        IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos();
    }
}
