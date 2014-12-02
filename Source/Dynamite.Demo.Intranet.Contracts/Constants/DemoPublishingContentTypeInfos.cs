using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    /// <summary>
    /// Content type definitions for the Dynamite demo module
    /// </summary>
    public class DemoPublishingContentTypeInfos
    {
        private readonly DemoPublishingFieldInfos _fieldInfoValues;
        private readonly PublishingContentTypeInfos _baseContentTypeValues;

        /// <summary>
        /// The DynamiteDemoContentTypeInfoValues constructor
        /// </summary>
        /// <param name="fieldInfoValues">The field info instance</param>
        /// <param name="baseContentTypeValues">The base content type settings</param>
        public DemoPublishingContentTypeInfos(DemoPublishingFieldInfos fieldInfoValues, PublishingContentTypeInfos baseContentTypeValues)
        {
            this._fieldInfoValues = fieldInfoValues;
            this._baseContentTypeValues = baseContentTypeValues;
        }

        #region Dynamite Item

        /// <summary>
        /// The dynamite demo item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo DynamiteItem()
        {
            return new ContentTypeInfo(
                    this._baseContentTypeValues.NewsItem().ContentTypeId + "01",
                    DynamiteDemoResources.ContentTypeDynamiteItemTitle,
                    DynamiteDemoResources.ContentTypeDynamiteItemDescription,
                    DynamiteDemoResources.ContentTypeGroup)
                {
                    Fields = new List<IFieldInfo>()
                    {
                        this._fieldInfoValues.DynamiteDemoColumn()
                    }
                };
        }
        #endregion
    }
}
