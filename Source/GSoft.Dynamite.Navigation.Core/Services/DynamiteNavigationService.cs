using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    /// <summary>
    /// The global navigation service
    /// </summary>
    public class DynamiteNavigationService : IDynamiteNavigationService
    {
        private readonly INavigationService navigationService;

        /// <summary>
        /// Initializes the properties
        /// </summary>
        /// <param name="navigationService">The navigation service</param>
        public DynamiteNavigationService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        /// <summary>
        /// Gets all navigation arborescence
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="queryParameters">The query parameters.</param>
        /// <param name="max">The value max of nodes</param>
        /// <returns>
        /// List of Navigation Nodes
        /// </returns>
        public IList<NavigationNode> GetMenuNodes(SPWeb web, NavigationQueryParameters queryParameters, int max)
        {
            var nodes = this.navigationService.GetAllNavigationNodes(web, queryParameters);

            // SortTree the Nodes vs Leafs (Nodes first)
            return this.SortTree(nodes.ToList(), 12);
        }

        private IList<NavigationNode> SortTree(IList<NavigationNode> nodes, int max)
        {
            nodes = this.Sort(nodes).Take(max).ToList();
            foreach (var node in nodes)
            {
                if (node.ChildNodes != null && node.ChildNodes.Any())
                {
                    node.ChildNodes = this.SortTree(node.ChildNodes.ToList(), max);
                }
            }

            return nodes;
        }

        private IList<NavigationNode> Sort(IList<NavigationNode> navigationNodes)
        {
            if (navigationNodes.Any(entity => entity.Id != Guid.Empty) && navigationNodes.Any(entity => entity.Id == Guid.Empty))
            {
                var nodes = new List<NavigationNode>();
                var leafs = new List<NavigationNode>();

                foreach (var entity in navigationNodes)
                {
                    if (entity.Id != Guid.Empty)
                    {
                        nodes.Add(entity);
                    }
                    else
                    {
                        leafs.Add(entity);
                    }
                }

                nodes.AddRange(leafs);
                return nodes;
            }

            return navigationNodes;
       } 
    }
}
