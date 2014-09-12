using System;
using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BaseTaxonomyConfig : IBaseTaxonomyConfig
    {
        private readonly BaseTermGroupInfoValues _termGroupInfoValues;

        public BaseTaxonomyConfig(BaseTermGroupInfoValues termGroupInfoValues)
        {
            _termGroupInfoValues = termGroupInfoValues;
        }

        public IDictionary<string, TermGroupInfo> TermGroups()
        {
            var termGroups = new Dictionary<string, TermGroupInfo>
            {
                {BaseTermGroupInfoKeys.NavigationTermGroup, _termGroupInfoValues.Navigation()}
            };

            return termGroups;
        }
    }
}
