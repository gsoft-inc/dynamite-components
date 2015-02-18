using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Globalization;
using Microsoft.SharePoint;

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
        private static readonly SPContentTypeId TranslatableItemContentType = new SPContentTypeId(SPBuiltInContentTypeId.Item + "008093F9E3678D3D4392C57B0E6929DE05");
        
        private static readonly SPContentTypeId BrowsableItemContentType = new SPContentTypeId(TranslatableItemContentType + "01");
        
        private static readonly SPContentTypeId DefaultItemContentType = new SPContentTypeId(BrowsableItemContentType + "01");
        
        private static readonly SPContentTypeId CatalogContentItemContentType = new SPContentTypeId(DefaultItemContentType + "01");
        
        private static readonly SPContentTypeId TargetContentItemContentType = new SPContentTypeId(DefaultItemContentType + "02");
        
        private static readonly SPContentTypeId NewsItemContentType = new SPContentTypeId(CatalogContentItemContentType + "01");
        
        private static readonly SPContentTypeId ContentItemContentType = new SPContentTypeId(TargetContentItemContentType + "01");

        private static readonly SPContentTypeId RichMediaAssetDocumentContentType = new SPContentTypeId(SPBuiltInContentTypeId.Document + "009148F5A04DDD49CBA7127AADA5FB792B");
        
        private static readonly SPContentTypeId ImageItemContentType = new SPContentTypeId(RichMediaAssetDocumentContentType + "00AADE34325A8B49CDA8BB4DB53328F214");

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
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global);
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
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global);
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
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global);
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
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global);
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
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.Page().ContentTypeId + "01"),
                PublishingResources.ContentTypeBrowsablePageTitle,
                PublishingResources.ContentTypeBrowsablePageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.BrowsablePage().ContentTypeId + "01"),
                PublishingResources.ContentTypeTranslatablePageTitle,
                PublishingResources.ContentTypeTranslatablePageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.TranslatablePage().ContentTypeId + "01"),
                PublishingResources.ContentTypeDefaultPageTitle,
                PublishingResources.ContentTypeDefaultPageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.ArticlePage().ContentTypeId + "01"),
                PublishingResources.ContentTypeBrowsableArticlePageTitle,
                PublishingResources.ContentTypeBrowsableArticlePageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.BrowsableArticlePage().ContentTypeId + "01"),
                PublishingResources.ContentTypeTranslatableArticlePageTitle,
                PublishingResources.ContentTypeTranslatableArticlePageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.TranslatableArticlePage().ContentTypeId + "01"),
                PublishingResources.ContentTypeDefaultArticlePageTitle,
                PublishingResources.ContentTypeDefaultArticlePageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.DefaultPage().ContentTypeId + "01"),
                PublishingResources.ContentTypeTargetContentPageTitle,
                PublishingResources.ContentTypeTargetContentPageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
                new SPContentTypeId(this.DefaultPage().ContentTypeId + "02"),
                PublishingResources.ContentTypeCatalogContentPageTitle,
                PublishingResources.ContentTypeCatalogContentPageDescription,
                PublishingResources.ContentTypeGroup,
                PublishingResources.Global)
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
            return new ContentTypeInfo(new SPContentTypeId("0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF39"), string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// The SharePoint Article page content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo ArticlePage()
        {
            return new ContentTypeInfo(new SPContentTypeId(this.Page().ContentTypeId + "00" + "242457EFB8B24247815D688C526CD44D"), string.Empty, string.Empty, string.Empty);
        }

        #endregion
    }
}
