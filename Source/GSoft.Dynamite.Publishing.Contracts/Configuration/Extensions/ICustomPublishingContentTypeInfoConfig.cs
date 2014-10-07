using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions
{
    public interface ICustomPublishingContentTypeInfoConfig
    {
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
