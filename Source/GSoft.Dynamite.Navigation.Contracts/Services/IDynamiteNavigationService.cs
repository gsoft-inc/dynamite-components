using System.Collections.Generic;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Services
{
    /// <summary>
    /// The public interface of the class DynamiteNavigationService
    /// </summary>
    public interface IDynamiteNavigationService
    {
        /// <summary>
        /// Gets all navigation arborescence
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="queryParameters">The query parameters.</param>
        /// <param name="max">The value max of nodes</param>
        /// <returns>
        /// List of Navigation Nodes
        /// </returns>
        IList<NavigationNode> GetMenuNodes(SPWeb web, NavigationQueryParameters queryParameters, int max);
    }
}
