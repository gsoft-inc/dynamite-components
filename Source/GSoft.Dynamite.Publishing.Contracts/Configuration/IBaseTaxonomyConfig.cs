using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IBaseTaxonomyConfig
    {
        IDictionary<string, TermGroupInfo> TermGroups();
    }
}
