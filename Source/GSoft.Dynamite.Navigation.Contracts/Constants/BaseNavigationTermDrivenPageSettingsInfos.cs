using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class BaseNavigationTermDrivenPageSettingsInfos
    {
        private readonly BasePublishingTermInfos _basePublishingTermInfos;
        private readonly BasePublishingTermSetInfos _basePublishingTermSetInfos;
        private readonly BasePublishingPageInfos _basePublishingPageInfos;

        public BaseNavigationTermDrivenPageSettingsInfos(BasePublishingTermInfos termInfos,
            BasePublishingTermSetInfos termSetInfos, BasePublishingPageInfos pageInfos)
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
