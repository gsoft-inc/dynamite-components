using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Term driven pages settings configuration for the navigation module
    /// </summary>
    public class NavigationTermDrivenPageSettingsInfos
    {
        private readonly PublishingTermInfos _basePublishingTermInfos;
        private readonly PublishingTermSetInfos _basePublishingTermSetInfos;
        private readonly PublishingPageInfos _basePublishingPageInfos;
        private readonly MultilingualismTermSetInfos _multilingualismTermInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="termInfos">The term info objects configuration from the publishing module</param>
        /// <param name="multilingualismTermInfos">The term info objects configuration from the multilingualism module</param>
        /// <param name="termSetInfos">The term set info objects configuration from the publishing module</param>
        /// <param name="pageInfos">The page info objects configuration from the publishing module</param>
        public NavigationTermDrivenPageSettingsInfos(
            PublishingTermInfos termInfos, 
            MultilingualismTermSetInfos multilingualismTermInfos,
            PublishingTermSetInfos termSetInfos, 
            PublishingPageInfos pageInfos)
        {
            this._basePublishingTermInfos = termInfos;
            this._multilingualismTermInfos = multilingualismTermInfos;
            this._basePublishingTermSetInfos = termSetInfos;
            this._basePublishingPageInfos = pageInfos;
        }

        /// <summary>
        /// The term driven pages settings or the english navigation taxonomy term set
        /// </summary>
        /// <returns>The term driven pages settings info</returns>
        public TermDrivenPageSettingInfo NavigationTermSet()
        {
            return new TermDrivenPageSettingInfo(
                this._basePublishingTermSetInfos.GlobalNavigation(),
                this._basePublishingPageInfos.TargetItemPageTemplate().SiteTokenizedTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogItemPageTemplate().SiteTokenizedTermDrivenPageUrl);
        }

        /// <summary>
        /// The term driven pages settings or the french navigation taxonomy term set
        /// </summary>
        /// <returns>The term driven pages settings info</returns>
        public TermDrivenPageSettingInfo NavigationTermSetFrench()
        {
            return new TermDrivenPageSettingInfo(
                this._multilingualismTermInfos.NavigationFrench(),
                this._basePublishingPageInfos.TargetItemPageTemplate().SiteTokenizedTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogItemPageTemplate().SiteTokenizedTermDrivenPageUrl);
        }

        /// <summary>
        /// The term driven pages settings or the News taxonomy term
        /// </summary>
        /// <returns>The term driven pages settings info</returns>
        public TermDrivenPageSettingInfo NewsTerm()
        {
            // Be careful, set ExcludeFromCurrentNavigation = false to get the friendly url generation from Search WebParts work
            // http://blog.mastykarz.nl/inconvenient-url-rewriting-catalog-items-sharepoint-2013/
            return new TermDrivenPageSettingInfo(
                this._basePublishingTermInfos.NewsLabel(),
                this._basePublishingPageInfos.CatalogCategoryItemsPageTemplate().SiteTokenizedTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogItemPageTemplate().SiteTokenizedTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogCategoryItemsPageTemplate().SiteTokenizedTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogItemPageTemplate().SiteTokenizedTermDrivenPageUrl,
                false,
                false);
        }
    }
}
