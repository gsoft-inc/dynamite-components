using System.Collections.Generic;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the reference of the Taxonomy Term Groups
    /// </summary>
    public class PublishingTaxonomyConfig : IPublishingTaxonomyConfig
    {
        private readonly PublishingTermGroupInfos termGroupInfoValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="termGroupInfoValues">The term groups info objects</param>
        public PublishingTaxonomyConfig(PublishingTermGroupInfos termGroupInfoValues)
        {
            this.termGroupInfoValues = termGroupInfoValues;
        }

        /// <summary>
        /// Property that return all references of taxonomy term groups used across the solution
        /// </summary>
        /// <returns>The term groups</returns>
        public IList<TermGroupInfo> TermGroups
        {
            get
            {
                var termGroups = new List<TermGroupInfo>
                {
                    this.termGroupInfoValues.Navigation()
                };

                return termGroups;
            }          
        }
    }
}
