using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search.Contracts.Configuration;

namespace GSoft.Dynamite.Search.Core.Configuration
{
    /// <summary>
    /// The public configuration of content types for search module.
    /// </summary>
    public class SearchContentTypeInfoConfig : ISearchContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos contentTypeInfoValues;
        private readonly ISearchFieldInfoConfig searchFieldInfoConfig;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="contentTypeInfoValues">Content types info</param>
        /// <param name="searchFieldInfoConfig">Fields info</param>
        public SearchContentTypeInfoConfig(PublishingContentTypeInfos contentTypeInfoValues, ISearchFieldInfoConfig searchFieldInfoConfig)
        {
            this.contentTypeInfoValues = contentTypeInfoValues;
            this.searchFieldInfoConfig = searchFieldInfoConfig;
        }

        /// <summary>
        /// Property that return all the content types to create in the publishing module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                // Gets the browsable item content type.
                var browsableItem = this.contentTypeInfoValues.BrowsableItem();

                // Get all the fields in the search configuration
                var searchFields = this.searchFieldInfoConfig.Fields;

                // Add each field in the content type
                foreach (var field in searchFields)
                {
                    browsableItem.Fields.Add(field);
                }

                // Add the updated content type in the configuration
                var contentTypes = new List<ContentTypeInfo>
                {
                    browsableItem
                };

                // Return the config
                return contentTypes;
            }
        }
    }
}
