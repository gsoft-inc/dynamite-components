using System;
using System.Collections.Generic;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Taxonomy configuration for the publishing modules
    /// </summary>
    public interface IPublishingTaxonomyConfig
    {
        /// <summary>
        /// Gets the term sets.
        /// </summary>
        /// <value>
        /// The term sets.
        /// </value>
        IList<TermSetInfo> TermSets { get; }

        /// <summary>
        /// Gets the taxonomy terms for this configuration.
        /// </summary>
        /// <value>
        /// A list of taxonomy term information.
        /// </value>
        IList<TermInfo> Terms { get; }

        /// <summary>
        /// Gets the term set by identifier.
        /// </summary>
        /// <param name="termSetId">The term set identifier.</param>
        /// <returns>The term set information.</returns>
        TermSetInfo GetTermSetById(Guid termSetId);

        /// <summary>
        /// Gets the term by identifier from this configuration.
        /// </summary>
        /// <param name="termId">The term identifier.</param>
        /// <returns>The term information.</returns>
        TermInfo GetTermById(Guid termId);
    }
}
