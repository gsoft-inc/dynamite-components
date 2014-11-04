using System.Collections.Generic;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class MultilingualismListInfoConfig : IPublishingListInfoConfig
    {
        private readonly PublishingListInfos multilingualismListInfos;

        public MultilingualismListInfoConfig(PublishingListInfos multilingualismListInfos)
        {
            this.multilingualismListInfos = multilingualismListInfos;
        }

        public IList<ListInfo> Lists
        {
            get
            {
                return new List<ListInfo>()
                {
                    this.multilingualismListInfos.PagesLibrary
                };
            }
        }
    }
}
