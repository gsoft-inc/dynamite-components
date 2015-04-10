using System;
using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration interface for the catalogs settings. Catalogs are only used with Cross Site Publishing based solutions
    /// </summary>
    public interface IPublishingCatalogInfoConfig
    {
        /// <summary>
        /// Property that return all the catalogs to use in the publishing module
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