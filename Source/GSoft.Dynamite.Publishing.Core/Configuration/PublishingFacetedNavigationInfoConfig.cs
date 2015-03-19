using System.Collections.Generic;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the Faceted Navigation settings. Used with OOTB refinements panel Web Part.
    /// </summary>
    public class PublishingFacetedNavigationInfoConfig : IPublishingFacetedNavigationInfoConfig
    {
        private readonly PublishingFacetedNavigationInfos publishingFacetedNavigationInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingFacetedNavigationInfos">The faceted navigation info objects configuration</param>
        public PublishingFacetedNavigationInfoConfig(PublishingFacetedNavigationInfos publishingFacetedNavigationInfos)
        {
            this.publishingFacetedNavigationInfos = publishingFacetedNavigationInfos;
        }

        /// <summary>
        /// Property that return all the faceted navigation settings to use in the publishing module
        /// </summary>
        /// <returns>The faceted navigation settings</returns>
        public IList<FacetedNavigationInfo> FacetedNavigationInfos
        {
            get
            {
                return new List<FacetedNavigationInfo>()
                {
                    this.publishingFacetedNavigationInfos.News
                };
            }
        }
    }
}
