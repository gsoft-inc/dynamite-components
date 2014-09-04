using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public static class BaseContentTypeInfoValues
    {
        #region Browsable Item

        public static readonly ContentTypeInfo BrowsableItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>()
            {
                BaseFieldInfoValues.Navigation
            },

            ContentTypeId = BrowsableItemContentType,

        };

        #endregion

        #region Translatable Item

        public static readonly ContentTypeInfo TranslatableItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>(){},

            ContentTypeId = TranslatableItemContentType,
        };

        #endregion

        #region Default Item

        public static readonly ContentTypeInfo DefaultItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>()
            {
                BaseFieldInfoValues.PublishingPageContent
            },

            ContentTypeId = DefaultItemContentType,
        };

        #endregion

        #region Catalog Content Item

        public static readonly ContentTypeInfo CatalogContentItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>() { },

            ContentTypeId = CatalogContentItemContentType,
        };

        #endregion

        #region Target Content Item

        public static readonly ContentTypeInfo TargetContentItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>() { },

            ContentTypeId = TargetContentItemContentType,
        };

        #endregion

        #region Content Item

        public static readonly ContentTypeInfo ContentItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>() { },

            ContentTypeId = ContentItemContentType,
        };

        #endregion

        #region News Item

        public static readonly ContentTypeInfo NewsItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>()
            {
                BaseFieldInfoValues.Summary,
                BaseFieldInfoValues.PublishingPageImage,
                BaseFieldInfoValues.ImageDescription
            },

            ContentTypeId = NewsItemContentType,
        };

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
