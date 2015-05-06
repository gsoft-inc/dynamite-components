using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// Property that return all the result sources to create in the publishing module
        /// </summary>
        /// <returns>The result sources</returns>
        public IList<ResultSourceInfo> ResultSources
        {
            get
            {
                var resultSources = new List<ResultSourceInfo>
                {
                    PublishingResultSourceInfos.SingleTargetItem,
                    PublishingResultSourceInfos.SingleCatalogItem,
                    PublishingResultSourceInfos.CatalogCategoryItems
                };

                return resultSources;
            }
        }

        /// <summary>
        /// Gets the result source information by name from this configuration.
        /// </summary>
        /// <param name="name">The name of the result source.</param>
        /// <returns>
        /// The result source information
        /// </returns>
        public ResultSourceInfo GetResultSourceInfoByName(string name)
        {
            return this.ResultSources.Single(r => r.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
