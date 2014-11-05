using System.Collections.Generic;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingListInfoConfig : IPublishingListInfoConfig
    {
        private readonly PublishingListInfos publishingListInfos;

        public PublishingListInfoConfig(PublishingListInfos publishingListInfos)
        {
            this.publishingListInfos = publishingListInfos;
        }

        public IList<ListInfo> Lists
        {
            get
            {
                return new List<ListInfo>()
                {
                    this.publishingListInfos.PagesLibrary
                };
            }
        }
    }
}
