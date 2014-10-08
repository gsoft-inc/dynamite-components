using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Re-implementation of the base publishing field info config to add multilingualism site column
    /// </summary>
    public class BaseMultilingualismFieldInfoConfig : IBasePublishingFieldInfoConfig
    {
        private IBasePublishingFieldInfoConfig basePublishingFieldInfoConfig;
        private BaseMultilingualismFieldInfos baseMultilingualismFieldInfos;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="basePublishingFieldInfoConfig">The "inherited" base publishing field info config</param>
        /// <param name="baseMultilingualismFieldInfos">The fields infos for multilingualism</param>
        public BaseMultilingualismFieldInfoConfig(IBasePublishingFieldInfoConfig basePublishingFieldInfoConfig, BaseMultilingualismFieldInfos baseMultilingualismFieldInfos)
        {
            this.basePublishingFieldInfoConfig = basePublishingFieldInfoConfig;
            this.baseMultilingualismFieldInfos = baseMultilingualismFieldInfos;
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

                // Add Content Association Key
                baseFieldInfo.Add(this.baseMultilingualismFieldInfos.ContentAssociationKey());

                return baseFieldInfo;
            }
        }
    }
}
