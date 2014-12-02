using System.Collections.Generic;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Term driven pages settings configuration for the navigation module
    /// </summary>
    public interface INavigationTermDrivenpageSettingsInfoConfig
    {
        /// <summary>
        /// Property that return all the term driven page settings in the navigation module
        /// </summary>
        IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos { get; }
    }
}
