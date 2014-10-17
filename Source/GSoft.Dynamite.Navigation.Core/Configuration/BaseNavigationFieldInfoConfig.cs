using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class BaseNavigationFieldInfoConfig: IBasePublishingFieldInfoConfig
    {
        private readonly IBasePublishingFieldInfoConfig basePublishingFieldInfoConfig;
        private readonly BaseNavigationFieldInfos baseNavigationFieldInfos;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="basePublishingFieldInfoConfig">The "inherited" base publishing field info config</param>
        /// <param name="baseMultilingualismFieldInfos">The fields infos for multilingualism</param>
        public BaseNavigationFieldInfoConfig(IBasePublishingFieldInfoConfig basePublishingFieldInfoConfig, BaseNavigationFieldInfos baseMultilingualismFieldInfos)
        {
            this.basePublishingFieldInfoConfig = basePublishingFieldInfoConfig;
            this.baseNavigationFieldInfos = baseMultilingualismFieldInfos;
        }

        /// <summary>
        /// Property to return the fields needed for the solution
        /// </summary>
        public IList<Definitions.IFieldInfo> Fields
        {
            get
            {
                // Get the base publishing field info 
                var baseFieldInfo = this.basePublishingFieldInfoConfig.Fields;

                // Add Date Slug
                baseFieldInfo.Add(this.baseNavigationFieldInfos.DateSlug());

                // Add Title Slug
                baseFieldInfo.Add(this.baseNavigationFieldInfos.TitleSlug());

                return baseFieldInfo;
            }
        }
    }
}
