using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Design.Contracts.Constants;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.WebParts;
using Microsoft.SharePoint.WebPartPages;

namespace GSoft.Dynamite.Design.Core.Configuration
{
    /// <summary>
    /// Home pages configurations for the design module
    /// </summary>
    public class DesignPageInfoConfig : IDesignPageInfoConfig
    {
        private const string PlaceholderBackgroundColor = "#F1F1F1";
        private const string PlaceholderTextColor = "#696C72";

        private readonly IWebPartHelper webPartHelper;
        private readonly IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig;

        /// <summary>
        /// Creates a new design page instance configuration
        /// </summary>
        /// <param name="webPartHelper">Dynamite web part helper</param>
        /// <param name="publishingPageLayoutInfoConfig">The publishing page layout configuration</param>
        public DesignPageInfoConfig(
            IWebPartHelper webPartHelper,
            IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig)
        {
            this.publishingPageLayoutInfoConfig = publishingPageLayoutInfoConfig;
            this.webPartHelper = webPartHelper;
        }

        /// <summary>
        /// Property that returns all page configurations for the design module.
        /// </summary>
        public IList<PageInfo> Pages
        {
            get 
            {
                return new List<PageInfo>()
                {
                    this.HomePageEn,
                    this.HomePageFr
                };
            }
        }

        private PageInfo HomePageEn
        {
            get
            {
                var page = DesignPageInfos.HomepageEn;
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
                var page = DesignPageInfos.HomepageFr;
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
