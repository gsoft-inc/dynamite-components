using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the content types settings
    /// </summary>
    public class PublishingContentTypeInfoConfig : IPublishingContentTypeInfoConfig
    {
        private readonly IPublishingFieldInfoConfig publishingFieldInfoConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishingContentTypeInfoConfig"/> class.
        /// </summary>
        /// <param name="publishingFieldInfoConfig">The publishing field information configuration.</param>
        public PublishingContentTypeInfoConfig(IPublishingFieldInfoConfig publishingFieldInfoConfig)
        {
            this.publishingFieldInfoConfig = publishingFieldInfoConfig;
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
                    PublishingContentTypeInfos.TranslatableItem,
                    this.GetConfiguredBrowsableItemContentType,
                    this.GetConfiguredDefaultItemContentType,
                    PublishingContentTypeInfos.CatalogContentItem,
                    PublishingContentTypeInfos.TargetContentItem,
                    this.GetConfiguredNewsItemContentType,
                    PublishingContentTypeInfos.ContentItem,
                    this.GetConfiguredBrowsablePageContentType,
                    PublishingContentTypeInfos.TranslatablePage,
                    PublishingContentTypeInfos.DefaultPage,
                    this.GetConfiguredBrowsableArticlePageContentType,
                    PublishingContentTypeInfos.TranslatableArticlePage,
                    PublishingContentTypeInfos.DefaultArticlePage,
                    PublishingContentTypeInfos.TargetContentPage,
                    PublishingContentTypeInfos.CatalogContentPage,
                };

                return contentTypes;
            }
        }

        private ContentTypeInfo GetConfiguredBrowsableItemContentType
        {
            get
            {
                var contentType = PublishingContentTypeInfos.BrowsableItem;
                contentType.Fields = new List<BaseFieldInfo>()
                {
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id)
                };

                return contentType;
            }
        }

        private ContentTypeInfo GetConfiguredDefaultItemContentType
        {
            get
            {
                var contentType = PublishingContentTypeInfos.DefaultItem;
                contentType.Fields = new List<BaseFieldInfo>()
                {
                    PublishingFields.PublishingPageContent
                };

                return contentType;
            }
        }

        private ContentTypeInfo GetConfiguredNewsItemContentType
        {
            get
            {
                var contentType = PublishingContentTypeInfos.NewsItem;
                contentType.Fields = new List<BaseFieldInfo>()
                {
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Summary.Id),
                    PublishingFields.PublishingPageImage,
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.ImageDescription.Id)
                };

                return contentType;
            }
        }

        private ContentTypeInfo GetConfiguredBrowsablePageContentType
        {
            get
            {
                var contentType = PublishingContentTypeInfos.BrowsablePage;
                contentType.Fields = new List<BaseFieldInfo>()
                {
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id)
                };

                return contentType;
            }
        }

        private ContentTypeInfo GetConfiguredBrowsableArticlePageContentType
        {
            get
            {
                var contentType = PublishingContentTypeInfos.BrowsableArticlePage;
                contentType.Fields = new List<BaseFieldInfo>()
                {
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id)
                };

                return contentType;
            }
        }

        /// <summary>
        /// Gets the content type from the ContentTypes property where the id of that content type is passed by parameter.
        /// </summary>
        /// <param name="contentTypeId">The unique identifier of the content type we are looking for.</param>
        /// <returns>
        /// The content type information.
        /// </returns>
        public ContentTypeInfo GetContentTypeById(SPContentTypeId contentTypeId)
        {
            return this.ContentTypes.Single(c => c.ContentTypeId.Equals(contentTypeId));
        }
    }
}
