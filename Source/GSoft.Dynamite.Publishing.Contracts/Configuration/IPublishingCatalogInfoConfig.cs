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
    }
}