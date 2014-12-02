using System.Collections.Generic;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the creation of the Result Types
    /// </summary>
    public class PublishingResultTypeInfoConfig : IPublishingResultTypeInfoConfig
    {        
        private readonly PublishingResultTypeInfos _basePublishingResultTypeInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="basePublishingResultTypeInfos">The result types info objects</param>
        public PublishingResultTypeInfoConfig(PublishingResultTypeInfos basePublishingResultTypeInfos)
        {
            this._basePublishingResultTypeInfos = basePublishingResultTypeInfos;
        }

        /// <summary>
        /// Property that return all the result types to create in the publishing module
        /// </summary>
        public IList<ResultTypeInfo> ResultTypes
        {
            get
            {
                var resultTypes = new List<ResultTypeInfo>()
                {
                    this._basePublishingResultTypeInfos.NewsPageResultType(),
                    this._basePublishingResultTypeInfos.ContentPageResultType(),
                    this._basePublishingResultTypeInfos.CategoryItemResultType()
                };

                return resultTypes;               
            }         
        }
    }
}
