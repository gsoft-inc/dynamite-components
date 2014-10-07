using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingContentTypeInfoConfig : IBasePublishingContentTypeInfoConfig
    {
        private readonly BasePublishingContentTypeInfos contentTypeInfoValues;

        public BasePublishingContentTypeInfoConfig(BasePublishingContentTypeInfos contentTypeInfoValues)
        {
            this.contentTypeInfoValues = contentTypeInfoValues;
        }

        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var contentTypes = new List<ContentTypeInfo>
                {
                    {this.contentTypeInfoValues.TranslatableItem()},
                    {this.contentTypeInfoValues.BrowsableItem()},
                    {this.contentTypeInfoValues.DefaultItem()},
                    {this.contentTypeInfoValues.CatalogContentItem()},
                    {this.contentTypeInfoValues.TargetContentItem()},
                    {this.contentTypeInfoValues.NewsItem()},
                    {this.contentTypeInfoValues.ContentItem()}
                };

                return contentTypes;
            }
        }
    }
}
