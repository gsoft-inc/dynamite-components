using System.Collections.Generic;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration for the Faceted Navigation settings. Used with OOTB refinements panel Web Part.
    /// </summary>
    public interface IPublishingFacetedNavigationInfoConfig
    {
        /// <summary>
        /// Property that return all the faceted navigation settings to use in the publishing module
        /// </summary>
        IList<FacetedNavigationInfo> FacetedNavigationInfos { get; }

        /// <summary>
        /// Gets the faceted navigation information by term information from this configuration.
        /// </summary>
        /// <param name="term">The term information.</param>
        /// <returns>The faceted navigation information</returns>
        FacetedNavigationInfo GetFacetedNavigationInfoByTerm(TermInfo term);
    }
}
