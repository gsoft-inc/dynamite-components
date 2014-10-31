using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    public interface IMultilingualismContentTypeInfoConfig
    {
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
