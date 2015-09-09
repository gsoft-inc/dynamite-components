using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.WebParts;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// WebPart definitions for the publishing module
    /// </summary>
    public static class PublishingWebPartInfos
    {
        /// <summary>
        /// WebPart for a single target item display (e.g. the "About Us" page)
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <returns>The WebPart info object</returns>
        public static WebPartInfo TargetItemContentWebPart
        {
            get
            {
                var webpart = new ResultScriptWebPart()
                {
                    Title = "Target Item Content Webpart",
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

                return new WebPartInfo()
                {
                    WebPart = webpart
                };
            }
        }

        /// <summary>
        /// WebPart for a single catalog item display (e.g. a single news)
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <returns>The WebPart info object</returns>
        public static WebPartInfo CatalogItemContentWebPart
        {
            get
            {
                var webpart = new ResultScriptWebPart()
                {
                    Title = "Catalog Item Content Webpart",
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

                return new WebPartInfo()
                {
                    WebPart = webpart,
                };
            }
        }

        /// <summary>
        /// WebPart for a multiple catalog items display (e.g. all news)
        /// </summary>
        /// <param name="zoneName">The name of the zone in the page layout</param>
        /// <returns>The WebPart info object</returns>
        public static WebPartInfo CatalogCategoryItemsMainWebPart
        {
            get
            {
                var webpart = new ResultScriptWebPart()
                {
                    Title = "Catalog Category Items Main Content Webpart",
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

                return new WebPartInfo()
                {
                    WebPart = webpart,
                };
            }
        }

        /// <summary>
        /// WebPart for a catalog items refinements (e.g. all news)
        /// </summary>
        /// <returns>The WebPart info object</returns>
        public static WebPartInfo CatalogCategoryRefinementWebPart
        {
            get
            {
                var webpart = new RefinementScriptWebPart()
                {
                    Title = "Catalog Category Items Refinement Content Webpart",
                    UseManagedNavigationRefiners = true,
                    ChromeType = PartChromeType.None,
                    ShowDataErrors = false,
                    QueryGroupName = "CatalogCategoryItems"
                };

                return new WebPartInfo()
                {
                    WebPart = webpart
                };
            }
        }
    }
}
