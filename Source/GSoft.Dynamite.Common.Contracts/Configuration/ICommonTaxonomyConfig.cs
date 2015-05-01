using System;
using System.Collections.Generic;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Common.Contracts.Configuration
{
    /// <summary>
    /// Interface for common configuration for taxonomy in components.
    /// </summary>
    public interface ICommonTaxonomyConfig
    {
        /// <summary>
        /// Gets the term group information.
        /// </summary>
        /// <value>
        /// The term group information.
        /// </value>
        IList<TermGroupInfo> TermGroupInfos { get; }

        /// <summary>
        /// Gets the term set information.
        /// </summary>
        /// <value>
        /// The term set information.
        /// </value>
        IList<TermSetInfo> TermSetInfos { get; }

        /// <summary>
        /// Gets the term group information by identifier from this configuration.
        /// </summary>
        /// <param name="id">The unique identifier of the term group.</param>
        /// <returns>The term group information</returns>
        TermGroupInfo GetTermGroupInfoById(Guid id);

        /// <summary>
        /// Gets the term set information by identifier from this configuration.
        /// </summary>
        /// <param name="id">The identifier of the term set.</param>
        /// <returns>The term set information</returns>
        TermSetInfo GetTermSetInfoById(Guid id);
    }
}
