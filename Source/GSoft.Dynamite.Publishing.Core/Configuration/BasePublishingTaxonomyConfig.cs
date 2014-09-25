using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingTaxonomyConfig : IBasePublishingTaxonomyConfig
    {
        private readonly BasePublishingTermGroupInfos _termGroupInfoValues;

        public BasePublishingTaxonomyConfig(BasePublishingTermGroupInfos termGroupInfoValues)
        {
            _termGroupInfoValues = termGroupInfoValues;
        }

        public IList<TermGroupInfo> TermGroups()
        {
            var termGroups = new List<TermGroupInfo>
            {
                {_termGroupInfoValues.Navigation()}
            };

            return termGroups;
        }
    }
}
