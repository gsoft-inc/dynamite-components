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
                                    this.EnsureRecursiveSyncToTargetTermSet(term, peerTermSet, webLanguage, isSourceVariationWeb);

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
        ////[Obsolete("Deleting terms upon item or page deletion is considered overzealous and potentially harmful. Before v3.0.2, this method's implementation would cause tons of Orphaned Terms because it didn't check for reuses and would delete source terms. Right now it's only still around to compensate for the OOTB implementation which causes similar eregious Orphaned Terms.")]
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
                        // Use the ambient web (or top level parent web's) navigation settings to figure out the correct 
                        // navigation term set to fetch the term from.
                        SPWeb webWithNavSettings = null;
                        var webNavSettings = FindTaxonomyWebNavigationSettingsInWebOrInParents(item.Web, out webWithNavSettings);
                        var taxonomySession = new TaxonomySession(item.Web.Site);
                        var termStore = taxonomySession.TermStores[webNavSettings.GlobalNavigation.TermStoreId];
                        var termSet = termStore.GetTermSet(webNavSettings.GlobalNavigation.TermSetId);
                        var term = termSet.GetTerm(new Guid(termValue.TermGuid));
                        var termLabel = term.GetDefaultLabel(webLanguage);

                        // Default OOTB behavior when page is deleted: The PagesListCPVEventReceiver calls FriendlyUrlEventReceiver.ItemDeleted, which will
                        // 1) if related navigation term has children, term will not be deleted (only changed to SimpleLink mode with blank target URL)
                        // 2) if related navigation term is a term reuse/pin, term reuse/pin will not be deleted (only changed to SimpleLink mode with blank target URL)
                        // 3) any other case, term will be deleted (which might be unfortunate in the case that the term was a SourceTerm for other reuses and/or pins)
                        // In other words: in case 3), the OOTB event receivers will cause Orphaned Terms by deleting source terms without making sure to clean up
                        // the reuses and/or pins beforehand. This sucks because the GUID of Orphaned Terms cannot be used again from that point on.
                        //
                        // Our goal is to pre-empt the ItemDeleted event recever by deleting the Navigation term's reuses (if they don't have any children of their own)
                        // before the OOTB event has a chance to run and cause mayhem and tons of Orphaned Terms.
                        if (term.TermsCount > 0)
                        {
                            this.logger.Info("Unable to delete the term {0} with id {1}: the term has children. Delete all children before deleting this term.", termLabel, term.Id);
                        }
                        else if (term.IsSourceTerm && term.IsReused)
                        {
                            // Term has no children but has re-uses: gotta get rid of those pins/reuses before attempting to delete
                            foreach (var termReuse in term.ReusedTerms)
                            {
                                if (termReuse.TermsCount > 0)
                                {
                                    this.logger.Warn("Unable to delete the term {0} with id {1}: one of the term's reuses/pins has children. Delete all children of that term reuse within termset {2} before deleting this term.", termLabel, term.Id, termReuse.TermSet.Name);
                                    return;
                                }

                                if (termReuse.IsPinned && !termReuse.IsPinnedRoot)
                                {
                                    this.logger.Warn("Unable to delete the term {0} with id {1}: one of the term's reuses/pins is a pin but not a pin root (within term set {2}). We'll let the OOTB event receiver cause the orphan term, too bad. Avoid pinned terms in favor of reuses, if you can.", termLabel, term.Id, termReuse.TermSet.Name);
                                    return;
                                }

                                // Either a childless reuse or pin root: deleting should be allowed (only in those two cases - leaf term re-use deletion has minimal impact and 
                                // only root-pin terms can be deleted without causing orphaned terms).
                                termReuse.Delete();
                                this.logger.Info("Deleting reuse of term {0} with id {1} from term set {2}.", termLabel, term.Id, termReuse.TermSet.Name);
                            }

                            // Re-fetch source term before attempting to delete it because its instance is now stale (we just delete all of its reuses and pins)
                            term = term.TermSet.GetTerm(term.Id);
                            term.Delete();
                            this.logger.Info("Deleting term {0} with id {1} from term set {2} (now that all its pins/reuses were childless and got deleted).", termLabel, term.Id, term.TermSet.Name);
                            termStore.CommitAll();
                        }
                        else if (term.IsSourceTerm && !term.IsReused)
                        {
                            // Term has no children and no re-uses: DELETE IT!
                            term.Delete();
                            this.logger.Info("Deleting term {0} with id {1} from term set {2} (because it is childless and has no pins/reuses).", termLabel, term.Id, term.TermSet.Name);
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

        private void EnsureRecursiveSyncToTargetTermSet(Term term, TermSet peerTermSet, int webLanguage, bool isSourceVariationWeb)
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
                                // Ensure a full parent-to-grandchildren re-use hierarchy (so that we get the benefits of hierarchy sync that comes with pinning,
                                // without the drawback of having the target hierarchy entirely stuck to the source hierarchy).
                                // Pinning is also a problem because deleting a single child term on the source hierarchy will cause orphaned terms at the destination pinned hierarhcy.
                                // Looks like pinning is/was broken by design (depending on whether that has been patched already in more recent CUs than the old-ish version I'm running now).
                                var newlyReusedPeer = reusedParentTerm.ReuseTerm(term, true);   // Using "true" as second argument sync the entire branch of child terms
                            }
                        }
                        else
                        {
                            this.logger.Warn("The parent term {0} of the term {1} was not found in the term set {2}", parentTermlabel, term.Id, peerTermSet.Name);
                        }
                    }
                    else
                    {
                        // Our parent term isn't re=used, so we need to recurse "up" to reach a parent we can re-use from instead.
                        // Re-using from the topmost parent we can find (or term set) will let us go down the parent-to-grandchildren chain 
                        // to do a pseudo-pinning operation (but just a full-child-herarchy of synced up re-uses, not a rigid unchangeable 
                        // pinned hierarchy)
                        this.EnsureRecursiveSyncToTargetTermSet(parentTerm, peerTermSet, webLanguage, isSourceVariationWeb);
                    }
                }
            }
            else
            {
                if (isSourceVariationWeb)
                {
                    // Pseudo-pin the term at root of peer term set (same reasons as above, will bring along all child terms 
                    // to the target term set)
                    var newlyReusedRootTerm = peerTermSet.ReuseTerm(term, true);
                }
            }
        }
    }
}
