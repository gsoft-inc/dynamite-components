using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingContentTypeInfoConfig : ICustomPublishingContentTypeInfoConfig
    {
        private readonly DynamiteDemoPublishingContentTypeInfos contentTypeInfoValues;

        public DynamiteDemoPublishingContentTypeInfoConfig(DynamiteDemoPublishingContentTypeInfos contentTypeInfoValues)
        {
            this.contentTypeInfoValues = contentTypeInfoValues;
        }

        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var contentTypes = new List<ContentTypeInfo>
                {
                    {this.contentTypeInfoValues.DynamiteItem()},
                };

                return contentTypes;
            }
        }
    }
}
