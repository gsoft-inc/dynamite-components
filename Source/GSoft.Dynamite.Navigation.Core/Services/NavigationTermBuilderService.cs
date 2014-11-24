using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    public class NavigationTermBuilderService : INavigationTermBuilderService
    {
        private readonly ITaxonomyService taxonomyService;
        private readonly INavigationHelper navigationHelper;
        private readonly PublishingFieldInfos publishingFieldInfos;

        public NavigationTermBuilderService(ITaxonomyService taxonomyService, INavigationHelper navigationHelper, PublishingFieldInfos publishingFieldInfos)
        {
            this.taxonomyService = taxonomyService;
            this.navigationHelper = navigationHelper;
            this.publishingFieldInfos = publishingFieldInfos;
        }

        /// <summary>
        /// Associtate the current page to its navigation navigation via a term driven page url
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

                        var termDrivenpage = new TermDrivenPageSettingInfo(termInfo, pageUrl, null, null, null, false,
                            false);

                        this.navigationHelper.SetTermDrivenPageSettings(site, termDrivenpage);
                    }
                }             
            }
        }

        /// <summary>
        /// Sync the associated navigation taxonomy term with other term sets for multilnigual support
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
                                    //Get all term sets where this term is reused
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
