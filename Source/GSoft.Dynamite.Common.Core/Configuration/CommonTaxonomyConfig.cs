using System;
using System.Collections.Generic;
using System.Linq;
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
        /// NOTE: The first term
        /// </summary>
        /// <value>
        /// The term set infos.
        /// </value>
        public IList<TermSetInfo> TermSetInfos
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
