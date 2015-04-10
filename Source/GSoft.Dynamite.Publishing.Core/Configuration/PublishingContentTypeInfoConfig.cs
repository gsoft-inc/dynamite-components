using System;
using System.Linq;
using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Fields.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the content types settings
    /// </summary>
    public class PublishingContentTypeInfoConfig : IPublishingContentTypeInfoConfig
    {
        private readonly IPublishingFieldInfoConfig publishingFieldInfoConfig;

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

        /// <summary>
        /// Gets the content type from the ContentTypes property where the id of that content type is passed by parameter.
        /// </summary>
        /// <param name="contentTypeId">The unique identifier of the content type we are looking for.</param>
        /// <returns>
        /// The content type information.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">When the ContentTypes collection of this configuration does not have a content type with the proper identifier.</exception>
        public ContentTypeInfo GetContentTypeById(SPContentTypeId contentTypeId)
        {
            var contentType = this.ContentTypes.FirstOrDefault(c => c.ContentTypeId.Equals(contentTypeId));
            if (contentType == null)
            {
                throw new ArgumentOutOfRangeException("contentTypeId", string.Format("Unable to find content type in this configuration with the id '{0}'.", contentTypeId));
            }

            return contentType;
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
    }
}
