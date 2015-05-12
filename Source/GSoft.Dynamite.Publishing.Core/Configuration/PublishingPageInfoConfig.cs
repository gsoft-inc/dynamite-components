using System;
using System.Collections.Generic;
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
        private const string PlaceholderBackgroundColor = "#0092d7";
        private const string PlaceholderTextColor = "#ffffff";

        private readonly IPublishingWebPartInfoConfig publishingWebPartInfoConfig;
        private readonly IWebPartHelper webPartHelper;
        private readonly IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig;

        /// <summary>
        /// Creates a new publishing page instance configuration
        /// </summary>
        /// <param name="webPartHelper">Web part helper</param>
        /// <param name="publishingWebPartInfoConfig">Web part configuration</param>
        /// <param name="publishingPageLayoutInfoConfig">Page layout configuration</param>
        public PublishingPageInfoConfig(
            IWebPartHelper webPartHelper,
            IPublishingWebPartInfoConfig publishingWebPartInfoConfig, 
            IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig)
        {
            this.publishingWebPartInfoConfig = publishingWebPartInfoConfig;
            this.publishingPageLayoutInfoConfig = publishingPageLayoutInfoConfig;
            this.webPartHelper = webPartHelper;
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
                    this.HomePageEn,
                    this.HomePageFr
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

        private PageInfo HomePageEn
        {
            get
            {
                var page = PublishingPageInfos.HomepageEn;
                page.PageLayout = this.publishingPageLayoutInfoConfig.GetPageLayoutByName(PublishingPageLayoutInfos.RightSidebar.Name);
                page.WebParts = new[]
                {
                    new WebPartInfo("Header", this.GetPlaceholderWebPart(391, "Header content"), 0),
                    new WebPartInfo("Main", this.GetPlaceholderWebPart(391, "Main content"), 0),
                    new WebPartInfo("RightColumn", this.GetPlaceholderWebPart(391, "Right column content"), 0),
                };

                // Return the page
                return page;
            }
        }

        private PageInfo HomePageFr
        {
            get
            {
                var page = PublishingPageInfos.HomepageFr;
                page.PageLayout = this.publishingPageLayoutInfoConfig.GetPageLayoutByName(PublishingPageLayoutInfos.RightSidebar.Name);
                page.WebParts = new[]
                {
                    new WebPartInfo("Header", this.GetPlaceholderWebPart(391, "Contenu en-tête"), 0),
                    new WebPartInfo("Main", this.GetPlaceholderWebPart(391, "Contenu principal"), 0),
                    new WebPartInfo("RightColumn", this.GetPlaceholderWebPart(391, "Contenu colonne de droite"), 0),
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

        private WebPart GetPlaceholderWebPart(int height, string title)
        {
            var webPart = this.webPartHelper.CreateResponsivePlaceholderWebPart(height, PlaceholderBackgroundColor, PlaceholderTextColor, title);
            webPart.Title = title;
            return webPart;
        }
    }
}
