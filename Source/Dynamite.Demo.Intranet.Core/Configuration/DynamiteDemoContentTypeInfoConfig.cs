using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Core.Keys;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoContentTypeInfoConfig: ICustomContentTypeInfoConfig
    {
        private readonly DynamiteDemoContentTypeInfoValues _contentTypeInfoValues;

        public DynamiteDemoContentTypeInfoConfig(DynamiteDemoContentTypeInfoValues contentTypeInfoValues)
        {
            _contentTypeInfoValues = contentTypeInfoValues;
        }

        public IDictionary<string, ContentTypeInfo> ContentTypes()
        {
            var contentTypes = new Dictionary<string, ContentTypeInfo>
            {
                {DynamiteDemoContentTypesKeys.DynamiteItem, _contentTypeInfoValues.DynamiteItem()},
            };

            return contentTypes;
        }
    }
}
