using GSoft.Dynamite.Portal.Contracts.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.Core.Config
{
    /// <summary>
    /// Default term store configuration for Portal
    /// </summary>
    public class DefaultTermStoreConfig : IPortalTermStoreConfig
    {
        /// <summary>
        /// Term set group for global term sets
        /// </summary>
        public string NavigationGroup
        {
            get 
            { 
                return "Portal - Navigation"; 
            }
        }

        /// <summary>
        /// Term set group for Catalogs term sets
        /// </summary>
        public string CatalogsGroup
        {
            get
            {
                return "Portal - Catalogs";
            }
        }

        /// <summary>
        /// Term set group for General Content term sets
        /// </summary>
        public string GeneralGroup
        {
            get
            {
                return "Portal - General";
            }
        }

        /// <summary>
        /// The term set for static content catalogs
        /// </summary>
        public string StaticContentCatalogTermSet
        {
            get
            {
                return "Catalog-StaticContent";
            }
        }

        /// <summary>
        /// The news catalog term set
        /// </summary>
        public string NewsCatalogTermSet
        {
            get
            {
                return "Catalog-News";
            }
        }

        /// <summary>
        /// The related subject (free tagging) term set
        /// </summary>
        public string RelatedSubjectsTermSet
        {
            get 
            {
                return "Related Subjects";
            }
        }

        /// <summary>
        /// Fetches the term set name for the specified culture's site navigation
        /// </summary>
        /// <param name="lcid">The culture we want to navigate in</param>
        /// <returns>The name of the term set (which should be part of the NavigationGroup</returns>
        public string GetNavigationTermSetNameByLCID(int lcid)
        {
            string termSetName = string.Empty;

            if (lcid == Language.English.Culture.LCID)
            {
                termSetName = "Navigation EN";
            }
            else if (lcid == Language.French.Culture.LCID)
            {
                termSetName = "Navigation FR";
            }
            else
            {
                throw new ArgumentOutOfRangeException("lcid");
            }

            return termSetName;
        }
    }
}
