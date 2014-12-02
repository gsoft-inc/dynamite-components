using System.Collections.Generic;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Term groups configuration for the publishing modules
    /// </summary>
    public interface IPublishingTaxonomyConfig
    {
        /// <summary>
        /// Property that return all the taxonomy term groups to create or configure in the publishing module
        /// </summary>
        IList<TermGroupInfo> TermGroups { get; }
    }
}
