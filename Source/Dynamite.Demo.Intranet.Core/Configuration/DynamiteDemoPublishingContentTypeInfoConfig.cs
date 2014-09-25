using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingContentTypeInfoConfig: ICustomPublishingContentTypeInfoConfig
    {
        private readonly DynamiteDemoPublishingContentTypeInfoValues _contentTypeInfoValues;

        public DynamiteDemoPublishingContentTypeInfoConfig(DynamiteDemoPublishingContentTypeInfoValues contentTypeInfoValues)
        {
            _contentTypeInfoValues = contentTypeInfoValues;
        }

        public IList<ContentTypeInfo> ContentTypes()
        {
            var contentTypes = new List<ContentTypeInfo>
            {
                {_contentTypeInfoValues.DynamiteItem()},
            };

            return contentTypes;
        }
    }
}
