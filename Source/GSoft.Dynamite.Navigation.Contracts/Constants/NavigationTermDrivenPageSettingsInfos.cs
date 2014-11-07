using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationTermDrivenPageSettingsInfos
    {
        private readonly PublishingTermInfos _basePublishingTermInfos;
        private readonly PublishingTermSetInfos _basePublishingTermSetInfos;
        private readonly PublishingPageInfos _basePublishingPageInfos;
        private readonly MultilingualismTermSetInfos _multilingualismTermInfos;

        public NavigationTermDrivenPageSettingsInfos(PublishingTermInfos termInfos, MultilingualismTermSetInfos multilingualismTermInfos,
            PublishingTermSetInfos termSetInfos, PublishingPageInfos pageInfos)
        {
            this._basePublishingTermInfos = termInfos;
            this._multilingualismTermInfos = multilingualismTermInfos;
            this._basePublishingTermSetInfos = termSetInfos;
            this._basePublishingPageInfos = pageInfos;
        }

        public TermDrivenPageSettingInfo NavigationTermSet()
        {
            return new TermDrivenPageSettingInfo(
                this._basePublishingTermSetInfos.GlobalNavigation(),
                this._basePublishingPageInfos.TargetItemPageTemplate().SiteTokenizedTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogItemPageTemplate().SiteTokenizedTermDrivenPageUrl);
        }

        public TermDrivenPageSettingInfo NavigationTermSetFrench()
        {
            return new TermDrivenPageSettingInfo(
                this._multilingualismTermInfos.NavigationFrench(),
                this._basePublishingPageInfos.TargetItemPageTemplate().SiteTokenizedTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogItemPageTemplate().SiteTokenizedTermDrivenPageUrl);
        }

        public TermDrivenPageSettingInfo NewsTerm()
        {
            return new TermDrivenPageSettingInfo(
                this._basePublishingTermInfos.NewsLabel(),
                string.Empty,
                this._basePublishingPageInfos.CatalogCategoryItemsPageTemplate().SiteTokenizedTermDrivenPageUrl,
                string.Empty,
                this._basePublishingPageInfos.CatalogItemPageTemplate().SiteTokenizedTermDrivenPageUrl,
                false,
                true);
        }
    }
}
