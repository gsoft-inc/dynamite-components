using System.Collections.Generic;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Faceted navigation setting definitions for the publishing module
    /// </summary>
    public class PublishingFacetedNavigationInfos
    {
        private readonly PublishingManagedPropertyInfos managedPropertyInfos;
        private readonly PublishingDisplayTemplateInfos displayTemplateInfos;
        private readonly PublishingTermInfos termInfo;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="termInfo">The term info objects configuration</param>
        /// <param name="managedPropertyInfos">The managed property info objects configuration</param>
        /// <param name="displayTemplateInfos">The display template info objects configuration</param>
        public PublishingFacetedNavigationInfos(
            PublishingTermInfos termInfo, 
            PublishingManagedPropertyInfos managedPropertyInfos, 
            PublishingDisplayTemplateInfos displayTemplateInfos)
        {
            this.managedPropertyInfos = managedPropertyInfos;
            this.displayTemplateInfos = displayTemplateInfos;
            this.termInfo = termInfo;
        }

        /// <summary>
        /// The news term faceted navigation settings
        /// </summary>
        public FacetedNavigationInfo News
        {
            get
            {
                var navigation = new RefinerInfo(this.managedPropertyInfos.NavigationText.Name, RefinerType.Text, false);
                navigation.DisplayTemplateJsLocation =
                    this.displayTemplateInfos.DefaultFilterCategoryRefinement().ItemTemplateTokenizedPath;

                var created = new RefinerInfo("Created", RefinerType.DateTime, false);

                var refiners = new List<RefinerInfo>()
                {
                    navigation,
                    created,
                };

                return new FacetedNavigationInfo(this.termInfo.NewsLabel(), refiners);
            }
        }
    }
}
