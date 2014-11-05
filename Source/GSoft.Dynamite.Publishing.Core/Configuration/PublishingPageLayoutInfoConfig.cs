using System.Collections.Generic;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingPageLayoutInfoConfig : IPublishingPageLayoutInfoConfig
    {
        private readonly PublishingPageLayoutInfos publishingPageLayoutInfos;

        public PublishingPageLayoutInfoConfig(PublishingPageLayoutInfos publishingPageLayoutInfos)
        {
            this.publishingPageLayoutInfos = publishingPageLayoutInfos;
        }

        public IList<PageLayoutInfo> PageLayouts
        {
            get
            {
                return new List<PageLayoutInfo>()
                {
                    this.publishingPageLayoutInfos.CatalogItemPageLayout(),
                    this.publishingPageLayoutInfos.TargetItemPageLayout()
                };
            }
        }
    }
}
