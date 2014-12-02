using System.Collections.Generic;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Re-implementation of the base publishing field info config to add multilingualism site column
    /// </summary>
    public class MultilingualismFieldInfoConfig : IMultilingualismFieldInfoConfig
    {
        private readonly MultilingualismFieldInfos baseMultilingualismFieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="baseMultilingualismFieldInfos">The fields info for multilingualism</param>
        public MultilingualismFieldInfoConfig(MultilingualismFieldInfos baseMultilingualismFieldInfos)
        {
            this.baseMultilingualismFieldInfos = baseMultilingualismFieldInfos;
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
                    this.baseMultilingualismFieldInfos.ContentAssociationKey(),
                    this.baseMultilingualismFieldInfos.ItemLanguage()
                };

                return baseFieldInfo;
            }
        }
    }
}
