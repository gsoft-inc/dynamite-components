using System.Collections.Generic;
using System.Linq;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DemoPublishingContentTypeInfoConfig : IPublishingContentTypeInfoConfig
    {
        private readonly IPublishingContentTypeInfoConfig _basePublishingContentTypeInfoConfig;
        private readonly PublishingContentTypeInfos _basePublishingContentTypeInfos;
        private readonly DemoPublishingFieldInfos _fieldbaseDemoPublishingFieldInfos;
        private readonly DemoPublishingContentTypeInfos _baseDemoPublishingContentTypeInfos;

        public DemoPublishingContentTypeInfoConfig(
            IPublishingContentTypeInfoConfig basePublishingContentTypeInfoConfig,
            PublishingContentTypeInfos basePublishingContentTypeInfos,
            DemoPublishingFieldInfos baseDemoPublishingFieldInfos,
            DemoPublishingContentTypeInfos baseDemoPublishingContentTypeInfos)
        {
            this._basePublishingContentTypeInfoConfig = basePublishingContentTypeInfoConfig;
            this._basePublishingContentTypeInfos = basePublishingContentTypeInfos;
            this._fieldbaseDemoPublishingFieldInfos = baseDemoPublishingFieldInfos;
            this._baseDemoPublishingContentTypeInfos = baseDemoPublishingContentTypeInfos;
        }

        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                // Getting the base content types
                var baseContentTypes = this._basePublishingContentTypeInfoConfig.ContentTypes;

                // Getting the News Item (to add fields)
                var catalogItemFieldInfo = baseContentTypes.Single(contentType => contentType.ContentTypeId == this._basePublishingContentTypeInfos.NewsItem().ContentTypeId);

                // Adding the Dynamite Demo field into an existing Content Type
                catalogItemFieldInfo.Fields.Add(this._fieldbaseDemoPublishingFieldInfos.DynamiteDemoColumn());

                // Add a custom content type
                baseContentTypes.Add(this._baseDemoPublishingContentTypeInfos.DynamiteItem());

                return baseContentTypes;
            }
        }
    }
}
