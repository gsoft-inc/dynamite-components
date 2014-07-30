using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.Contracts.Config
{
    public interface IPortalTermStoreConfig
    {
        /// <summary>
        /// Term set group for global term sets
        /// </summary>
        string NavigationGroup { get; }

        /// <summary>
        /// Term set group for Catalogs term sets
        /// </summary>
        string CatalogsGroup { get; }

        /// <summary>
        /// The term set for static content catalogs
        /// </summary>
        string StaticContentCatalogTermSet { get; }

        /// <summary>
        /// The news catalog term set
        /// </summary>
        string NewsCatalogTermSet { get; }

        /// <summary>
        /// Term set group for General Content term sets
        /// </summary>
        string GeneralGroup { get; }

        /// <summary>
        /// The related subject (free tagging) term set
        /// </summary>
        string RelatedSubjectsTermSet { get; }

        /// <summary>
        /// Fetches the term set name for the specified culture's site navigation
        /// </summary>
        /// <param name="lcid">The culture we want to navigate in</param>
        /// <returns>The name of the term set (which should be part of the NavigationGroup</returns>
        string GetNavigationTermSetNameByLCID(int lcid);
    }
}
