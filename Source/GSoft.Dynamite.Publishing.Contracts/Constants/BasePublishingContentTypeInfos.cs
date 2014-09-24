using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base ContentTypeInfo values
    /// </summary>
    public class BasePublishingContentTypeInfos
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = BasePublishingResources.Global;
        private readonly BasePublishingFieldInfos _fieldInfoValues;

        /// <summary>
        /// The BaseContentTypeInfoValues constructor
        /// </summary>
        /// <param name="resourceLocator">The resource locator instance</param>
        /// <param name="fieldInfoValues">The field info instance</param>
        public BasePublishingContentTypeInfos(IResourceLocator resourceLocator, BasePublishingFieldInfos fieldInfoValues)
        {
            this._resourceLocator = resourceLocator;
            this._fieldInfoValues = fieldInfoValues;
        }

        #region Browsable Item

        /// <summary>
        /// The browsable item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public  ContentTypeInfo BrowsableItem()
        {
            return new ContentTypeInfo()
            {
                Fields = new List<FieldInfo>()
                {
                   this._fieldInfoValues.Navigation()
                },

                ContentTypeId = BrowsableItemContentType,

                // Default content type name
                DisplayName = this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeBrowsableItemTitle,new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeBrowsableItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeBrowsableItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeBrowsableItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeBrowsableItemDescription,new CultureInfo(1036))}
                },

                Group = this._resourceLocator.GetResourceString(this._resourceFileName, BasePublishingResources.ContentTypeGroup)
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
            return new ContentTypeInfo()
            {
                Fields = new List<FieldInfo>() {},

                ContentTypeId = TranslatableItemContentType,
                DisplayName = this._resourceLocator.Find(this._resourceFileName, BasePublishingResources.ContentTypeTranslatableItemTitle, new CultureInfo(1033)),
                Group = this._resourceLocator.GetResourceString(this._resourceFileName, BasePublishingResources.ContentTypeGroup),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTranslatableItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTranslatableItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTranslatableItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTranslatableItemDescription,new CultureInfo(1036))}
                },
            };
        }

        #endregion

        #region Default Item

        /// <summary>
        /// The default item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo DefaultItem()
        {
            return new ContentTypeInfo()
            {
                 Fields = new List<FieldInfo>()
                {
                    this._fieldInfoValues.PublishingPageContent()
                },

                ContentTypeId = DefaultItemContentType,

                DisplayName = this._resourceLocator.Find(this._resourceFileName, BasePublishingResources.ContentTypeDefaultItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeDefaultItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeDefaultItemTitle,new CultureInfo(1036))}
                },

                 DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeDefaultItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeDefaultItemDescription,new CultureInfo(1036))}
                },

                Group = this._resourceLocator.GetResourceString(this._resourceFileName, BasePublishingResources.ContentTypeGroup)
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
            return new ContentTypeInfo()
            {
                Fields = new List<FieldInfo>() { },

                ContentTypeId = CatalogContentItemContentType,
                DisplayName = this._resourceLocator.Find(this._resourceFileName, BasePublishingResources.ContentCatalogTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentCatalogTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentCatalogTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentCatalogDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentCatalogDescription,new CultureInfo(1036))}
                },

                Group = this._resourceLocator.GetResourceString(this._resourceFileName, BasePublishingResources.ContentTypeGroup)
            };

        }

        #endregion

        #region Target Content Item

        /// <summary>
        /// The target content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo TargetContentItem()
        {
            return new ContentTypeInfo()
            {
                Fields = new List<FieldInfo>() { },

                ContentTypeId = TargetContentItemContentType,
                DisplayName = this._resourceLocator.Find(this._resourceFileName, BasePublishingResources.ContentTypeTargetContentItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTargetContentItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTargetContentItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTargetContentItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeTargetContentItemDescription,new CultureInfo(1036))}
                },

                Group = this._resourceLocator.GetResourceString(this._resourceFileName, BasePublishingResources.ContentTypeGroup)
            };
        }

        #endregion

        #region Content Item

        /// <summary>
        /// The content item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo ContentItem()
        {
            return new ContentTypeInfo()
            {
                Fields = new List<FieldInfo>() {},
                ContentTypeId = ContentItemContentType,
                DisplayName = this._resourceLocator.Find(this._resourceFileName, BasePublishingResources.ContentTypeContentItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeContentItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeContentItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeContentItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeContentItemDescription,new CultureInfo(1036))}
                },

                Group = this._resourceLocator.GetResourceString(this._resourceFileName, BasePublishingResources.ContentTypeGroup)
            };
        }

        #endregion

        #region News Item

        /// <summary>
        /// The news item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo NewsItem()
        {
            return new ContentTypeInfo()
            {
                DisplayName = this._resourceLocator.Find(this._resourceFileName, BasePublishingResources.ContentTypeNewsItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeNewsItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeNewsItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeNewsItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),this._resourceLocator.Find(this._resourceFileName,BasePublishingResources.ContentTypeNewsItemDescription,new CultureInfo(1036))}
                },

                Group = this._resourceLocator.GetResourceString(this._resourceFileName, BasePublishingResources.ContentTypeGroup),

                Fields = new List<FieldInfo>()
                {
                    this._fieldInfoValues.Summary(),
                    this._fieldInfoValues.PublishingPageImage(),
                    this._fieldInfoValues.ImageDescription()
                },
                ContentTypeId = NewsItemContentType,
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
            return new ContentTypeInfo()
            {
                ContentTypeId = "0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF39"
            };
        }

        #endregion

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
    }
}
