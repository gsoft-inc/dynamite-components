using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.WebParts;
using Microsoft.SharePoint.WebPartPages;

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
                    this.CatalogCategoryItemsPageTemplate,
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
        /// Gets the name of the page information by file and culture.
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The page information.</returns>
        public PageInfo GetPageInfoByFileName(string fileName, CultureInfo culture)
        {
            if (culture != null)
            {
                return this.Pages.SingleOrDefault(page => page.FileName.Equals(fileName, StringComparison.OrdinalIgnoreCase) && page.Culture.LCID.Equals(culture.LCID)); 
            }
            return this.Pages.SingleOrDefault(page => page.FileName.Equals(fileName, StringComparison.OrdinalIgnoreCase)); 
        }

        /// <summary>
        /// Gets the name of the page information by file
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <returns>The page information.</returns>
        public PageInfo GetPageInfoByFileName(string fileName)
        {
            return this.GetPageInfoByFileName(fileName, null);
        }
    }
}
