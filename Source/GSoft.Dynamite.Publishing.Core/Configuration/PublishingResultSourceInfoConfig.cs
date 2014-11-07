using System.Collections.Generic;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the creation of the Result Sources
    /// </summary>
    public class PublishingResultSourceInfoConfig : IPublishingResultSourceInfoConfig
    {
        private readonly PublishingResultSourceInfos resultSourceValues;

        /// <summary>
        /// Constructor of the configuration.
        /// </summary>
        /// <param name="resultSourceValues"></param>
        public PublishingResultSourceInfoConfig(PublishingResultSourceInfos resultSourceValues)
        {
            this.resultSourceValues = resultSourceValues;
        }

        /// <summary>
        /// Method to get the ResultSources to create
        /// </summary>
        /// <returns>A list of result source info</returns>
        public IList<ResultSourceInfo> ResultSources()
        {
            var resultSources = new List<ResultSourceInfo>
            {
                {resultSourceValues.SingleTargetItem()},
                {resultSourceValues.SingleCatalogItem()},
                {resultSourceValues.CatalogCategoryItems()}
            };

            return resultSources;
        }
    }
}
