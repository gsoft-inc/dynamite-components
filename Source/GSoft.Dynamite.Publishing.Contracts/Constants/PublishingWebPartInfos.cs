using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.WebParts;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// WebPart definitions for the publishing module
    /// </summary>
    public class PublishingWebPartInfos
    {
        private readonly PublishingResultSourceInfos resultSourceInfos;
        private readonly PublishingDisplayTemplateInfos displayTemplateInfos;
        private readonly IWebPartHelper webPartHelper;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webPartHelper">The WebPart helper</param>
        /// <param name="resultSourceInfos">The Result Source info</param>
        /// <param name="displayTemplateInfos">The display templates info</param>
        public PublishingWebPartInfos(IWebPartHelper webPartHelper, PublishingResultSourceInfos resultSourceInfos, PublishingDisplayTemplateInfos displayTemplateInfos)
        {
            this.webPartHelper = webPartHelper;
            this.resultSourceInfos = resultSourceInfos;
            this.displayTemplateInfos = displayTemplateInfos;
        }

        /// <summary>
        /// WebPart for a single target item display (e.g. the "About Us" page)
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <returns>The WebPart info object</returns>
        public WebPartInfo TargetItemContentWebPart(string zoneName)
        {
            // When you set a result source to a Search WebPart, you need to use at least the Properties["SourceName"] and Properties["SourceLevel"] attributes
            var querySettings = new DataProviderScriptWebPart();
            querySettings.Properties["SourceName"] = this.resultSourceInfos.SingleTargetItem().Name;
            querySettings.Properties["SourceLevel"] = this.resultSourceInfos.SingleTargetItem().Level.ToString();
            querySettings.Properties["QueryTemplate"] = string.Empty;

            // To set a display template manually, use this line
            // ItemBodyTemplateId = this._displayTemplateInfos.ItemSingleContentItem().ItemTemplateIdUrl
            var webpart = new ResultScriptWebPart()
            {
                Title = "Target Item Content Webpart",
                DataProviderJSON = querySettings.PropertiesJson,
                ChromeType = PartChromeType.None,
                ShowAdvancedLink = false,
                ShowBestBets = false,
                ShowAlertMe = false,
                ShowLanguageOptions = false,
                ShowDidYouMean = false,
                ShowPaging = false,
                ShowResultCount = false,
                ShowPersonalFavorites = false,
                ShowSortOptions = false,
                ShowViewDuplicates = false,
                ShowDataErrors = false,
                ShowDefinitions = false,
                ShowPreferencesLink = false,
                ShowUpScopeMessage = false,
                ShowResults = true,
                BypassResultTypes = false,
                ResultsPerPage = 1,
                QueryGroupName = "SingleItem"
            };

            return new WebPartInfo(zoneName, webpart);
        }

        /// <summary>
        /// WebPart for a single catalog item display (e.g. a single news)
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <returns>The WebPart info object</returns>
        public WebPartInfo CatalogItemContentWebPart(string zoneName)
        {
            var querySettings = new DataProviderScriptWebPart();
            querySettings.Properties["SourceName"] = this.resultSourceInfos.SingleCatalogItem().Name;
            querySettings.Properties["SourceLevel"] = this.resultSourceInfos.SingleCatalogItem().Level.ToString();
            querySettings.Properties["QueryTemplate"] = string.Empty;

            var webpart = new ResultScriptWebPart()
            {
                Title = "Catalog Item Content Webpart",
                DataProviderJSON = querySettings.PropertiesJson,
                ChromeType = PartChromeType.None,
                ShowAdvancedLink = false,
                ShowBestBets = false,
                ShowAlertMe = false,
                ShowLanguageOptions = false,
                ShowDidYouMean = false,
                ShowPaging = false,
                ShowResultCount = false,
                ShowPersonalFavorites = false,
                ShowSortOptions = false,
                ShowViewDuplicates = false,
                ShowDataErrors = false,
                ShowDefinitions = false,
                ShowPreferencesLink = false,
                ShowUpScopeMessage = false,
                ShowResults = true,
                BypassResultTypes = false,
                ResultsPerPage = 1,
                QueryGroupName = "SingleItem"
            };

            return new WebPartInfo(zoneName, webpart);
        }

        /// <summary>
        /// Create a place holder WebPart
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <param name="x">Horizontal dimension in pixel</param>
        /// <param name="y">Vertical dimension in pixel</param>
        /// <param name="backgroundColor">Background color in hex ex: <c>"ffffff"</c> or <c>"e3b489"</c></param>
        /// <param name="fontColor">font color in hex ex: <c>"ffffff"</c> or <c>"e3b489"</c></param>
        /// <returns>The WebPart definition</returns>
        public WebPartInfo PlaceHolder(string zoneName, int x, int y, string backgroundColor, string fontColor)
        {
            var webpart = this.webPartHelper.CreatePlaceholderWebPart(x, y, backgroundColor, fontColor);

            return new WebPartInfo(zoneName, webpart);
        }

        /// <summary>
        /// WebPart for a multiple catalog items display (e.g. all news)
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <returns>The WebPart info object</returns>
        public WebPartInfo CatalogCategoryItemsMainWebPart(string zoneName)
        {
            var querySettings = new DataProviderScriptWebPart();
            querySettings.Properties["SourceName"] = this.resultSourceInfos.CatalogCategoryItems().Name;
            querySettings.Properties["SourceLevel"] = this.resultSourceInfos.CatalogCategoryItems().Level.ToString();
            querySettings.Properties["QueryTemplate"] = string.Empty;

            var webpart = new ResultScriptWebPart()
            {
                Title = "Catalog Category Items Main Content Webpart",
                DataProviderJSON = querySettings.PropertiesJson,
                ChromeType = PartChromeType.None,
                ShowAdvancedLink = false,
                ShowBestBets = false,
                ShowAlertMe = false,
                ShowLanguageOptions = false,
                ShowDidYouMean = false,
                ShowPaging = true,
                ShowResultCount = false,
                ShowPersonalFavorites = false,
                ShowSortOptions = false,
                ShowViewDuplicates = false,
                ShowDataErrors = false,
                ShowDefinitions = false,
                ShowPreferencesLink = false,
                ShowUpScopeMessage = false,
                ShowResults = true,
                BypassResultTypes = false,
                ResultsPerPage = 20,
                QueryGroupName = "CatalogCategoryItems"
            };

            return new WebPartInfo(zoneName, webpart);
        }

        /// <summary>
        /// WebPart for a catalog items refinements (e.g. all news)
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <returns>The WebPart info object</returns>
        public WebPartInfo CatalogCategoryRefinementWepart(string zoneName)
        {
            var webpart = new RefinementScriptWebPart()
            {
                Title = "Catalog Category Items Refinement Content Webpart",
                UseManagedNavigationRefiners = true,
                ChromeType = PartChromeType.None,
                ShowDataErrors = false,
                QueryGroupName = "CatalogCategoryItems"
            };

            return new WebPartInfo(zoneName, webpart);
        }
    }
}
