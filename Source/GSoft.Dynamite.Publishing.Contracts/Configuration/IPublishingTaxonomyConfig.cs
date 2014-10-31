using System.Collections.Generic;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingTaxonomyConfig
    {
        IList<TermGroupInfo> TermGroups();
    }
}
