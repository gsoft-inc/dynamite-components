using System.Collections.Generic;
using System.Linq;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingContentTypeInfoConfig : IBasePublishingContentTypeInfoConfig
    {
        private readonly IBasePublishingContentTypeInfoConfig _basePublishingContentTypeInfoConfig;
        private readonly BasePublishingContentTypeInfos _basePublishingContentTypeInfos;
        private readonly DynamiteDemoPublishingFieldInfos _fieldbaseDemoPublishingFieldInfos;
        private readonly DynamiteDemoPublishingContentTypeInfos _baseDemoPublishingContentTypeInfos;

        public DynamiteDemoPublishingContentTypeInfoConfig(
            IBasePublishingContentTypeInfoConfig basePublishingContentTypeInfoConfig,
            BasePublishingContentTypeInfos basePublishingContentTypeInfos,
            DynamiteDemoPublishingFieldInfos baseDemoPublishingFieldInfos,
            DynamiteDemoPublishingContentTypeInfos baseDemoPublishingContentTypeInfos)
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
