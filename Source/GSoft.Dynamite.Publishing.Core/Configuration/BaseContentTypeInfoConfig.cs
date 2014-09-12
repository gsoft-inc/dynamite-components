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
        private readonly BaseContentTypeInfoValues _contentTypeInfoValues;

        public BaseContentTypeInfoConfig(BaseContentTypeInfoValues contentTypeInfoValues)
        {
            _contentTypeInfoValues = contentTypeInfoValues;
        }

        public IDictionary<string, ContentTypeInfo> ContentTypes()
        {
            var contentTypes = new Dictionary<string, ContentTypeInfo>
            {
                {BaseContentTypeInfoKeys.TranslatableItem, _contentTypeInfoValues.TranslatableItem()},
                {BaseContentTypeInfoKeys.BrowsableItem, _contentTypeInfoValues.BrowsableItem()},
                {BaseContentTypeInfoKeys.DefaultItem, _contentTypeInfoValues.DefaultItem()},
                {BaseContentTypeInfoKeys.CatalogContentItem, _contentTypeInfoValues.CatalogContentItem()},
                {BaseContentTypeInfoKeys.TargetContentItem, _contentTypeInfoValues.TargetContentItem()},
                {BaseContentTypeInfoKeys.NewsItem, _contentTypeInfoValues.NewsItem()},
                {BaseContentTypeInfoKeys.ContentItem, _contentTypeInfoValues.ContentItem()}
            };

            return contentTypes;
        }
    }
}
