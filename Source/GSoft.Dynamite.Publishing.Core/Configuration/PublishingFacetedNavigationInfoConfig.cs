using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingFacetedNavigationInfoConfig : IPublishingFacetedNavigationInfoConfig
    {
        private readonly PublishingFacetedNavigationInfos publishingFacetedNavigationInfos;

        public PublishingFacetedNavigationInfoConfig(PublishingFacetedNavigationInfos publishingFacetedNavigationInfos)
        {
            this.publishingFacetedNavigationInfos = publishingFacetedNavigationInfos;
        }

        public IList<FacetedNavigationInfo> FacetedNavigationInfos
        {
            get
            {
                return new List<FacetedNavigationInfo>()
                {
                    {this.publishingFacetedNavigationInfos.News}
                };
            }
        }
    }
}
