using System.Collections.Generic;
using System.Globalization;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public class DynamiteDemoPublishingContentTypeInfoValues
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = DynamiteDemoResources.Global;
        private readonly DynamiteDemoPublishingFieldInfoValues _fieldInfoValues;
        private readonly BasePublishingContentTypeInfos _baseContentTypeValues;

        /// <summary>
        /// The DynamiteDemoContentTypeInfoValues constructor
        /// </summary>
        /// <param name="resourceLocator">The resource locator instance</param>
        /// <param name="fieldInfoValues">The field info instance</param>
        public DynamiteDemoPublishingContentTypeInfoValues(IResourceLocator resourceLocator, DynamiteDemoPublishingFieldInfoValues fieldInfoValues, BasePublishingContentTypeInfos baseContentTypeValues)
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
            return new ContentTypeInfo()
            {
                Fields = new List<FieldInfo>()
                {
                    _fieldInfoValues.DynamiteDemoColumn()
                },

                ContentTypeId = _baseContentTypeValues.NewsItem().ContentTypeId +"01",
                DisplayName = _resourceLocator.Find(_resourceFileName, DynamiteDemoResources.ContentTypeDynamiteItemTitle, new CultureInfo(1033)),

                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.ContentTypeDynamiteItemTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.ContentTypeDynamiteItemTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.ContentTypeDynamiteItemDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.ContentTypeDynamiteItemDescription,new CultureInfo(1036))}
                },

                Group = _resourceLocator.GetResourceString(_resourceFileName, DynamiteDemoResources.ContentTypeGroup)
            };
        }
        #endregion
    }
}
