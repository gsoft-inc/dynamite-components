using System;
using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingTaxonomyConfig : IBasePublishingTaxonomyConfig
    {
        private readonly BasePublishingTermGroupInfos _termGroupInfoValues;

        public BasePublishingTaxonomyConfig(BasePublishingTermGroupInfos termGroupInfoValues)
        {
            _termGroupInfoValues = termGroupInfoValues;
        }

        public IDictionary<string, TermGroupInfo> TermGroups()
        {
            var termGroups = new Dictionary<string, TermGroupInfo>
            {
                {BasePublishingTermGroupInfoKeys.NavigationTermGroup, _termGroupInfoValues.Navigation()}
            };

            return termGroups;
        }
    }
}
