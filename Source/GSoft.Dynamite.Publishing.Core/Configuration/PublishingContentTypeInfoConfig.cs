using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the content types settings
    /// </summary>
    public class PublishingContentTypeInfoConfig : IPublishingContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos contentTypeInfoValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="contentTypeInfoValues">The content types info objects configuration</param>
        public PublishingContentTypeInfoConfig(PublishingContentTypeInfos contentTypeInfoValues)
        {
            this.contentTypeInfoValues = contentTypeInfoValues;
        }

        /// <summary>
        /// Property that return all the content types to create in the publishing module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var contentTypes = new List<ContentTypeInfo>
                {
                    this.contentTypeInfoValues.TranslatableItem(),
                    this.contentTypeInfoValues.BrowsableItem(),
                    this.contentTypeInfoValues.DefaultItem(),
                    this.contentTypeInfoValues.CatalogContentItem(),
                    this.contentTypeInfoValues.TargetContentItem(),
                    this.contentTypeInfoValues.NewsItem(),
                    this.contentTypeInfoValues.ContentItem(),
                    this.contentTypeInfoValues.BrowsablePage(),
                    this.contentTypeInfoValues.TranslatablePage(),
                    this.contentTypeInfoValues.DefaultPage(),
                    this.contentTypeInfoValues.BrowsableArticlePage(),
                    this.contentTypeInfoValues.TranslatableArticlePage(),
                    this.contentTypeInfoValues.DefaultArticlePage(),
                    this.contentTypeInfoValues.TargetContentPage(),
                    this.contentTypeInfoValues.CatalogContentPage(),
                };

                return contentTypes;
            }
        }
    }
}
