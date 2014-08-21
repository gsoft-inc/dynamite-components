using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BaseContentTypeInfoConfig: IBaseContentTypeInfoConfig
    {
        public IDictionary<string, ContentTypeInfo> ContentTypes()
        {
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
