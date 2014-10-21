using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationFieldInfoConfig : INavigationFieldInfoConfig
    {
        private readonly NavigationFieldInfos _baseNavigationFieldInfos;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="baseMultilingualismFieldInfos">The fields infos for multilingualism</param>
        public NavigationFieldInfoConfig(NavigationFieldInfos baseMultilingualismFieldInfos)
        {
            this._baseNavigationFieldInfos = baseMultilingualismFieldInfos;
        }

        /// <summary>
        /// Property to return the fields needed for the solution
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
                    this._baseNavigationFieldInfos.PublishingStartDate()
                };

                return baseFieldInfo;
            }
        }
    }
}
