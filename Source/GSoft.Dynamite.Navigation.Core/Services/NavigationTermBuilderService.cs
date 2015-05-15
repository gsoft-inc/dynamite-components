using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Caml;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;
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
        private readonly IVariationHelper variationHelper;
        private readonly IPublishingFieldInfoConfig publishingFieldConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger">The logger helper</param>
        /// <param name="taxonomyService">The taxonomy service helper</param>
        /// <param name="navigationHelper">The navigation helper</param>
        /// <param name="variationHelper">The variation helper</param>
        /// <param name="publishingFieldConfig">The publishing field info objects</param>
        public NavigationTermBuilderService(ILogger logger, ITaxonomyService taxonomyService, INavigationHelper navigationHelper, IVariationHelper variationHelper, IPublishingFieldInfoConfig publishingFieldConfig)
        {
            this.taxonomyService = taxonomyService;
            this.navigationHelper = navigationHelper;
            this.logger = logger;
            this.variationHelper = variationHelper;
            this.publishingFieldConfig = publishingFieldConfig;
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

            var pagesLib = web.GetPagesLibrary();
            foreach (SPListItem page in pagesLib.Items)
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
                var navigationFieldName = this.publishingFieldConfig.GetFieldById(PublishingFieldInfos.Navigation.Id).InternalName;

                if (item.Fields.ContainsField(navigationFieldName))
                {
                    var termValue = item[navigationFieldName] as TaxonomyFieldValue;

                    if (termValue != null)
                    {
                        var pageUrl = "~site/" + item.Url;
                        var termInfo = new TermInfo(new Guid(termValue.TermGuid), string.Empty, null);
                        var termDrivenpage = new TermDrivenPageSettingInfo(termInfo, pageUrl, null, null, null, false, false);

                        this.navigationHelper.SetTermDrivenPageSettings(site, termDrivenpage);
                    }
                }
            }
        }

        /// <summary>
        /// Sync the associated navigation taxonomy term with other navigation term sets for multilingual support
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current item</param>
        public void SyncNavigationTerm(SPSite site, SPListItem item)
        {
            if (item != null)
            {
                var itemNavigationFieldName = this.publishingFieldConfig.GetFieldById(PublishingFieldInfos.Navigation.Id).InternalName;

                if (item.Fields.ContainsField(itemNavigationFieldName))
                {
                    var termValue = item[itemNavigationFieldName] as TaxonomyFieldValue;

                    if (termValue != null)
                    {
                        var currentWeb = item.Web;
                        var publishingWeb = PublishingWeb.GetPublishingWeb(currentWeb);
                        var isSourceVariationWeb = this.variationHelper.IsCurrentWebSourceLabel(currentWeb);
                        var peerNavigationTermSets = new List<Guid>();
                        var webLanguage = item.Web.Locale.LCID;

                        // Get the current term associated with the page
                        var term = this.taxonomyService.GetTermForId(site, new Guid(termValue.TermGuid));
                        var termLabel = term.GetDefaultLabel(webLanguage);
                        var termStore = term.TermStore;
                        var isSyncAvailable = true;

                        // In XSP scenario we can't use the associated navigation term sets according to variations because we work in the authoring site and not in the publishing site 
                        // (a different managed navigation setting can be used between publishing and authoring)
                        // The only case when the sync is possible is when the navigation of the current web uses the term set acts
                        // as navigation classification term set for the content. Else, it's mean we are on an authoring site.
                        var currentWebNavigationSettings = TaxonomyNavigation.GetWebNavigationSettings(currentWeb);
                        if (currentWebNavigationSettings != null)
                        {
                            var currentWebNavigationTermSetId = currentWebNavigationSettings.GlobalNavigation.TermSetId;

                            var navigationField = item.Fields.GetFieldByInternalName(itemNavigationFieldName) as TaxonomyField;

                            if (navigationField != null)
                            {
                                // Get the term set associated with the field in the list
                                var navigationTermSetFromColumn = navigationField.TermSetId;

                                if (currentWebNavigationTermSetId != navigationTermSetFromColumn)
                                {
                                    isSyncAvailable = false;
                                }
                            }
                        }

                        if (isSyncAvailable)
                        {
                            // Check if there are some peer webs and add corresponding navigation term sets if so
                            if (publishingWeb.VariationPublishingWebUrls.Count > 0)
                            {
                                foreach (var peerWebUrl in publishingWeb.VariationPublishingWebUrls)
                                {
                                    var peerSite = new SPSite(peerWebUrl);
                                    var peerWeb = peerSite.OpenWeb();

                                    var webNavigationSettings = TaxonomyNavigation.GetWebNavigationSettings(peerWeb);

                                    if (webNavigationSettings != null)
                                    {
                                        // Add peer term sets Id
                                        peerNavigationTermSets.Add(webNavigationSettings.GlobalNavigation.TermSetId);
                                    }

                                    peerWeb.Dispose();
                                    peerSite.Dispose();
                                }
                            }

                            foreach (var termSetId in peerNavigationTermSets)
                            {
                                // Open the peer term set
                                var termSet = termStore.GetTermSet(termSetId);
                                var termExists = false;

                                // Check if the current term is already resued in the peer term set
                                if (term.IsReused)
                                {
                                    var reusedTerm = term.ReusedTerms.FirstOrDefault(t => t.TermSet.Id.Equals(termSet.Id));
                                    if (reusedTerm == null)
                                    {
                                        this.logger.Warn("The term {0} with id {1} already exists in the term set with name {2} and id {3}", termLabel, term.Id, termSet.Name, termSet.Id);
                                        termExists = true;
                                    }
                                }

                                // Check if the current term is under a parent one
                                if (!termExists)
                                {
                                    if (!term.IsRoot)
                                    {
                                        // Check if the parent is reused in the peer term set
                                        var parentTerm = term.Parent;
                                        var parentTermlabel = parentTerm.GetDefaultLabel(webLanguage);

                                        if (parentTerm != null)
                                        {
                                            if (parentTerm.IsReused)
                                            {
                                                // Get the reuse in the peer term set. Note that it can exist only one reuse of a term in a term set (FirstOrDefault)
                                                var reusedTerm = parentTerm.ReusedTerms.FirstOrDefault(t => t.TermSet.Id.Equals(termSet.Id));

                                                if (reusedTerm != null)
                                                {
                                                    if (isSourceVariationWeb)
                                                    {
                                                        // Pin the term in peer term sets
                                                        // We use a pin instead of reuse to reproduce the behavior of the SharePoint variations system. One term set acts as source term set with more targets term sets. We have this information with associated variations webs.
                                                        // If you are creating a term in a peer term set, that's mean you are creating an orphan page which doesn't need to be synced with the source term set (like varaitions do)
                                                        // A pin is also useful for deleting scenarios (see DeleteAssociatedPageTerm method). Pin = hard link between terms
                                                        reusedTerm.ReuseTermWithPinning(term);
                                                    }
                                                }
                                                else
                                                {
                                                    this.logger.Warn("The parent term {0} of the term {1} was not found in the term set {2}", parentTermlabel, term.Id, termSet.Name);
                                                }
                                            }
                                            else
                                            {
                                                // Don't try to recreate the same parent hierarchy here. Too much assumptions about what the user really wants here. In doubt don't do anything
                                                this.logger.Warn("Unable to reuse the term {0}. The parent term {1} of the term {2} is not reused in the peer term set {3}. ", termLabel, parentTermlabel, term.Id, termSet.Name);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (isSourceVariationWeb)
                                        {
                                            // Pin the term at root of peer term set (same reasons as above)
                                            termSet.ReuseTermWithPinning(term);
                                        }
                                    }

                                    termStore.CommitAll();
                                }
                            }
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
                var itemNavigationFieldName = this.publishingFieldConfig.GetFieldById(PublishingFieldInfos.Navigation.Id).InternalName;

                if (item.Fields.ContainsField(itemNavigationFieldName))
                {
                    var webLanguage = item.Web.Locale.LCID;
                    var termValue = item[itemNavigationFieldName] as TaxonomyFieldValue;

                    if (termValue != null)
                    {
                        var term = this.taxonomyService.GetTermForId(site, new Guid(termValue.TermGuid));
                        var termLabel = term.GetDefaultLabel(webLanguage);
                        var termStore = term.TermStore;

                        // If the term has children we don't do anything to avoid mistakes (accidently ruining a contributor's entire navigation hierarchy, for instance)
                        if (term.TermsCount > 0)
                        {
                            this.logger.Warn("Unable to delete the term {0} with id {1}: the term has children. Delete all children before deleting this term", termLabel, term.Id);
                        }
                        else
                        {
                            // Pinned term behavior 
                            // If the term is the source for pinning then all pinned terms will be deleted automatically in target term sets. By default SharePoint doesn't care about children
                            // and the whole branch will be deleted (That's why we check before)
                            // However, if the term is not the source, it will be deleted only in the target term set, not in the source one

                            // Reused term behavior
                            // If the term is the source for reusing then all reused terms in target term sets WON'T BE removed
                            // However, those terms will be placed into the Sytem group in the "Orphaned Terms" term set. When they are here, it is not possible to delete them
                            // If the term is not the source, it will be deleted only in the target term set, not in the source one
                            term.Delete();
                            termStore.CommitAll();
                        }
                    }
                }
            }
        }
    }
}
