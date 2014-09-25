using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingContentTypeInfoConfig: IBasePublishingContentTypeInfoConfig
    {
        private readonly BasePublishingContentTypeInfos _contentTypeInfoValues;

        public BasePublishingContentTypeInfoConfig(BasePublishingContentTypeInfos contentTypeInfoValues)
        {
            _contentTypeInfoValues = contentTypeInfoValues;
        }

        public IList<ContentTypeInfo> ContentTypes()
        {
            var contentTypes = new List<ContentTypeInfo>
            {
                {_contentTypeInfoValues.TranslatableItem()},
                {_contentTypeInfoValues.BrowsableItem()},
                {_contentTypeInfoValues.DefaultItem()},
                {_contentTypeInfoValues.CatalogContentItem()},
                {_contentTypeInfoValues.TargetContentItem()},
                {_contentTypeInfoValues.NewsItem()},
                {_contentTypeInfoValues.ContentItem()}
            };

            return contentTypes;
        }
    }
}
