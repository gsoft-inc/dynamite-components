using System.Collections.Generic;
using System.Globalization;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public class DemoPublishingContentTypeInfos
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = DynamiteDemoResources.Global;
        private readonly DemoPublishingFieldInfos _fieldInfoValues;
        private readonly PublishingContentTypeInfos _baseContentTypeValues;

        /// <summary>
        /// The DynamiteDemoContentTypeInfoValues constructor
        /// </summary>
        /// <param name="resourceLocator">The resource locator instance</param>
        /// <param name="fieldInfoValues">The field info instance</param>
        public DemoPublishingContentTypeInfos(IResourceLocator resourceLocator, DemoPublishingFieldInfos fieldInfoValues, PublishingContentTypeInfos baseContentTypeValues)
        {
            _resourceLocator = resourceLocator;
            _fieldInfoValues = fieldInfoValues;
            _baseContentTypeValues = baseContentTypeValues;
        }

        #region Dynamite Item

        /// <summary>
        /// The dynamite demo item content type
        /// </summary>
        /// <returns>The content type info</returns>
        public ContentTypeInfo DynamiteItem()
        {
            return new ContentTypeInfo(
                    _baseContentTypeValues.NewsItem().ContentTypeId +"01",
                    DynamiteDemoResources.ContentTypeDynamiteItemTitle,
                    DynamiteDemoResources.ContentTypeDynamiteItemDescription,
                    DynamiteDemoResources.ContentTypeGroup)
                {
                    Fields = new List<IFieldInfo>()
                    {
                        _fieldInfoValues.DynamiteDemoColumn()
                    }
                };
        }
        #endregion
    }
}
