using System.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// The taxonomy managed navigation settings for the navigation module
    /// </summary>
    public class NavigationManagedNavigationInfos
    {
        private readonly PublishingTermSetInfos publishingTermSetInfos;
        private readonly PublishingTermGroupInfos publishingTermGroupInfos;
        private readonly MultilingualismTermSetInfos multilingualismTermSetInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingTermSetInfos">The term info objects configuration from the publishing module</param>
        /// <param name="multilingualismTermSetInfos">The term set info objects configuration from the publishing module</param>
        /// <param name="publishingTermGroupInfos">The term group info objects configuration from the publishing module</param>
        public NavigationManagedNavigationInfos(
            PublishingTermSetInfos publishingTermSetInfos,
            MultilingualismTermSetInfos multilingualismTermSetInfos,
            PublishingTermGroupInfos publishingTermGroupInfos)
        {
            this.publishingTermSetInfos = publishingTermSetInfos;
            this.multilingualismTermSetInfos = multilingualismTermSetInfos;
            this.publishingTermGroupInfos = publishingTermGroupInfos;
        }

        /// <summary>
        /// The taxonomy managed navigation settings for the english site
        /// </summary>
        public ManagedNavigationInfo ManagedNavigationSettingsEnglish
        {
            get
            {
                return new ManagedNavigationInfo(
                    this.publishingTermSetInfos.GlobalNavigation(),
                    this.publishingTermGroupInfos.Navigation(), 
                    new CultureInfo(1033));
            }
        }

        /// <summary>
        /// The taxonomy managed navigation settings for the french site
        /// </summary>
        public ManagedNavigationInfo ManagedNavigationSettingsFrench
        {
            get
            {
                return new ManagedNavigationInfo(
                    this.multilingualismTermSetInfos.NavigationFrench(),
                    this.publishingTermGroupInfos.Navigation(), 
                    new CultureInfo(1036));
            }
        }
    }
}
