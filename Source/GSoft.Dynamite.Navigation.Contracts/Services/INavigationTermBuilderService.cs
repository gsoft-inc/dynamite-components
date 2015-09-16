using System;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Services
{
    /// <summary>
    /// Interface for the navigation builder service used for the navigation structure management.
    /// </summary>
    public interface INavigationTermBuilderService
    {
        /// <summary>
        /// Associate all pages in the sites pages library to its navigation via a term driven page url.
        /// Only pages with the Dynamite taxonomy navigation field that have a none null value will be set.
        /// </summary>
        /// <param name="web">The web where the pages library is located.</param>
        void SetTermDrivenPageForTerms(SPWeb web);

        /// <summary>
        /// Associates the current page to its navigation navigation via a term driven page url
        /// </summary>
        /// <param name="item">The current page item</param>
        void SetTermDrivenPageForTerm(SPListItem item);

        /// <summary>
        /// Deletes the term associated to a page if the page is deleted
        /// </summary>
        /// <param name="item">The current page item</param>
        [Obsolete("Deleting terms upon item or page deletion is considered overzealous and potentially harmful. Before v3.0.2, this method's implementation would cause tons of Orphaned Terms because it didn't check for reuses and would delete source terms.")]
        void DeleteAssociatedPageTerm(SPListItem item);

        /// <summary>
        /// Synchronizes the associated navigation taxonomy term with other term sets for multilingual support
        /// </summary>
        /// <param name="item">The current item</param>
        void SyncNavigationTerm(SPListItem item);
    }
}
