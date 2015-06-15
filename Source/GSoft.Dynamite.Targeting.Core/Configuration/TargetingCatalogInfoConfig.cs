using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Targeting.Contracts.Configuration;

namespace GSoft.Dynamite.Targeting.Core.Configuration
{
    /// <summary>
    /// Configuration of catalogs settings in the targeting module.
    /// </summary>
    public class TargetingCatalogInfoConfig : ITargetingCatalogInfoConfig
    {
        /// <summary>
        /// Property that return all the catalogs to use in the targeting module
        /// </summary>
        public IList<CatalogInfo> Catalogs
        {
            get
            {
                return new List<CatalogInfo>();
            }
        }

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        public CatalogInfo GetCatalogInfoByWebRelativeUrl(string webRelativeUrl)
        {
            return this.GetCatalogInfoByWebRelativeUrl(new Uri(webRelativeUrl, UriKind.Relative));
        }

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        public CatalogInfo GetCatalogInfoByWebRelativeUrl(Uri webRelativeUrl)
        {
            return this.Catalogs.Single(c => c.WebRelativeUrl.Equals(webRelativeUrl));
        }
    }
}
