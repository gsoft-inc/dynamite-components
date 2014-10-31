using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationTermDrivenPageSettingsInfos
    {
        private readonly PublishingTermInfos _basePublishingTermInfos;
        private readonly PublishingTermSetInfos _basePublishingTermSetInfos;
        private readonly PublishingPageInfos _basePublishingPageInfos;

        public NavigationTermDrivenPageSettingsInfos(PublishingTermInfos termInfos,
            PublishingTermSetInfos termSetInfos, PublishingPageInfos pageInfos)
        {
            this._basePublishingTermInfos = termInfos;
            this._basePublishingTermSetInfos = termSetInfos;
            this._basePublishingPageInfos = pageInfos;
        }

        public TermDrivenPageSettingInfo NavigationTermSet()
        {
            return new TermDrivenPageSettingInfo(
                this._basePublishingTermSetInfos.GlobalNavigation(),
                this._basePublishingPageInfos.TargetItemPageTemplate().RelativeTermDrivenPageUrl,
                this._basePublishingPageInfos.CatalogItemPageTemplate().RelativeTermDrivenPageUrl);
        }

        public TermDrivenPageSettingInfo NewsTerm()
        {
            return new TermDrivenPageSettingInfo(
                this._basePublishingTermInfos.NewsLabel(),
                string.Empty,
                this._basePublishingPageInfos.CatalogItemPageTemplate().RelativeTermDrivenPageUrl,
                string.Empty,
                this._basePublishingPageInfos.CatalogItemPageTemplate().RelativeTermDrivenPageUrl,
                false,
                true);
        }

        public TermDrivenPageSettingInfo AboutTerm()
        {
            return new TermDrivenPageSettingInfo(
                this._basePublishingTermInfos.AboutLabel(),"http://www.gsoft.com"
                );
        }
    }
}
