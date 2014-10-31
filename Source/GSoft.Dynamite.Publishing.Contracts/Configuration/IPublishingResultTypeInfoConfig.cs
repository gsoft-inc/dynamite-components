using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingResultTypeInfoConfig
    {
        IList<ResultTypeInfo> ResultTypes();
    }
}
