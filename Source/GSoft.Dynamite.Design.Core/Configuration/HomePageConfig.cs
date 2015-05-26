using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite;
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
    /// Configuration for the home page
    /// </summary>
    public class HomePageConfig : IHomePageConfig
    {
        private const string PlaceholderBackgroundColor = "#F1F1F1";
        private const string PlaceholderTextColor = "#696C72";

        private readonly IWebPartHelper webPartHelper;
        private readonly IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig;

        /// <summary>
        /// Creates a new home page instance configuration
        /// </summary>
        /// <param name="webPartHelper">Dynamite web part helper</param>
        /// <param name="publishingPageLayoutInfoConfig">The publishing page layout configuration</param>
        public HomePageConfig(
            IWebPartHelper webPartHelper,
            IPublishingPageLayoutInfoConfig publishingPageLayoutInfoConfig)
        {
            this.publishingPageLayoutInfoConfig = publishingPageLayoutInfoConfig;
            this.webPartHelper = webPartHelper;
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

                return page;
            }
        }

        /// <summary>
        /// Method that returns the appropriate home page according to its culture info
        /// </summary>
        /// <param name="cultureInfo">The home page's CultureInfo</param>
        /// <returns>Home page associated with <paramref name="cultureInfo"/>.</returns>
        public PageInfo GetHomePageInfoByCulture(CultureInfo cultureInfo)
        {
            // Try exact cultureinfo match
            if (cultureInfo.LCID == Language.English.Culture.LCID)
            {
                return this.HomePageEn;
            }
            else if (cultureInfo.LCID == Language.French.Culture.LCID)
            {
                return this.HomePageFr;
            }

            // Try partial match using TwoLetterISOName
            if (cultureInfo.TwoLetterISOLanguageName == Language.English.Culture.TwoLetterISOLanguageName)
            {
                return this.HomePageEn;
            }
            else if (cultureInfo.TwoLetterISOLanguageName == Language.French.Culture.TwoLetterISOLanguageName)
            {
                return this.HomePageFr;
            }

            throw new ArgumentException("No home page correspond to cultureInfo " + cultureInfo.DisplayName);
        }

        private WebPart GetPlaceholderWebPart(int height, string title)
        {
            var webPart = this.webPartHelper.CreateResponsivePlaceholderWebPart(height, PlaceholderBackgroundColor, PlaceholderTextColor, title);
            webPart.Title = title;
            return webPart;
        }
    }
}
