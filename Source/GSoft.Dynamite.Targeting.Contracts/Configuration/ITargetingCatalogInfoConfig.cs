using System;
using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;

namespace GSoft.Dynamite.Targeting.Contracts.Configuration
{
    /// <summary>
    /// Interface for the configuration of catalogs settings in the targeting module.
    /// </summary>
    public interface ITargetingCatalogInfoConfig
    {
        /// <summary>
        /// Property that return all the catalogs to use in the targeting module
        /// </summary>
        IList<CatalogInfo> Catalogs { get; }

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        CatalogInfo GetCatalogInfoByWebRelativeUrl(string webRelativeUrl);

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        CatalogInfo GetCatalogInfoByWebRelativeUrl(Uri webRelativeUrl);
    }
}
