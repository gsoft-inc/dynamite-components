using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing.Navigation;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    /// <summary>
    /// The global navigation service
    /// </summary>
    public class DynamiteNavigationService : IDynamiteNavigationService
    {
        private readonly INavigationService navigationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationService"></param>
        public DynamiteNavigationService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        /// <summary>
        /// Gets all navigation arborescence
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="properties">The properties object</param>
        /// <param name="max">The value max of nodes</param>
        /// <returns>List of Navigation Nodes</returns>
        public IList<INavigationNode> GetMenuNodes(SPWeb web, NavigationManagedProperties properties, int max)
        {
            var nodes = this.navigationService.GetAllNavigationNodes(SPContext.Current.Web, properties);

            // SortTree the Nodes vs Leafs (Nodes first)
            return this.SortTree(nodes.ToList(), 12);
        }

        private IList<INavigationNode> SortTree(IList<INavigationNode> nodes, int max)
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

        private IList<INavigationNode> Sort(IList<INavigationNode> navigationNodes)
        {
            if (navigationNodes.Any(entity => entity.Id != Guid.Empty) && navigationNodes.Any(entity => entity.Id == Guid.Empty))
            {
                var nodes = new List<INavigationNode>();
                var leafs = new List<INavigationNode>();

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
