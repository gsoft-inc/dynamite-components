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
        /// Default constructor
        /// </summary>
        /// <param name="resultSourceValues">The result sources info configuration objects</param>
        public PublishingResultSourceInfoConfig(PublishingResultSourceInfos resultSourceValues)
        {
            this.resultSourceValues = resultSourceValues;
        }

        /// <summary>
        /// Property that return all the result sources to create in the publishing module
        /// </summary>
        /// <returns>The result sources</returns>
        public IList<ResultSourceInfo> ResultSources()
        {
            var resultSources = new List<ResultSourceInfo>
            {
                this.resultSourceValues.SingleTargetItem(),
                this.resultSourceValues.SingleCatalogItem(),
                this.resultSourceValues.CatalogCategoryItems()
            };

            return resultSources;
        }
    }
}
