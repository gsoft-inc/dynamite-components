using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.ContentTypes.Constants;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Globalization;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base ContentTypeInfo values
    /// </summary>
    public static class PublishingContentTypeInfos
    {
        #region Browsable Item

        /// <summary>
        /// The <c>browsable</c> item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo BrowsableItem
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.TranslatableItem.ContentTypeId + "01"),
                    PublishingResources.ContentTypeBrowsableItemTitle,
                    PublishingResources.ContentTypeBrowsableItemDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Translatable Item

        /// <summary>
        /// The translatable item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo TranslatableItem
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(SPBuiltInContentTypeId.Item + "008093F9E3678D3D4392C57B0E6929DE05"),
                    PublishingResources.ContentTypeTranslatableItemTitle,
                    PublishingResources.ContentTypeTranslatableItemDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Default Item

        /// <summary>
        /// The default item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo DefaultItem
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.BrowsableItem.ContentTypeId + "01"),
                    PublishingResources.ContentTypeDefaultItemTitle,
                    PublishingResources.ContentTypeDefaultItemDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Catalog Content Item

        /// <summary>
        /// The catalog content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo CatalogContentItem
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.DefaultItem.ContentTypeId + "01"),
                    PublishingResources.ContentTypeCatalogContentItemTitle,
                    PublishingResources.ContentTypeCatalogContentItemDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Target Content Item

        /// <summary>
        /// The target content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo TargetContentItem
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.DefaultItem.ContentTypeId + "02"),
                    PublishingResources.ContentTypeTargetContentItemTitle,
                    PublishingResources.ContentTypeTargetContentItemDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Content Item

        /// <summary>
        /// The content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo ContentItem
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.TargetContentItem.ContentTypeId + "01"),
                    PublishingResources.ContentTypeContentItemTitle,
                    PublishingResources.ContentTypeContentItemDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region News Item

        /// <summary>
        /// The news item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo NewsItem
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.CatalogContentItem.ContentTypeId + "01"),
                    PublishingResources.ContentTypeNewsItemTitle,
                    PublishingResources.ContentTypeNewsItemDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Browsable Page

        /// <summary>
        /// The translatable page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo BrowsablePage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(BuiltInContentTypes.Page + "01"),
                    PublishingResources.ContentTypeBrowsablePageTitle,
                    PublishingResources.ContentTypeBrowsablePageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Translatable Page

        /// <summary>
        /// The translatable page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo TranslatablePage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.BrowsablePage.ContentTypeId + "01"),
                    PublishingResources.ContentTypeTranslatablePageTitle,
                    PublishingResources.ContentTypeTranslatablePageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Default Page

        /// <summary>
        /// The default page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo DefaultPage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.TranslatablePage.ContentTypeId + "01"),
                    PublishingResources.ContentTypeDefaultPageTitle,
                    PublishingResources.ContentTypeDefaultPageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }
        
        #endregion

        #region Browsable Article Page

        /// <summary>
        /// The <c>browsable</c> article page content type information.
        /// </summary>
        /// <returns>Content type information</returns>
        public static ContentTypeInfo BrowsableArticlePage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(BuiltInContentTypes.ArticlePage + "01"),
                    PublishingResources.ContentTypeBrowsableArticlePageTitle,
                    PublishingResources.ContentTypeBrowsableArticlePageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Translatable Article Page

        /// <summary>
        /// The translatable article page content type information.
        /// </summary>
        /// <returns>Content type information</returns>
        public static ContentTypeInfo TranslatableArticlePage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.BrowsableArticlePage.ContentTypeId + "01"),
                    PublishingResources.ContentTypeTranslatableArticlePageTitle,
                    PublishingResources.ContentTypeTranslatableArticlePageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Default Article Page

        /// <summary>
        /// The default article page content type information.
        /// </summary>
        /// <returns>Content type information</returns>
        public static ContentTypeInfo DefaultArticlePage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.TranslatableArticlePage.ContentTypeId + "01"),
                    PublishingResources.ContentTypeDefaultArticlePageTitle,
                    PublishingResources.ContentTypeDefaultArticlePageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Target Content Page

        /// <summary>
        /// The default page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo TargetContentPage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.DefaultPage.ContentTypeId + "01"),
                    PublishingResources.ContentTypeTargetContentPageTitle,
                    PublishingResources.ContentTypeTargetContentPageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion

        #region Catalog Content Page

        /// <summary>
        /// The default page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public static ContentTypeInfo CatalogContentPage
        {
            get
            {
                return new ContentTypeInfo(
                    new SPContentTypeId(PublishingContentTypeInfos.DefaultPage.ContentTypeId + "02"),
                    PublishingResources.ContentTypeCatalogContentPageTitle,
                    PublishingResources.ContentTypeCatalogContentPageDescription,
                    PublishingResources.ContentTypeGroup,
                    PublishingResources.Global);
            }
        }

        #endregion
    }
}
