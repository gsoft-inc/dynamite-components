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
using GSoft.Dynamite.Sites;
using GSoft.Dynamite.Taxonomy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Utilities;

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
        public NavigationTermBuilderService(
            ILogger logger, 
            ITaxonomyService taxonomyService, 
            INavigationHelper navigationHelper, 
            IVariationHelper variationHelper, 
            IPublishingFieldInfoConfig publishingFieldConfig)
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
                this.SetTermDrivenPageForTerm(page);
            }
        }

        /// <summary>
        /// Associate the current page to its navigation navigation via a term driven page url
        /// </summary>
        /// <param name="item">The current page item</param>
        public void SetTermDrivenPageForTerm(SPListItem item)
        {
            if (item != null)
            {
                var navigationFieldName = this.publishingFieldConfig.GetFieldById(PublishingFieldInfos.Navigation.Id).InternalName;

                if (item.Fields.ContainsField(navigationFieldName))
                {
                    var termValue = item[navigationFieldName] as TaxonomyFieldValue;

                    if (termValue != null)
                    {
                        TaxonomyField taxoFieldOnList = (TaxonomyField)item.ParentList.Fields[PublishingFieldInfos.Navigation.Id];
                        var termSetId = taxoFieldOnList.TermSetId;
                        var termStoreId = taxoFieldOnList.SspId;

                        var session = new TaxonomySession(item.Web.Site);
                        var termStore = session.TermStores[termStoreId];
                        var termSet = termStore.GetTermSet(termSetId);

                        var itemUrl = new SPUrl(item.Web, item.Url);
                        var pageUrl = SPUtility.ConcatUrls("~sitecollection/", itemUrl.AbsoluteUrl.AbsolutePath);
                        var termInfo = new TermInfo(new Guid(termValue.TermGuid), termValue.Label, new TermSetInfo(termSet));
                        var termDrivenpage = new TermDrivenPageSettingInfo(termInfo, pageUrl, null, null, null, false, false);

                        this.navigationHelper.SetTermDrivenPageSettings(item.Web, termDrivenpage);
                    }
                }
            }
        }

        /// <summary>
        /// Sync the associated navigation taxonomy term with other navigation term sets for multilingual support
        /// </summary>
        /// <param name="item">The current item</param>
        public void SyncNavigationTerm(SPListItem item)
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

                        // Get the web-specific navigation settings
                        SPWeb webWithReturnedSettings = null;
                        var webNavigationSettings = FindTaxonomyWebNavigationSettingsInWebOrInParents(currentWeb, out webWithReturnedSettings);
                        var taxonomySession = new TaxonomySession(currentWeb.Site);
                        var termStore = taxonomySession.TermStores[webNavigationSettings.GlobalNavigation.TermStoreId];
                        var termSet = termStore.GetTermSet(webNavigationSettings.GlobalNavigation.TermSetId);

                        var isSourceVariationWeb = this.variationHelper.IsCurrentWebSourceLabel(currentWeb);
                        var peerNavigationTermSetIds = new List<Guid>();
                        var webLanguage = item.Web.Locale.LCID;

                        // Get the current term associated with the page
                        var term = termSet.GetTerm(new Guid(termValue.TermGuid));
                        var termLabel = term.GetDefaultLabel(webLanguage);
                        var isSyncAvailable = true;

                        // In XSP scenario we can't use the associated navigation term sets according to variations because we work in the authoring site and not in the publishing site 
                        // (a different managed navigation setting can be used between publishing and authoring)
                        // The only case when the sync is possible is when the navigation of the current web uses the term set acts
                        // as navigation classification term set for the content. Else, it's mean we are on an authoring site.
                        if (webNavigationSettings != null)
                        {
                            var currentWebNavigationTermSetId = webNavigationSettings.GlobalNavigation.TermSetId;

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

                                    SPWeb peerParentWithReturnedSettings = null;
                                    var peerWebNavigationSettings = FindTaxonomyWebNavigationSettingsInWebOrInParents(peerWeb, out peerParentWithReturnedSettings);

                                    if (peerWebNavigationSettings != null)
                                    {
                                        // Add peer term sets Id
                                        peerNavigationTermSetIds.Add(peerWebNavigationSettings.GlobalNavigation.TermSetId);
                                    }

                                    peerWeb.Dispose();
                                    peerSite.Dispose();
                                }
                            }

                            foreach (var termSetId in peerNavigationTermSetIds)
                            {
                                // Open the peer term set
                                var peerTermSet = termStore.GetTermSet(termSetId);
                                var termExists = false;

                                // Check if the current term is already resued in the peer term set
                                if (term.IsReused)
                                {
                                    var reusedTermInPeerTermSet = term.ReusedTerms.FirstOrDefault(t => t.TermSet.Id.Equals(peerTermSet.Id));
                                    if (reusedTermInPeerTermSet != null)
                                    {
                                        this.logger.Warn("The term {0} with id {1} already exists in the term set with name {2} and id {3}", termLabel, term.Id, peerTermSet.Name, peerTermSet.Id);
                                        termExists = true;
                                    }
                                }

                                // Check if the current term is under a parent one
                                if (!termExists)
                                {
                                    this.EnsureRecursiveSyncToTargetTermSet(term, peerTermSet, webLanguage, isSourceVariationWeb, null);

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
        /// <param name="item">The current page item</param>
        public void DeleteAssociatedPageTerm(SPListItem item)
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
                        var term = this.taxonomyService.GetTermForId(item.Web.Site, new Guid(termValue.TermGuid));
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

        private static WebNavigationSettings FindTaxonomyWebNavigationSettingsInWebOrInParents(SPWeb web, out SPWeb webWithNavigationSettings)
        {
            var currentWebNavSettings = new WebNavigationSettings(web);
            webWithNavigationSettings = web;

            if (currentWebNavSettings.GlobalNavigation.Source == StandardNavigationSource.InheritFromParentWeb
                && web.ParentWeb != null)
            {
                // current web inherits its settings from its parent, so we gotta look upwards to the parent webs
                // recursively until we find a match
                return FindTaxonomyWebNavigationSettingsInWebOrInParents(web.ParentWeb, out webWithNavigationSettings);
            }

            return currentWebNavSettings;
        }

        private void EnsureRecursiveSyncToTargetTermSet(Term term, TermSet peerTermSet, int webLanguage, bool isSourceVariationWeb, Term childToEnsure)
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
                        var reusedParentTerm = parentTerm.ReusedTerms.FirstOrDefault(t => t.TermSet.Id.Equals(peerTermSet.Id));

                        if (reusedParentTerm != null)
                        {
                            if (isSourceVariationWeb)
                            {
                                // This may be the termination point of the "down" recursing from parent-to-child-to-grandchild
                                // Pin the term in peer term sets (under the already re-used parent)!
                                // We use a pin instead of reuse to reproduce the behavior of the SharePoint variations system. One term set acts as source term set with more targets term sets. We have this information with associated variations webs.
                                // If you are creating a term in a peer term set, that's mean you are creating an orphan page which doesn't need to be synced with the source term set (like varaitions do)
                                // A pin is also useful for deleting scenarios (see DeleteAssociatedPageTerm method). Pin = hard link between terms
                                reusedParentTerm.ReuseTermWithPinning(term);
                            }
                        }
                        else
                        {
                            this.logger.Warn("The parent term {0} of the term {1} was not found in the term set {2}", parentTermlabel, term.Id, peerTermSet.Name);
                        }
                    }
                    else
                    {
                        // Our parent term isn't re=used, so we need to recurse "up" to reach a parent we can pin instead.
                        // Pinning the parent will bring the term we want to our target term set as well (since pinning 
                        // acts as a full-child-hierarchy reuse).
                        this.EnsureRecursiveSyncToTargetTermSet(parentTerm, peerTermSet, webLanguage, isSourceVariationWeb, term);
                    }
                }
            }
            else
            {
                if (isSourceVariationWeb)
                {
                    // Pin the term at root of peer term set (same reasons as above, will bring along all child terms 
                    // to the target term set)
                    peerTermSet.ReuseTermWithPinning(term);
                }
            }
        }
    }
}
