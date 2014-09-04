using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BaseContentTypeInfoConfig: IBaseContentTypeInfoConfig
    {
        private readonly IResourceLocator _resourceLocator;

        public BaseContentTypeInfoConfig(IResourceLocator resourceLocator)
        {
            _resourceLocator = resourceLocator;
        }

        public IDictionary<string, ContentTypeInfo> ContentTypes()
        {
            var resourceFileName = BaseResources.Global;

            // Get resources strings
            BaseContentTypeInfoValues.TranslatableItem.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeTranslatableItemTitle);
            BaseContentTypeInfoValues.TranslatableItem.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeTranslatableItemDescription);
            BaseContentTypeInfoValues.TranslatableItem.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeGroup);

            BaseContentTypeInfoValues.CatalogContentItem.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeCatalogContentItemTitle);
            BaseContentTypeInfoValues.CatalogContentItem.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeCatalogContentItemDescription);
            BaseContentTypeInfoValues.CatalogContentItem.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeGroup);

            BaseContentTypeInfoValues.TargetContentItem.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeTargetContentItemTitle);
            BaseContentTypeInfoValues.TargetContentItem.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeTargetContentItemDescription);
            BaseContentTypeInfoValues.TargetContentItem.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeGroup);

            BaseContentTypeInfoValues.BrowsableItem.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeBrowsableItemTitle);
            BaseContentTypeInfoValues.BrowsableItem.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeBrowsableItemDescription);
            BaseContentTypeInfoValues.BrowsableItem.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeGroup);

            BaseContentTypeInfoValues.DefaultItem.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeDefaultItemTitle);
            BaseContentTypeInfoValues.DefaultItem.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeDefaultItemDescription);
            BaseContentTypeInfoValues.DefaultItem.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeGroup);

            BaseContentTypeInfoValues.NewsItem.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeNewsItemTitle);
            BaseContentTypeInfoValues.NewsItem.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeNewsItemDescription);
            BaseContentTypeInfoValues.NewsItem.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeGroup);

            BaseContentTypeInfoValues.ContentItem.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeContentItemTitle);
            BaseContentTypeInfoValues.ContentItem.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeContentItemDescription);
            BaseContentTypeInfoValues.ContentItem.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.ContentTypeGroup);

            var contentTypes = new Dictionary<string, ContentTypeInfo>
            {
                {BaseContentTypeInfoKeys.TranslatableItem, BaseContentTypeInfoValues.TranslatableItem},
                {BaseContentTypeInfoKeys.BrowsableItem, BaseContentTypeInfoValues.BrowsableItem},
                {BaseContentTypeInfoKeys.DefaultItem, BaseContentTypeInfoValues.DefaultItem},
                {BaseContentTypeInfoKeys.CatalogContentItem, BaseContentTypeInfoValues.CatalogContentItem},
                {BaseContentTypeInfoKeys.TargetContentItem, BaseContentTypeInfoValues.TargetContentItem},
                {BaseContentTypeInfoKeys.NewsItem, BaseContentTypeInfoValues.NewsItem},
                {BaseContentTypeInfoKeys.ContentItem, BaseContentTypeInfoValues.ContentItem}
            };

            return contentTypes;
        }
    }
}
