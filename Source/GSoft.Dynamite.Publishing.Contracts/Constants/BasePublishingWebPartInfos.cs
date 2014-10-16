using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Definitions;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingWebPartInfos
    {
        private readonly BasePublishingResultSourceInfos _resultSourceInfos;
        private readonly BasePublishingDisplayTemplateInfos _displayTemplateInfos;

        public BasePublishingWebPartInfos(BasePublishingResultSourceInfos resultSourceInfos, BasePublishingDisplayTemplateInfos displayTemplateInfos)
        {
            this._resultSourceInfos = resultSourceInfos;
            this._displayTemplateInfos = displayTemplateInfos;
        }

        public WebPartInfo TargetItemContentWebPart()
        {
            // When you set a result source to a Search WebPart, you need to use at least the Properties["SourceName"] and Properties["SourceLevel"] attributes
            var querySettings = new DataProviderScriptWebPart();
            querySettings.Properties["SourceName"] = this._resultSourceInfos.SingleTargetItem().Name;
            querySettings.Properties["SourceLevel"] = this._resultSourceInfos.SingleTargetItem().Level.ToString();
            querySettings.Properties["QueryTemplate"] = string.Empty;
            

            return new WebPartInfo("Target Item Content Webpart")
            {
                WebPart = new ResultScriptWebPart()
                {
                    DataProviderJSON = querySettings.PropertiesJson,
                    // To set a display template manually, use this line
                    //ItemBodyTemplateId = this._displayTemplateInfos.ItemSingleContentItem().ItemTemplateIdUrl,
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
                    ResultsPerPage = 1
                }
            };
        }

        public WebPartInfo CatalogItemContentWebPart()
        {
            var querySettings = new DataProviderScriptWebPart();
            querySettings.Properties["SourceName"] = this._resultSourceInfos.SingleCatalogItem().Name;
            querySettings.Properties["SourceLevel"] = this._resultSourceInfos.SingleCatalogItem().Level.ToString();
            querySettings.Properties["QueryTemplate"] = string.Empty;


            return new WebPartInfo("Catalog Item Content Webpart")
            {
                WebPart = new ResultScriptWebPart()
                {
                    DataProviderJSON = querySettings.PropertiesJson,
                    //ItemBodyTemplateId = this._displayTemplateInfos.ItemSingleContentItem().ItemTemplateIdUrl,
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
                    ResultsPerPage = 1
                }
            };
        }
    }
}
