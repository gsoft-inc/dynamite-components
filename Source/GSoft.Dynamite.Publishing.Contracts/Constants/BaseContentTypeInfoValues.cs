using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base ContentTypeInfo values
    /// </summary>
    public class BaseContentTypeInfoValues
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = BaseResources.Global;
        private readonly BaseFieldInfoValues _fieldInfoValues;

        /// <summary>
        /// The BaseContentTypeInfoValues constructor
        /// </summary>
        /// <param name="resourceLocator">The resource locator instance</param>
        /// <param name="fieldInfoValues">The field info instance</param>
        public BaseContentTypeInfoValues(IResourceLocator resourceLocator, BaseFieldInfoValues fieldInfoValues)
        {
            _resourceLocator = resourceLocator;
            _fieldInfoValues = fieldInfoValues;
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
                    _fieldInfoValues.Navigation()
                },

                ContentTypeId = BrowsableItemContentType,

                // Default content type name
                DisplayName = _resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeBrowsableItemTitle,new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeBrowsableItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeBrowsableItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeBrowsableItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeBrowsableItemDescription,new CultureInfo(1036))}
                },

                Group = _resourceLocator.GetResourceString(_resourceFileName, BaseResources.ContentTypeGroup)
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
                DisplayName = _resourceLocator.Find(_resourceFileName, BaseResources.ContentTypeTranslatableItemTitle, new CultureInfo(1033)),
                Group = _resourceLocator.GetResourceString(_resourceFileName, BaseResources.ContentTypeGroup),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTranslatableItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTranslatableItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTranslatableItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTranslatableItemDescription,new CultureInfo(1036))}
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
                    _fieldInfoValues.PublishingPageContent()
                },

                ContentTypeId = DefaultItemContentType,

                DisplayName = _resourceLocator.Find(_resourceFileName, BaseResources.ContentTypeDefaultItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeDefaultItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeDefaultItemTitle,new CultureInfo(1036))}
                },

                 DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeDefaultItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeDefaultItemDescription,new CultureInfo(1036))}
                },

                Group = _resourceLocator.GetResourceString(_resourceFileName, BaseResources.ContentTypeGroup)
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
                DisplayName = _resourceLocator.Find(_resourceFileName, BaseResources.ContentCatalogTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogDescription,new CultureInfo(1036))}
                },

                Group = _resourceLocator.GetResourceString(_resourceFileName, BaseResources.ContentTypeGroup)
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
                DisplayName = _resourceLocator.Find(_resourceFileName, BaseResources.ContentTypeTargetContentItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTargetContentItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTargetContentItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTargetContentItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeTargetContentItemDescription,new CultureInfo(1036))}
                },

                Group = _resourceLocator.GetResourceString(_resourceFileName, BaseResources.ContentTypeGroup)
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
                DisplayName = _resourceLocator.Find(_resourceFileName, BaseResources.ContentTypeContentItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeContentItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeContentItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeContentItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeContentItemDescription,new CultureInfo(1036))}
                },

                Group = _resourceLocator.GetResourceString(_resourceFileName, BaseResources.ContentTypeGroup)
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
                DisplayName = _resourceLocator.Find(_resourceFileName, BaseResources.ContentTypeNewsItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeNewsItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeNewsItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeNewsItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentTypeNewsItemDescription,new CultureInfo(1036))}
                },

                Group = _resourceLocator.GetResourceString(_resourceFileName, BaseResources.ContentTypeGroup),

                Fields = new List<FieldInfo>()
                {
                    _fieldInfoValues.Summary(),
                    _fieldInfoValues.PublishingPageImage(),
                    _fieldInfoValues.ImageDescription()
                },
                ContentTypeId = NewsItemContentType,
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
