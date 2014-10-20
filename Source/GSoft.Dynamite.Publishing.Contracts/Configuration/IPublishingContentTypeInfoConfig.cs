using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingContentTypeInfoConfig
    {
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
