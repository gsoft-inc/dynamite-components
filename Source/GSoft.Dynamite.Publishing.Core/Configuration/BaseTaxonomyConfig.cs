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
        public IDictionary<string, TermGroupInfo> TermGroups()
        {
            var termGroups = new Dictionary<string, TermGroupInfo>
            {
                {BaseTermGroupInfoKeys.NavigationTermGroup, BaseTermGroupInfoValues.Navigation}
            };

            return termGroups;
        }
    }
}
