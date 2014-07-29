using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using GSoft.Dynamite.Navigation;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Utils;
using GSoft.Dynamite.Utils;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;

namespace GSoft.Dynamite.Portal.Core.Utils
{
    /// <summary>
    /// The navigation builder class
    /// </summary>
    public class NavigationBuilder : INavigationBuilder
    {
        private readonly NavigationService navigationService;
        private readonly SearchHelper searchHelper;

        /// <summary>
        /// Initialize a new instance of NavigationBuilder class
        /// </summary>
        /// <param name="navigationService">The navigation service instance</param>
        /// <param name="searchHelper">The search helper</param>
        public NavigationBuilder(NavigationService navigationService, SearchHelper searchHelper)
        {
            this.navigationService = navigationService;
            this.searchHelper = searchHelper;
        }

        /// <summary>
        /// Get the pages tagged with terms across the search service
        /// </summary>
        /// <param name="properties">The Managed Properties</param>
        /// <param name="termId">The term Id</param>
        /// <returns>Navigation node</returns>
        public IEnumerable<INavigationNode> GetNavigationNodeItems(NavigationManagedProperties properties, string termId)
        {
            // Use 'all menu items' result source for search query
            var searchResultSource = this.searchHelper.GetResultSourceByName(properties.ResultSourceName, SPContext.Current.Site, SearchObjectLevel.Ssa);

            // Build query to return items in current variation label language
            var currentLabel = PublishingWeb.GetPublishingWeb(SPContext.Current.Web).Label;
            var labelLocalAgnosticLanguage = currentLabel.Language.Split('-').First();
            var query = new KeywordQuery(SPContext.Current.Web)
            {
                SourceId = searchResultSource.Id,
                QueryText = string.Format("{0}:{1} {2}:{3}", properties.ItemLanguage, labelLocalAgnosticLanguage, "GP0|#", termId),
                TrimDuplicates = false,
                
            };

            query.SelectProperties.AddRange(new List<string>(properties.FriendlyUrlRequiredProperties) { properties.Title }.ToArray());

            var tables = new SearchExecutor().ExecuteQuery(query);
            if (tables.Exists(KnownTableTypes.RelevantResults))
            {
                // Build navigation nodes for search results
                var results = tables.Filter("TableType", KnownTableTypes.RelevantResults).Single(relevantTable => relevantTable.QueryRuleId == Guid.Empty);
                var nodes = results.Table.Rows.Cast<DataRow>().Select(x => new NavigationNode(x, properties.Navigation));
               
                return nodes;
            }

           
            return new List<INavigationNode>();
        }

        /// <summary>
        /// Get all the navigation terms
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="isParentNode">The parent node</param>
        /// <returns>Navigation node tree</returns>
        public IEnumerable<INavigationNode> GetContextualNavigationAndItems(SPWeb web, bool isParentNode)
        {
            var properties = new NavigationManagedProperties()
            {
                Title = PortalManagedProperties.Title,
                Navigation = PortalManagedProperties.PortalNavigation,
                ItemLanguage = PortalManagedProperties.ItemLanguage,
                FriendlyUrlRequiredProperties = PortalManagedProperties.FriendlyUrlRequiredProperties,
                ResultSourceName = "Parent navigation items"
            };

            var view = new NavigationTermSetView(web, StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider)
            {
                ExcludeTermsByProvider = false
            };

            IEnumerable<INavigationNode> items, terms, nodes;
            var termId = this.GetResultSourceTermID(isParentNode);
            items = this.GetNavigationNodeItems(properties, termId)
                .OrderBy(page => page.Title, StringComparer.InvariantCultureIgnoreCase);
            terms = this.GetContextualNavigationSiblingsTerms(isParentNode);
            nodes = this.navigationService.MapNavigationNodeTree(terms, items);

            var nodesArray = nodes as INavigationNode[] ?? nodes.ToArray();
            return nodesArray;
        }

        /// <summary>
        /// Get all the navigation terms
        /// </summary>
        /// <returns>Contextual navigation node tree</returns>
        public IEnumerable<INavigationNode> GetContextualNavigationTerms()
        {
            if (TaxonomyNavigationContext.Current.NavigationTerm != null)
            {
            return this.navigationService.GetNavigationNodeTerms(new[] { TaxonomyNavigationContext.Current.NavigationTerm });
        }

            return new List<INavigationNode>();
        }

        /// <summary>
        /// Get all the navigation siblings terms
        /// </summary>
        /// <param name="isParenNode">The parent node</param>
        /// <returns>Contextual navigation node tree</returns>
        public IEnumerable<INavigationNode> GetContextualNavigationSiblingsTerms(bool isParenNode)
        {
            var currentTerm = TaxonomyNavigationContext.Current.NavigationTerm;
            if (currentTerm.Parent != null && isParenNode)
            {
                return this.GetNavigationNodeTerms(new[] { currentTerm.Parent }, 1);
            }
            return this.GetNavigationNodeTerms(new[] { currentTerm }, 1);
        }
        
        /// <summary>
        /// Method to get the Navigation node terms with a recurrence level
        /// </summary>
        /// <param name="navigationTerms">The navigation terms to get</param>
        /// <param name="maxLevel">The maximum number of levels to get</param>
        /// <returns>A list of navigation node</returns>
        public IEnumerable<INavigationNode> GetNavigationNodeTerms(IEnumerable<NavigationTerm> navigationTerms, int maxLevel)
        {
            var terms = navigationTerms as NavigationTerm[] ?? navigationTerms.Where(x => !x.ExcludeFromGlobalNavigation).ToArray();
            var nodes = terms.Select(x => new NavigationNode(x)).ToArray();

            if (maxLevel > 0)
            {
                for (var i = 0; i < terms.Length; i++)
                {
                    var term = terms[i];
                    var node = nodes[i];
                    
                    // If term contains children, recurvise call
                    if (term.Terms.Count > 0)
                    {
                        node.ChildNodes = this.GetNavigationNodeTerms(term.Terms, maxLevel - 1);
                    }
                } 
            }

            return nodes;
        }

        /// <summary>
        /// Gets the term ID included in the result source.
        /// </summary>
        /// <param name="isParenNode">The parent node</param>
        /// <returns>The term Id</returns>
        private string GetResultSourceTermID(bool isParenNode)
        {
            var currentTerm = TaxonomyNavigationContext.Current.NavigationTerm;
            if (currentTerm == null)
            {
                return string.Empty;
            }

            if (currentTerm.Parent != null && isParenNode)
            {
                return currentTerm.Parent.Id.ToString();
            }
            return currentTerm.Id.ToString();
        }
    }
}
