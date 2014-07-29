using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Navigation;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Services
{
    /// <summary>
    /// Interface for the service responsible to get Navigation nodes and leafs
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Gets all the navigation terms.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="resultSourceName">Name of the result source.</param>
        /// <returns>A navigation node tree.</returns>
        IEnumerable<INavigationNode> GetAllNavigationNodes(SPWeb web, string resultSourceName);
    }
}
