using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Common.Contract.Constants;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Term driven pages settings configuration for the navigation module
    /// </summary>
    public class NavigationTermDrivenPageSettingsInfoConfig : INavigationTermDrivenpageSettingsInfoConfig
    {
        private readonly ICommonTaxonomyConfig commonTaxonomyConfig;
        private readonly IPublishingPageInfoConfig publishingPageInfoConfig;
        private readonly IPublishingTaxonomyConfig publishingTaxonomyConfig;

        public NavigationTermDrivenPageSettingsInfoConfig(
            ICommonTaxonomyConfig commonTaxonomyConfig,
            IPublishingPageInfoConfig publishingPageInfoConfig,
            IPublishingTaxonomyConfig publishingTaxonomyConfig)
        {
            this.commonTaxonomyConfig = commonTaxonomyConfig;
            this.publishingPageInfoConfig = publishingPageInfoConfig;
            this.publishingTaxonomyConfig = publishingTaxonomyConfig;
        }

        /// <summary>
        /// Property that return all the term driven page settings in the navigation module
        /// </summary>
        public IList<TermDrivenPageSettingInfo> TermDrivenPageSettingInfos
        {
            get
            {               
                return new List<TermDrivenPageSettingInfo>()
                {
                    // Be careful, put TermSets configuration before Terms 
                    this.NavigationTermSet,
                    this.NavigationTermSetFrench,
                    this.NewsTerm,
                };
            }        
        }

        /// <summary>
        /// Gets the term driven page setting information by term from this configuration.
        /// </summary>
        /// <param name="term">The term information.</param>
        /// <returns>
        /// The term driven page setting information
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TermDrivenPageSettingInfo GetTermDrivenPageSettingInfoByTerm(TermInfo term)
        {
            return this.TermDrivenPageSettingInfos.Single(s => s.IsTerm && s.Term.Equals(term));
        }

        /// <summary>
        /// Gets the term driven page setting information by term set from this configuration.
        /// </summary>
        /// <param name="termSet">The term set information.</param>
        /// <returns>
        /// The term driven page setting information
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TermDrivenPageSettingInfo GetTermDrivenPageSettingInfoByTermSet(TermSetInfo termSet)
        {
            return this.TermDrivenPageSettingInfos.Single(s => s.IsTermSet && s.TermSet.Equals(termSet));
        }

        /// <summary>
        /// The term driven pages settings or the english navigation taxonomy term set
        /// </summary>
        private TermDrivenPageSettingInfo NavigationTermSet
        {
            get
            {
                return new TermDrivenPageSettingInfo(
                    this.commonTaxonomyConfig.GetTermSetInfoById(CommonTermSetInfo.EnglishNavigation.Id),
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.TargetItemPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl,
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogItemPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl);
            }
        }

        /// <summary>
        /// The term driven pages settings or the french navigation taxonomy term set
        /// </summary>
        private TermDrivenPageSettingInfo NavigationTermSetFrench
        {
            get
            {
                return new TermDrivenPageSettingInfo(
                    this.commonTaxonomyConfig.GetTermSetInfoById(CommonTermSetInfo.FrenchNavigation.Id),
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.TargetItemPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl,
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogItemPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl);
            }
        }

        /// <summary>
        /// The term driven pages settings or the News taxonomy term
        /// </summary>
        private TermDrivenPageSettingInfo NewsTerm
        {
            get
            {
                // Be careful, set ExcludeFromCurrentNavigation = false to get the friendly url generation from Search WebParts work
                // http://blog.mastykarz.nl/inconvenient-url-rewriting-catalog-items-sharepoint-2013/
                return new TermDrivenPageSettingInfo(
                    this.publishingTaxonomyConfig.GetTermById(PublishingTermInfos.News.Id),
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogCategoryItemsPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl,
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogItemPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl,
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogCategoryItemsPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl,
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogItemPageTemplate.FileName).SiteTokenizedTermDrivenPageUrl,
                    false,
                    false);
            }
        }
    }
}
