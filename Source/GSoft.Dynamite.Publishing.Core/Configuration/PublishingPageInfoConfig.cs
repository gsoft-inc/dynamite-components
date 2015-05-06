using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Default page configurations for the publishing module
    /// </summary>
    public class PublishingPageInfoConfig : IPublishingPageInfoConfig
    {
        private readonly IPublishingWebPartInfoConfig publishingWebPartInfoConfig;
        private readonly IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig;

        /// <summary>
        /// Creates a new publishing page instance configuration
        /// </summary>
        /// <param name="publishingWebPartInfoConfig">Web part configuration</param>
        /// <param name="publishingPageLayoutInfoConfig">Page layout configuration</param>
        public PublishingPageInfoConfig(
            IPublishingWebPartInfoConfig publishingWebPartInfoConfig, 
            IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig)
        {
            this.publishingWebPartInfoConfig = publishingWebPartInfoConfig;
            this.publishingPageLayoutInfoConfig = publishingPageLayoutInfoConfig;
        }

        /// <summary>
        /// Property that returns all page configurations for the publishing module.
        /// </summary>
        public IList<PageInfo> Pages
        {
            get 
            {
                return new List<PageInfo>()
                {
                    this.TargetItemPageTemplate,
                    this.CatalogItemPageTemplate,
                    this.CatalogCategoryItemsPageTemplate
                };
            }
        }

        private PageInfo TargetItemPageTemplate
        {
            get
            {
                // Prepare the web parts
                var webPart = this.publishingWebPartInfoConfig.GetWebPartInfoByTitle(PublishingWebPartInfos.TargetItemContentWebPart.WebPart.Title);
                webPart.ZoneName = "Main";

                // Prepare the page
                var page = PublishingPageInfos.TargetItemPageTemplate;
                page.PageLayout = this.publishingPageLayoutInfoConfig.GetPageLayoutByName(PublishingPageLayoutInfos.TargetItemPageLayout.Name);
                page.WebParts = new[]
                {
                    webPart
                };

                // Return the page
                return page;
            }
        }

        private PageInfo CatalogItemPageTemplate
        {
            get
            {
                // Prepare the web parts
                var webPart = this.publishingWebPartInfoConfig.GetWebPartInfoByTitle(PublishingWebPartInfos.CatalogItemContentWebPart.WebPart.Title);
                webPart.ZoneName = "Main";

                // Prepare the page
                var page = PublishingPageInfos.CatalogItemPageTemplate;
                page.PageLayout = this.publishingPageLayoutInfoConfig.GetPageLayoutByName(PublishingPageLayoutInfos.CatalogItemPageLayout.Name);
                page.WebParts = new[]
                {
                    webPart
                };

                // Return the page
                return page;
            }
        }

        private PageInfo CatalogCategoryItemsPageTemplate
        {
            get
            {
                // Prepare the web parts
                var TargetItemContentWebPart = this.publishingWebPartInfoConfig.GetWebPartInfoByTitle(PublishingWebPartInfos.TargetItemContentWebPart.WebPart.Title);
                TargetItemContentWebPart.ZoneName = "Header";

                var CatalogCategoryItemsMainWebPart = this.publishingWebPartInfoConfig.GetWebPartInfoByTitle(PublishingWebPartInfos.CatalogCategoryItemsMainWebPart.WebPart.Title);
                CatalogCategoryItemsMainWebPart.ZoneName = "Main";

                var CatalogCategoryRefinementWepart = this.publishingWebPartInfoConfig.GetWebPartInfoByTitle(PublishingWebPartInfos.CatalogCategoryRefinementWebPart.WebPart.Title);
                CatalogCategoryRefinementWepart.ZoneName = "RightColumn";

                // Prepare the page
                var page = PublishingPageInfos.CatalogCategoryItemsPageTemplate;
                page.PageLayout = this.publishingPageLayoutInfoConfig.GetPageLayoutByName(PublishingPageLayoutInfos.CatalogCategoryItemsPageLayout.Name);
                page.WebParts = new[]
                {
                    TargetItemContentWebPart,
                    CatalogCategoryItemsMainWebPart,
                    CatalogCategoryRefinementWepart
                };

                // Return the page
                return page;
            }
        }

        /// <summary>
        /// Gets the page information by file name from this configuration.
        /// </summary>
        /// <param name="fileName">The file name of the page without the ASPX extension.</param>
        /// <returns>
        /// The page information
        /// </returns>
        public PageInfo GetPageInfoByFileName(string fileName)
        {
            return this.Pages.Single(p => p.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
