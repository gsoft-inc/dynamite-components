using System.Linq;
using System.Collections.Generic;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;
using GSoft.Dynamite.Common.Contracts.Constants;
using System;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the reference of the Taxonomy Term Groups
    /// </summary>
    public class PublishingTaxonomyConfig : IPublishingTaxonomyConfig
    {
        private readonly ICommonTaxonomyConfig commonTaxonomyConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishingTaxonomyConfig"/> class.
        /// </summary>
        /// <param name="commonTaxonomyConfig">The common taxonomy configuration.</param>
        public PublishingTaxonomyConfig(ICommonTaxonomyConfig commonTaxonomyConfig)
        {
            this.commonTaxonomyConfig = commonTaxonomyConfig;
        }

        /// <summary>
        /// Gets the term sets.
        /// </summary>
        /// <value>
        /// The term sets.
        /// </value>
        public IList<TermSetInfo> TermSets
        {
            get 
            {
                // Get the term group on the possibly customized term group infos
                var restrictedTermGroupInfo = this.commonTaxonomyConfig.GetTermGroupInfoById(CommonTermGroupInfo.Restricted.Id);
                var restrictedNewsTermSetInfo = this.GetTermSetById(PublishingTermSetInfos.RestrictedNews.Id);
                restrictedNewsTermSetInfo.Group = restrictedTermGroupInfo;

                return new[] 
                {
                    restrictedNewsTermSetInfo
                };
            }
        }

        /// <summary>
        /// Gets the taxonomy terms for this configuration.
        /// </summary>
        /// <value>
        /// A list of taxonomy term information.
        /// </value>
        public IList<TermInfo> Terms
        {
            get
            {
                var newsTerm = PublishingTermInfos.News;
                newsTerm.TermSet = this.GetTermSetById(PublishingTermSetInfos.RestrictedNews.Id);

                return new[]
                {
                    newsTerm
                };
            }
        }

        /// <summary>
        /// Gets the term set by identifier.
        /// </summary>
        /// <param name="termSetId">The term set identifier.</param>
        /// <returns>
        /// The term set information.
        /// </returns>
        public TermSetInfo GetTermSetById(Guid termSetId)
        {
            return this.TermSets.Single(termSet => termSet.Id == termSetId);
        }


        /// <summary>
        /// Gets the term by identifier from this configuration.
        /// </summary>
        /// <param name="termId">The term identifier.</param>
        /// <returns>
        /// The term information.
        /// </returns>
        public TermInfo GetTermById(Guid termId)
        {
            return this.Terms.Single(term => term.Id == termId);
        }
    }
}
