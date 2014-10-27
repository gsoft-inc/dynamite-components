using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Docs.Contracts.Configuration
{
    public interface IDocsContentTypeInfoConfig
    {
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
