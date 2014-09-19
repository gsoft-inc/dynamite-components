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
    public class BasePublishingContentTypeInfoConfig: IBasePublishingContentTypeInfoConfig
    {
        private readonly BasePublishingContentTypeInfos _contentTypeInfoValues;

        public BasePublishingContentTypeInfoConfig(BasePublishingContentTypeInfos contentTypeInfoValues)
        {
            _contentTypeInfoValues = contentTypeInfoValues;
        }

        public IDictionary<string, ContentTypeInfo> ContentTypes()
        {
            var contentTypes = new Dictionary<string, ContentTypeInfo>
            {
                {BasePublishingContentTypeInfoKeys.TranslatableItem, _contentTypeInfoValues.TranslatableItem()},
                {BasePublishingContentTypeInfoKeys.BrowsableItem, _contentTypeInfoValues.BrowsableItem()},
                {BasePublishingContentTypeInfoKeys.DefaultItem, _contentTypeInfoValues.DefaultItem()},
                {BasePublishingContentTypeInfoKeys.CatalogContentItem, _contentTypeInfoValues.CatalogContentItem()},
                {BasePublishingContentTypeInfoKeys.TargetContentItem, _contentTypeInfoValues.TargetContentItem()},
                {BasePublishingContentTypeInfoKeys.NewsItem, _contentTypeInfoValues.NewsItem()},
                {BasePublishingContentTypeInfoKeys.ContentItem, _contentTypeInfoValues.ContentItem()}
            };

            return contentTypes;
        }
    }
}
