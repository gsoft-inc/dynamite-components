using System.Collections.Generic;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Fields configuration for the navigation module
    /// </summary>
    public class NavigationFieldInfoConfig : INavigationFieldInfoConfig
    {
        private readonly NavigationFieldInfos baseNavigationFieldInfos;
        private readonly PublishingFieldInfos basePublishingFieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="baseMultilingualismFieldInfos">The fields info for multilingualism</param>
        /// <param name="basePublishingFieldInfos">The base publishing field information.</param>
        public NavigationFieldInfoConfig(
            NavigationFieldInfos baseMultilingualismFieldInfos,
            PublishingFieldInfos basePublishingFieldInfos)
        {
            this.baseNavigationFieldInfos = baseMultilingualismFieldInfos;
            this.basePublishingFieldInfos = basePublishingFieldInfos;
        }

        /// <summary>
        /// Property that return all the fields to create or configure in the navigation module
        /// </summary>
        public IList<IFieldInfo> Fields
        {
            get
            {
                // Get the base publishing field info 
                var baseFieldInfo = new List<IFieldInfo>
                {
                    this.baseNavigationFieldInfos.DateSlug(),
                    this.baseNavigationFieldInfos.TitleSlug(),
                    this.basePublishingFieldInfos.PublishingStartDate(),
                    this.baseNavigationFieldInfos.OccurrenceLinkLocation()
                };

                return baseFieldInfo;
            }
        }
    }
}
