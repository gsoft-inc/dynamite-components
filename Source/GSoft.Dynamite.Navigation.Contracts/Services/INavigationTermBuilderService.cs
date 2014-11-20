using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Services
{
    public interface INavigationTermBuilderService
    {
        /// <summary>
        /// Associtate the current page to its navigation navigation via a term driven page url
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current page item</param>
        void SetTermDrivenPageForTerm(SPSite site, SPListItem item);

        /// <summary>
        /// Delete the term associated to a page if the page is deleted
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current page item</param>
        void DeleteAssociatedPageTerm(SPSite site, SPListItem item);

        /// <summary>
        /// Sync the associated navigation taxonomy term with other term sets for multilnigual support
        /// </summary>
        /// <param name="site">The current site</param>
        /// <param name="item">The current item</param>
        void SyncNavigationTerm(SPSite site, SPListItem item);
    }
}
