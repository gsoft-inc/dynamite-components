using System;
using System.Collections.Generic;
using System.Linq;
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
                    PublishingPageLayoutInfos.CatalogItemPageLayout,
                    PublishingPageLayoutInfos.TargetItemPageLayout,
                    PublishingPageLayoutInfos.CatalogCategoryItemsPageLayout,
                    PublishingPageLayoutInfos.RightSidebar,
                    PublishingPageLayoutInfos.BootstrapRightSidebar,
                    PublishingPageLayoutInfos.BootstrapTwoColumns,
                    PublishingPageLayoutInfos.OneColunmWithHeader,
                    PublishingPageLayoutInfos.OneColunmWithThreeTabs,
                    PublishingPageLayoutInfos.TwoColumnsAndOneColumn
                };
            }
        }

        /// <summary>
        /// Gets Page layout from this configuration using its file name including the aspx extention.
        /// </summary>
        /// <param name="name">The page layout name including aspx extention.</param>
        /// <returns>
        /// The page layout information.
        /// </returns>
        public PageLayoutInfo GetPageLayoutByName(string name)
        {
            return this.PageLayouts.Single(pageLayout => pageLayout.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
