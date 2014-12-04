using System.Collections.Generic;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration of publishing module page layouts
    /// </summary>
    public class PublishingPageLayoutInfoConfig : IPublishingPageLayoutInfoConfig
    {
        private readonly PublishingPageLayoutInfos publishingPageLayoutInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingPageLayoutInfos">The page layouts info configuration objects</param>
        public PublishingPageLayoutInfoConfig(PublishingPageLayoutInfos publishingPageLayoutInfos)
        {
            this.publishingPageLayoutInfos = publishingPageLayoutInfos;
        }

        /// <summary>
        /// Property that return all the pages layouts used in the publishing module
        /// Page layouts are deployed through a module in the SharePoint project
        /// </summary>
        public IList<PageLayoutInfo> PageLayouts
        {
            get
            {
                return new List<PageLayoutInfo>()
                {
                    this.publishingPageLayoutInfos.CatalogItemPageLayout(),
                    this.publishingPageLayoutInfos.TargetItemPageLayout(),
                    this.publishingPageLayoutInfos.CatalogCategoryItemsPageLayout(),
                    this.publishingPageLayoutInfos.RightSidebar(),
                    this.publishingPageLayoutInfos.OneColunmWithHeader(),
                    this.publishingPageLayoutInfos.OneColunmWithThreeTabs()
                };
            }
        }
    }
}
