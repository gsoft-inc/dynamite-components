using System;
using System.Collections.Generic;
using GSoft.Dynamite.Caml;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    /// <summary>
    /// Service for the target pages manipulation and navigation structure management
    /// </summary>
    public class NavigationTermBuilderService : INavigationTermBuilderService
    {
        private readonly ITaxonomyService taxonomyService;
        private readonly INavigationHelper navigationHelper;
        private readonly ILogger logger;
        private readonly ICamlBuilder caml;
        private readonly PublishingFieldInfos publishingFieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger">The logger helper</param>
        /// <param name="taxonomyService">The taxonomy service helper</param>
        /// <param name="navigationHelper">The navigation helper</param>
        /// <param name="caml">The CAML builder helper</param>
        /// <param name="publishingFieldInfos">The publishing field info objects</param>
        public NavigationTermBuilderService(ILogger logger, ITaxonomyService taxonomyService, INavigationHelper navigationHelper, ICamlBuilder caml, PublishingFieldInfos publishingFieldInfos)
        {
            this.taxonomyService = taxonomyService;
            this.navigationHelper = navigationHelper;
            this.logger = logger;
            this.caml = caml;
            this.publishingFieldInfos = publishingFieldInfos;
        }

        /// <summary>
        /// Associate all pages in the sites pages library to its navigation via a term driven page url.
        /// Only pages with the Dynamite taxonomy navigation field that have a none null value will be set.
        /// </summary>
        /// <param name="web">The web where the pages library is located.</param>
        public void SetTermDrivenPageForTerms(SPWeb web)
        {
            if (web == null)
            {
                this.logger.Error("Unable to set term driven page for terms because no web was passed.");
                return;
            }

            // Prepare the query to get the pages that have a value in the navigation column
            var itemNavigationFieldName = this.publishingFieldInfos.Navigation().InternalName;
            var pagesLib = web.GetPagesLibrary();
            var query = new SPQuery().Query =
                this.caml.Where(
                        this.caml.IsNotNull(this.caml.FieldRef(itemNavigationFieldName)));

            // Execute the query and loop on each page.
            var pages = pagesLib.GetItems(query);
            foreach (SPListItem page in pages)
            {
                this.SetTermDrivenPageForTerm(web.Site, page);
            }
        }

        /// <summary>
        /// Associate the current page to its navigation navigation via a term driven page url
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current page item</param>
        public void SetTermDrivenPageForTerm(SPSite site, SPListItem item)
        {
            if (item != null)
            {
                var itemNavigationFieldName = this.publishingFieldInfos.Navigation().InternalName;

                if (item.Fields.ContainsField(itemNavigationFieldName))
                {
                    var termValue = item[itemNavigationFieldName] as TaxonomyFieldValue;

                    if (termValue != null)
                    {
                        var pageUrl = "~site/" + item.Url;
                        var termInfo = new TermInfo(new Guid(termValue.TermGuid), string.Empty, null);

                        var termDrivenpage = new TermDrivenPageSettingInfo(
                            termInfo, 
                            pageUrl, 
                            null, 
                            null, 
                            null, 
                            false,
                            false);

                        this.navigationHelper.SetTermDrivenPageSettings(site, termDrivenpage);
                    }
                }             
            }
        }

        /// <summary>
        /// Sync the associated navigation taxonomy term with other term sets for multilingual support
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current item</param>
        public void SyncNavigationTerm(SPSite site, SPListItem item)
        {
            if (item != null)
            {
                var itemNavigationFieldName = this.publishingFieldInfos.Navigation().InternalName;

                if (item.Fields.ContainsField(itemNavigationFieldName))
                {
                    var termValue = item[itemNavigationFieldName] as TaxonomyFieldValue;

                    if (termValue != null)
                    {
                        var term = this.taxonomyService.GetTermForId(site, new Guid(termValue.TermGuid));

                        var termStore = term.TermStore;

                        if (!term.IsReused)
                        {
                            // Check if the parent is reused
                            var parentTerm = term.Parent;

                            if (parentTerm != null)
                            {
                                if (parentTerm.IsReused)
                                {
                                    // Get all term sets where this term is reused
                                    foreach (var reusedTerm in parentTerm.ReusedTerms)
                                    {
                                        var reusedTermSet = reusedTerm.TermSet;
                                        var originalTerm = reusedTermSet.GetTerm(parentTerm.Id);

                                        // Add the term
                                        originalTerm.ReuseTermWithPinning(term);
                                    }
                                }
                            }
                            else
                            {
                                var termSet = term.TermSet;

                                // Check if termset terms are reused
                                var terms = termSet.GetAllTerms();

                                var containsReusedTerms = false;
                                var reusedTermSets = new List<TermSet>();

                                foreach (var currentTerm in terms)
                                {
                                    if (currentTerm.IsReused && !containsReusedTerms)
                                    {
                                        foreach (var reusedTerm in currentTerm.ReusedTerms)
                                        {
                                            if (!reusedTermSets.Contains(reusedTerm.TermSet))
                                            {
                                                reusedTermSets.Add(reusedTerm.TermSet);
                                            }                                            
                                        }
                                       
                                        containsReusedTerms = true;
                                    }
                                }

                                if (containsReusedTerms)
                                {
                                    foreach (var reusedTermSet in reusedTermSets)
                                    {
                                        reusedTermSet.ReuseTermWithPinning(term);
                                    }
                                }
                            }

                            termStore.CommitAll();
                        }                       
                    }
                }
            }
        }

        /// <summary>
        /// Delete the term associated to a page if the page is deleted
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current page item</param>
        public void DeleteAssociatedPageTerm(SPSite site, SPListItem item)
        {
            if (item != null)
            {
                var itemNavigationFieldName = this.publishingFieldInfos.Navigation().InternalName;

                if (item.Fields.ContainsField(itemNavigationFieldName))
                {
                    var termValue = item[itemNavigationFieldName] as TaxonomyFieldValue;

                    if (termValue != null)
                    {
                        // Delete the term and its reuses
                        var term = this.taxonomyService.GetTermForId(site, new Guid(termValue.TermGuid));

                        if (term.IsReused)
                        {
                            foreach (var reusedTerm in term.ReusedTerms)
                            {
                                reusedTerm.Delete();
                            }
                        }

                        // Delete the term after all reuses deletes
                        term = this.taxonomyService.GetTermForId(site, new Guid(termValue.TermGuid));
                        var termStore = term.TermStore;
                        term.Delete();
                        termStore.CommitAll();
                    }
                }
            }
        }
    }
}
