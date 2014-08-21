using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Core.Keys;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoContentTypesConfig: ICustomContentTypeInfoConfig
    {
        public IDictionary<string, ContentTypeInfo> ContentTypes()
        {
            var contentTypes = new Dictionary<string, ContentTypeInfo>
            {
                {DynamiteDemoContentTypesKeys.MyContentItem, DynamiteDemoContentTypeInfoValues.MyContentItem}
            };

            return contentTypes;           
        }
    }
}
