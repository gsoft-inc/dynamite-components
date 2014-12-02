using System.Collections.Generic;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Fields configuration for the navigation module
    /// </summary>
    public class NavigationFieldInfoConfig : INavigationFieldInfoConfig
    {
        private readonly NavigationFieldInfos _baseNavigationFieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="baseMultilingualismFieldInfos">The fields info for multilingualism</param>
        public NavigationFieldInfoConfig(NavigationFieldInfos baseMultilingualismFieldInfos)
        {
            this._baseNavigationFieldInfos = baseMultilingualismFieldInfos;
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
                    this._baseNavigationFieldInfos.DateSlug(),
                    this._baseNavigationFieldInfos.TitleSlug(),
                    this._baseNavigationFieldInfos.PublishingStartDate(),
                    this._baseNavigationFieldInfos.OccurrenceLinkLocation()
                };

                return baseFieldInfo;
            }
        }
    }
}
