using System.Collections.Generic;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Term driven pages settings configuration for the navigation module
    /// </summary>
    public interface INavigationTermDrivenPageSettingsInfoConfig
    {
        /// <summary>
        /// Property that return all the term driven page settings in the navigation module
        /// </summary>
        IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos { get; }

        /// <summary>
        /// Gets the term driven page setting information by term from this configuration.
        /// </summary>
        /// <param name="term">The term information.</param>
        /// <returns>The term driven page setting information</returns>
        TermDrivenPageSettingInfo GetTermDrivenPageSettingInfoByTerm(TermInfo term);

        /// <summary>
        /// Gets the term driven page setting information by term set from this configuration.
        /// </summary>
        /// <param name="termSet">The term set information.</param>
        /// <returns>The term driven page setting information</returns>
        TermDrivenPageSettingInfo GetTermDrivenPageSettingInfoByTermSet(TermSetInfo termSet);
    }
}
