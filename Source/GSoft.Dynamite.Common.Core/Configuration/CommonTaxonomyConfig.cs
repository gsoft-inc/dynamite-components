using System.Collections.Generic;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Common.Contract.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Common.Core.Configuration
{
    /// <summary>
    /// Common configuration for taxonomy in components.
    /// </summary>
    public class CommonTaxonomyConfig : ICommonTaxonomyConfig
    {
        /// <summary>
        /// Gets the term group infos.
        /// </summary>
        /// <value>
        /// The term group infos.
        /// </value>
        public IList<TermGroupInfo> TermGroupInfos
        {
            get
            {
                return new[]
                {
                    CommonTermGroupInfo.Navigation, 
                    CommonTermGroupInfo.Restricted,
                    CommonTermGroupInfo.Keywords
                };
            }
        }

        /// <summary>
        /// Gets the term set infos.
        /// NOTE: The first term set info is used as the SOURCE term set.
        /// </summary>
        /// <value>
        /// The term set infos.
        /// </value>
        public IList<TermSetInfo> NavigationTermSetInfos
        {
            get
            {
                return new[]
                {
                    CommonTermSetInfo.EnglishNavigation,
                    CommonTermSetInfo.FrenchNavigation
                };
            }
        }

        /// <summary>
        /// Gets the term set infos.
        /// NOTE: The first term
        /// </summary>
        /// <value>
        /// The term set infos.
        /// </value>
        public IList<TermSetInfo> TermSetInfos
        {
            get
            {
                return new List<TermSetInfo>();
            }
        }
    }
}
