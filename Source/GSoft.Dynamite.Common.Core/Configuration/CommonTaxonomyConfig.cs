using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Common.Core.Configuration
{
    /// <summary>
    /// Common configuration for taxonomy in components.
    /// </summary>
    public class CommonTaxonomyConfig : ICommonTaxonomyConfig
    {
        /// <summary>
        /// Gets the term group information.
        /// </summary>
        /// <value>
        /// The term group information.
        /// </value>
        public IList<TermGroupInfo> TermGroupInfos
        {
            get
            {
                return new List<TermGroupInfo>
                {
                    CommonTermGroupInfo.Navigation, 
                    CommonTermGroupInfo.Restricted,
                    CommonTermGroupInfo.Keywords
                };
            }
        }

        /// <summary>
        /// Gets the term set information.
        /// NOTE: The first term
        /// </summary>
        /// <value>
        /// The term set information.
        /// </value>
        public IList<TermSetInfo> TermSetInfos
        {
            get
            {
                return new List<TermSetInfo>
                {
                    CommonTermSetInfo.EnglishNavigation,
                    CommonTermSetInfo.FrenchNavigation
                };
            }
        }

        /// <summary>
        /// Gets the term group information by identifier from this configuration.
        /// </summary>
        /// <param name="id">The unique identifier of the term group.</param>
        /// <returns>
        /// The term group information
        /// </returns>
        public TermGroupInfo GetTermGroupInfoById(Guid id)
        {
            return this.TermGroupInfos.Single(termGroup => termGroup.Id.Equals(id));
        }

        /// <summary>
        /// Gets the term set information by identifier from this configuration.
        /// </summary>
        /// <param name="id">The identifier of the term set.</param>
        /// <returns>
        /// The term set information
        /// </returns>
        public TermSetInfo GetTermSetInfoById(Guid id)
        {
            return this.TermSetInfos.Single(termSet => termSet.Id.Equals(id));
        }
    }
}
