using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="properties">The properties object</param>
        /// <param name="max">The value max of nodes</param>
        /// <returns>List of Navigation Nodes</returns>
        IList<NavigationNode> GetMenuNodes(SPWeb web, NavigationManagedProperties properties, int max);
    }
}
