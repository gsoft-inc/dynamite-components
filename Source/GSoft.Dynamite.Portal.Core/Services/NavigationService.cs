using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Services;
using GSoft.Dynamite.Utils;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Portal.Core.Services
{
    /// <summary>
    /// Service for navigation logic
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly ILogger logger;
        private readonly SearchHelper searchHelper;
        private readonly NavigationHelper navigationHelper;
        private readonly ICatalogNavigation catalogNavigation;

        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationService(ILogger logger, SearchHelper searchHelper, NavigationHelper navigationHelper, ICatalogNavigation catalogNavigation)
        {
            this.logger = logger;
            this.searchHelper = searchHelper;
            this.navigationHelper = navigationHelper;
            this.catalogNavigation = catalogNavigation;
        }

        /// <summary>
        /// Gets all the navigation terms.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="resultSourceName">Name of the result source.</param>
        /// <returns>A navigation node tree.</returns>
        public IEnumerable<INavigationNode> GetAllNavigationNodes(SPWeb web, string resultSourceName)
        {
            try
            {
                // Use the SPMonitored scope to 
                using (new SPMonitoredScope("GSoft.Dynamite.Portal.Core.Services.NavigationService::GetAllNavigationNodes"))
                {
                    // Create view to return all navigation terms
                    var view = new NavigationTermSetView(web, StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider)
                    {
                        ExcludeTermsByProvider = false
                    };

                    IEnumerable<INavigationNode> items, terms, nodes;
                    var navigationTermSet = TaxonomyNavigation.GetTermSetForWeb(web, StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider, true).GetWithNewView(view);

                    using (new SPMonitoredScope("GetNavigationNodeItems"))
                    {
                        // Get navigation items from search
                        items = this.GetNavigationNodeItems(resultSourceName).ToArray();

                        // If the cache contains corrupted data,
                        // clear it and fetch the data again
                        if (items == null)
                        {
                            //this._sessionCacheHelper.ClearCache();
                            items = this.GetNavigationNodeItems(resultSourceName);
                        }
                    }

                    using (new SPMonitoredScope("GetNavigationNodeTerms"))
                    {
                        // Get navigation terms from taxonomy
                        terms = this.GetNavigationNodeTerms(web, navigationTermSet.Terms);

                        // If the cache contains corrupted data,
                        // clear it and fetch the data again
                        if ((terms == null) || !terms.Any())
                        {
                            //this._appCacheHelper.ClearCache(AgropurCache.MainMenuNavigationNodesKey.Prefix);
                            terms = this.GetNavigationNodeTerms(web, navigationTermSet.Terms);
                        }
                    }

                    using (new SPMonitoredScope("MapNavigationNodeTree"))
                    {
                        // Map navigation terms to node object, including search items
                        nodes = this.MapNavigationNodeTree(terms, items);
                    }

                    var nodesArray = nodes as NavigationNode[] ?? nodes.ToArray();
                    this.logger.Info("GetAllNavigationNodes: Found {0} navigation nodes in result source '{1}'.", nodesArray.Length, resultSourceName);
                    return nodesArray;
                }
            }
            catch (Exception ex)
            {
                this.logger.Error("GetAllNavigationNodes: {0}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the navigation node terms.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="navigationTerms">The navigation terms.</param>
        /// <param name="maxLevel">The maximum childs level.</param>
        /// <returns>A navigation node tree.</returns>
        public IEnumerable<INavigationNode> GetNavigationNodeTerms(SPWeb web, IEnumerable<NavigationTerm> navigationTerms)
        {
            return this.GetNavigationNodeTerms(web, navigationTerms, int.MaxValue);
        }

        /// <summary>
        /// Gets the navigation node terms.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="navigationTerms">The navigation terms.</param>
        /// <param name="maxLevel">The maximum childs level.</param>
        /// <returns>A navigation node tree.</returns>
        public IEnumerable<INavigationNode> GetNavigationNodeTerms(SPWeb web, IEnumerable<NavigationTerm> navigationTerms, int maxLevel)
        {
            // Navigation terms needs to be editable to get the description
            var session = new TaxonomySession(web.Site);
            var terms = navigationTerms as NavigationTerm[] ?? navigationTerms.Where(x => !x.ExcludeFromGlobalNavigation).ToArray();
            var nodes = terms.Select(x => new NavigationNode(x.GetAsEditable(session))).ToArray();

            if (maxLevel > 0)
            {
                for (var i = 0; i < terms.Length; i++)
                {
                    var term = terms[i];
                    var node = nodes[i];

                    // If term contains children, recurvise call
                    if (term.Terms.Count > 0)
                    {
                        node.ChildNodes = this.GetNavigationNodeTerms(web, term.Terms, maxLevel - 1);
                    }
                }
            }

            return nodes;
        }

        private IEnumerable<INavigationNode> GetNavigationNodeItems(string resultSourceName)
        {
            // Use 'all menu items' result source for search query
            var searchResultSource = this.searchHelper.GetResultSourceByName(resultSourceName, SPContext.Current.Site, SearchObjectLevel.Ssa);

            // Build query to return items in current variation label language
            //var currentLabel = PublishingWeb.GetPublishingWeb(SPContext.Current.Web).Label;
            //var labelLocalAgnosticLanguage = currentLabel.Language.Split('-').First();
            var labelLocalAgnosticLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var query = new KeywordQuery(SPContext.Current.Web)
            {
                SourceId = searchResultSource.Id,
                QueryText = string.Format("{0}:{1}", PortalManagedProperties.ItemLanguage, labelLocalAgnosticLanguage),
                TrimDuplicates = false
            };

            query.SelectProperties.AddRange(new List<string>(PortalManagedProperties.FriendlyUrlRequiredProperties) { PortalManagedProperties.Title }.ToArray());

            var tables = new SearchExecutor().ExecuteQuery(query);
            if (tables.Exists(KnownTableTypes.RelevantResults))
            {
                // Build navigation nodes for search results
                var results = tables.Filter("TableType", KnownTableTypes.RelevantResults).Single(relevantTable => relevantTable.QueryRuleId == Guid.Empty);
                var nodes = results.Table.Rows.Cast<DataRow>().Select(row => new NavigationNode(row, PortalManagedProperties.PortalNavigation));
                this.logger.Info("GetNavigationNodeItems: Found {0} items with search query '{1}' from source '{2}'.", results.Table.Rows.Count, query.QueryText, resultSourceName);

                return nodes;
            }

            this.logger.Error("GetNavigationNodeItems: No relevant results table found with search query '{0}' from source '{1}'.", query.QueryText, resultSourceName);

            return new List<INavigationNode>();
        }

        private IEnumerable<INavigationNode> MapNavigationNodeTree(IEnumerable<INavigationNode> navigationTerms, IEnumerable<INavigationNode> navigationItems)
        {
            // Initialize current navigation term, current navigation branch terms, navigation items and navigation terms
            var currentTerm = TaxonomyNavigationContext.Current.NavigationTerm;
            var currentBranchTerms = this.navigationHelper.GetNavigationParentTerms(currentTerm).ToArray();
            var items = navigationItems == null ? new INavigationNode[] { } : navigationItems.ToArray();

            // Set branch properties for current navigation context
            var terms = navigationTerms.ToList();
            terms.ForEach(x => x.SetCurrentBranchProperties(currentTerm, currentBranchTerms));

            // For each term, map their child terms with recursive call
            for (var i = 0; i < terms.Count; i++)
            {
                var term = terms[i];
                var childNodes = new List<INavigationNode>();

                // If search item found, add it to child items
                var matchingItems = items.Where(x => x.ParentNodeId.Equals(term.Id));
                foreach (var matchingItem in matchingItems)
                {
                    // Item is only in current branch it's the current item
                    if (this.catalogNavigation.IsCurrentItem(matchingItem.Url))
                    {
                        matchingItem.IsNodeInCurrentBranch = currentBranchTerms.Any(y => y.Id.Equals(term.Id));
                    }

                    childNodes.Add(matchingItem);
                }

                // If term contains children, recurvise call
                if (term.ChildNodes != null && term.ChildNodes.Any())
                {
                    childNodes.AddRange(this.MapNavigationNodeTree(term.ChildNodes, items));
                }

                term.ChildNodes = childNodes;
            }

            return terms;
        }
    }
}
