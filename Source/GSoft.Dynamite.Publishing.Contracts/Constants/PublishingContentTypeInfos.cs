using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Globalization;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base ContentTypeInfo values
    /// </summary>
    public class PublishingContentTypeInfos
    {
        #region Item Content Type Hierarchy

        /// <summary>
        /// The "out-of-the-box" SharePoint item content type id
        /// </summary>
        private const string ItemContentType = "0x01";

        private const string TranslatableItemContentType = ItemContentType + "008093F9E3678D3D4392C57B0E6929DE05";

        private const string BrowsableItemContentType = TranslatableItemContentType + "01";

        private const string DefaultItemContentType = BrowsableItemContentType + "01";

        private const string CatalogContentItemContentType = DefaultItemContentType + "01";

        private const string TargetContentItemContentType = DefaultItemContentType + "02";

        private const string NewsItemContentType = CatalogContentItemContentType + "01";

        private const string ContentItemContentType = TargetContentItemContentType + "01";

        #endregion

        private readonly PublishingFieldInfos fieldInfoValues;

        /// <summary>
        /// The BaseContentTypeInfoValues constructor
        /// </summary>
        /// <param name="resourceLocator">The resource locator instance</param>
        /// <param name="fieldInfoValues">The field info instance</param>
        public PublishingContentTypeInfos(IResourceLocator resourceLocator, PublishingFieldInfos fieldInfoValues)
        {
            this.fieldInfoValues = fieldInfoValues;
        }

        #region Browsable Item

        /// <summary>
        /// The <c>browsable</c> item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo BrowsableItem()
        {
            return new ContentTypeInfo(
                BrowsableItemContentType,
                PublishingResources.ContentTypeBrowsableItemTitle,
                PublishingResources.ContentTypeBrowsableItemDescription,
                PublishingResources.ContentTypeGroup)
            {
                Fields = new List<IFieldInfo>()
                {
                   this.fieldInfoValues.Navigation()
                }
            };
        }

        #endregion

        #region Translatable Item

        /// <summary>
        /// The translatable item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo TranslatableItem()
        {
            return new ContentTypeInfo(
                TranslatableItemContentType,
                PublishingResources.ContentTypeTranslatableItemTitle,
                PublishingResources.ContentTypeTranslatableItemDescription,
                PublishingResources.ContentTypeGroup);
        }

        #endregion

        #region Default Item

        /// <summary>
        /// The default item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo DefaultItem()
        {
            return new ContentTypeInfo(
                DefaultItemContentType,
                PublishingResources.ContentTypeDefaultItemTitle,
                PublishingResources.ContentTypeDefaultItemDescription,
                PublishingResources.ContentTypeGroup)
            {
                Fields = new List<IFieldInfo>()
                {
                    PublishingFields.PublishingPageContent
                }
            }; 
        }

        #endregion

        #region Catalog Content Item

        /// <summary>
        /// The catalog content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo CatalogContentItem()
        {
            return new ContentTypeInfo(
                CatalogContentItemContentType,
                PublishingResources.ContentTypeCatalogContentItemTitle,
                PublishingResources.ContentTypeCatalogContentItemDescription,
                PublishingResources.ContentTypeGroup);
        }

        #endregion

        #region Target Content Item

        /// <summary>
        /// The target content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo TargetContentItem()
        {
            return new ContentTypeInfo(
                TargetContentItemContentType,
                PublishingResources.ContentTypeTargetContentItemTitle,
                PublishingResources.ContentTypeTargetContentItemDescription,
                PublishingResources.ContentTypeGroup);
        }

        #endregion

        #region Content Item

        /// <summary>
        /// The content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo ContentItem()
        {
            return new ContentTypeInfo(
                ContentItemContentType,
                PublishingResources.ContentTypeContentItemTitle,
                PublishingResources.ContentTypeContentItemDescription,
                PublishingResources.ContentTypeGroup);
        }

        #endregion

        #region News Item

        /// <summary>
        /// The news item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo NewsItem()
        {
            return new ContentTypeInfo(
                NewsItemContentType,
                PublishingResources.ContentTypeNewsItemTitle,
                PublishingResources.ContentTypeNewsItemDescription,
                PublishingResources.ContentTypeGroup)
            {
                Fields = new List<IFieldInfo>()
                {
                    this.fieldInfoValues.Summary(),
                    PublishingFields.PublishingPageImage,
                    this.fieldInfoValues.ImageDescription()
                },
            };
        }

        #endregion

        #region Browsable Page

        /// <summary>
        /// The translatable page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo BrowsablePage()
        {
            return new ContentTypeInfo(
                this.Page().ContentTypeId + "01",
                PublishingResources.ContentTypeBrowsablePageTitle,
                PublishingResources.ContentTypeBrowsablePageDescription,
                PublishingResources.ContentTypeGroup)
            {
                Fields = new List<IFieldInfo>()
                {
                   this.fieldInfoValues.Navigation()
                }
            };
        }

        #endregion

        #region Translatable Page

        /// <summary>
        /// The translatable page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo TranslatablePage()
        {
            return new ContentTypeInfo(
                this.BrowsablePage().ContentTypeId + "01",
                PublishingResources.ContentTypeTranslatablePageTitle,
                PublishingResources.ContentTypeTranslatablePageDescription,
                PublishingResources.ContentTypeGroup)
            {
            };
        }

        #endregion

        #region Default Page

        /// <summary>
        /// The default page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo DefaultPage()
        {
            return new ContentTypeInfo(
                this.TranslatablePage().ContentTypeId + "01",
                PublishingResources.ContentTypeDefaultPageTitle,
                PublishingResources.ContentTypeDefaultPageDescription,
                PublishingResources.ContentTypeGroup)
            {
            };
        }
        
        #endregion

        #region Browsable Article Page

        /// <summary>
        /// The <c>browsable</c> article page content type information.
        /// </summary>
        /// <returns>Content type information</returns>
        public ContentTypeInfo BrowsableArticlePage()
        {
            return new ContentTypeInfo(
                this.ArticlePage().ContentTypeId + "01",
                PublishingResources.ContentTypeBrowsableArticlePageTitle,
                PublishingResources.ContentTypeBrowsableArticlePageDescription,
                PublishingResources.ContentTypeGroup)
            {
                Fields = new List<IFieldInfo>()
                {
                   this.fieldInfoValues.Navigation()
                }
            };
        }

        #endregion

        #region Translatable Article Page

        /// <summary>
        /// The translatable article page content type information.
        /// </summary>
        /// <returns>Content type information</returns>
        public ContentTypeInfo TranslatableArticlePage()
        {
            return new ContentTypeInfo(
                this.BrowsableArticlePage().ContentTypeId + "01",
                PublishingResources.ContentTypeTranslatableArticlePageTitle,
                PublishingResources.ContentTypeTranslatableArticlePageDescription,
                PublishingResources.ContentTypeGroup)
            {
            };
        }

        #endregion

        #region Default Article Page

        /// <summary>
        /// The default article page content type information.
        /// </summary>
        /// <returns>Content type information</returns>
        public ContentTypeInfo DefaultArticlePage()
        {
            return new ContentTypeInfo(
                this.TranslatableArticlePage().ContentTypeId + "01",
                PublishingResources.ContentTypeDefaultArticlePageTitle,
                PublishingResources.ContentTypeDefaultArticlePageDescription,
                PublishingResources.ContentTypeGroup)
            {
            };
        }

        #endregion

        #region Target Content Page

        /// <summary>
        /// The default page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo TargetContentPage()
        {
            return new ContentTypeInfo(
                this.DefaultPage().ContentTypeId + "01",
                PublishingResources.ContentTypeTargetContentPageTitle,
                PublishingResources.ContentTypeTargetContentPageDescription,
                PublishingResources.ContentTypeGroup)
            {
            };
        }

        #endregion

        #region Catalog Content Page

        /// <summary>
        /// The default page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo CatalogContentPage()
        {
            return new ContentTypeInfo(
                this.DefaultPage().ContentTypeId + "02",
                PublishingResources.ContentTypeCatalogContentPageTitle,
                PublishingResources.ContentTypeCatalogContentPageDescription,
                PublishingResources.ContentTypeGroup)
            {
            };
        }

        #endregion

        #region SharePoint Content Types

        /// <summary>
        /// The SharePoint Page Content Type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo Page()
        {
            return new ContentTypeInfo("0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF39", string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// The SharePoint Article page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo ArticlePage()
        {
            return new ContentTypeInfo(this.Page().ContentTypeId + "00" + "242457EFB8B24247815D688C526CD44D", string.Empty, string.Empty, string.Empty);
        }

        #endregion
    }
}
