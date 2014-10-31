using System.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationManagedNavigationInfos
    {
        private readonly PublishingTermSetInfos publishingTermSetInfos;
        private readonly PublishingTermGroupInfos publishingTermGroupInfos;
        private readonly MultilingualismTermSetInfos multilingualismTermSetInfos;

        public NavigationManagedNavigationInfos(PublishingTermSetInfos publishingTermSetInfos,
            MultilingualismTermSetInfos multilingualismTermSetInfos,
            PublishingTermGroupInfos publishingTermGroupInfos)
        {
            this.publishingTermSetInfos = publishingTermSetInfos;
            this.multilingualismTermSetInfos = multilingualismTermSetInfos;
            this.publishingTermGroupInfos = publishingTermGroupInfos;
        }

        public ManagedNavigationInfo ManagedNavigationSettingsEnglish
        {
            get
            {
                return new ManagedNavigationInfo(this.publishingTermSetInfos.GlobalNavigation(),
                    this.publishingTermGroupInfos.Navigation(), new CultureInfo(1033));
            }
        }

        public ManagedNavigationInfo ManagedNavigationSettingsFrench
        {
            get
            {
                return new ManagedNavigationInfo(this.multilingualismTermSetInfos.NavigationFrench(),
                    this.publishingTermGroupInfos.Navigation(), new CultureInfo(1036));
            }
        }
    }
}
