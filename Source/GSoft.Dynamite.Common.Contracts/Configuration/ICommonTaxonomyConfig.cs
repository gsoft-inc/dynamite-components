using System.Collections.Generic;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Common.Contract.Configuration
{
    /// <summary>
    /// Interface for common configuration for taxonomy in components.
    /// </summary>
    public interface ICommonTaxonomyConfig
    {
        /// <summary>
        /// Gets the term group infos.
        /// </summary>
        /// <value>
        /// The term group infos.
        /// </value>
        IList<TermGroupInfo> TermGroupInfos { get; }

        /// <summary>
        /// Gets the term set infos.
        /// NOTE: The first term set info is used as the SOURCE term set.
        /// </summary>
        /// <value>
        /// The term set infos.
        /// </value>
        IList<TermSetInfo> NavigationTermSetInfos { get; }

        /// <summary>
        /// Gets the term set infos.
        /// </summary>
        /// <value>
        /// The term set infos.
        /// </value>
        IList<TermSetInfo> TermSetInfos { get; }
    }
}
