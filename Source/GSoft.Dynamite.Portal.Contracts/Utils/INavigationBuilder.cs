using System.Collections.Generic;
using GSoft.Dynamite.Navigation;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Utils
{
    /// <summary>
    /// The interface of navigation builder
    /// </summary>
    public interface INavigationBuilder
    {
        /// <summary>
        /// Get all the navigation terms
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="isParentNode">The parent node</param>
        /// <returns>Navigation node tree</returns>
        IEnumerable<INavigationNode> GetContextualNavigationAndItems(SPWeb web, bool isParentNode);

        /// <summary>
        /// Get all the navigation terms
        /// </summary>
        /// <returns>Contextual navigation node tree</returns>
        IEnumerable<INavigationNode> GetContextualNavigationTerms();

        /// <summary>
        /// Get all the navigation siblings terms
        /// </summary>
        /// <param name="isParenNode">The parent node</param>
        /// <returns>Contextual navigation node tree</returns>
        IEnumerable<INavigationNode> GetContextualNavigationSiblingsTerms(bool isParenNode);
    }
}
