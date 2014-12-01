using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the catalogs settings. Catalogs are only used with Cross Site Publishing based solutions
    /// </summary>
    public class PublishingCatalogInfoConfig : IPublishingCatalogInfoConfig
    {
        private readonly PublishingCatalogInfos _catalogInfoValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="catalogInfoValues">The catalog info objects configuration</param>
        public PublishingCatalogInfoConfig(PublishingCatalogInfos catalogInfoValues)
        {
            this._catalogInfoValues = catalogInfoValues;
        }

        /// <summary>
        /// Property that return all the catalogs to use in the publishing module
        /// </summary>
        /// <returns>Teh catalogs</returns>
        public IList<CatalogInfo> Catalogs
        {
            get
            {
                var catalogs = new List<CatalogInfo>
                {
                    this._catalogInfoValues.NewsPages(),
                    this._catalogInfoValues.ContentPages()
                };

                return catalogs;
            }
        }
    }
}
