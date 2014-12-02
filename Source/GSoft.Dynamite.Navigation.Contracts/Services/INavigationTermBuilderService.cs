using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Services
{
    /// <summary>
    /// Interface for the navigation builder service used for the navigation structure management.
    /// </summary>
    public interface INavigationTermBuilderService
    {
        /// <summary>
        /// Associates the current page to its navigation navigation via a term driven page url
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current page item</param>
        void SetTermDrivenPageForTerm(SPSite site, SPListItem item);

        /// <summary>
        /// Deletes the term associated to a page if the page is deleted
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current page item</param>
        void DeleteAssociatedPageTerm(SPSite site, SPListItem item);

        /// <summary>
        /// Synchronizes the associated navigation taxonomy term with other term sets for multilingual support
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current item</param>
        void SyncNavigationTerm(SPSite site, SPListItem item);
    }
}
