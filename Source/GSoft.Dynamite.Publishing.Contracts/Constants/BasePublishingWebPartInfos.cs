using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.WebParts;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Class to create the Basic Web Parts
    /// </summary>
    public class BasePublishingWebPartInfos
    {
        private readonly BasePublishingResultSourceInfos resultSourceInfos;
        private readonly BasePublishingDisplayTemplateInfos displayTemplateInfos;
        private readonly WebPartHelper webPartHelper;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webPartHelper">The WebPart helper</param>
        /// <param name="resultSourceInfos">The Result Source infos</param>
        /// <param name="displayTemplateInfos">The display templates infos</param>
        public BasePublishingWebPartInfos(WebPartHelper webPartHelper, BasePublishingResultSourceInfos resultSourceInfos, BasePublishingDisplayTemplateInfos displayTemplateInfos)
        {
            this.webPartHelper = webPartHelper;
            this.resultSourceInfos = resultSourceInfos;
            this.displayTemplateInfos = displayTemplateInfos;
        }

        /// <summary>
        /// Web part for Item Content
        /// </summary>
        /// <returns>WebPart info object</returns>
        public WebPartInfo ItemContentWebPart()
        {
            // When you set a result source to a Search WebPart, you need to use at least the Properties["SourceName"] and Properties["SourceLevel"] attributes
            var querySettings = new DataProviderScriptWebPart();
            querySettings.Properties["SourceName"] = this.resultSourceInfos.SingleTargetItem().Name;
            querySettings.Properties["SourceLevel"] = this.resultSourceInfos.SingleTargetItem().Level.ToString();
            querySettings.Properties["QueryTemplate"] = string.Empty;
            

            return new WebPartInfo("Item Content Webpart")
            {
                WebPart = new ResultScriptWebPart()
                {
                    DataProviderJSON = querySettings.PropertiesJson,
                    //ItemBodyTemplateId = this._displayTemplateInfos.ItemSingleContentItem().ItemTemplateIdUrl,
                    ChromeType = PartChromeType.None
                }
            };
        }

        /// <summary>
        /// Create a Place Holder webpartinfo
        /// </summary>
        /// <param name="x">Horizontal dimension in pixel</param>
        /// <param name="y">Vertical dimension in pixel</param>
        /// <param name="backgroundColor">Background color in hex ex: <c>"ffffff"</c> or <c>"e3b489"</c></param>
        /// <param name="fontColor">font color in hex ex: <c>"ffffff"</c> or <c>"e3b489"</c></param>
        /// <returns>A webpartinfo containing the webpart</returns>
        public WebPartInfo PlaceHolder(int x, int y, string backgroundColor, string fontColor)
        { 
            return new WebPartInfo("Place Holder")
            {
                WebPart = this.webPartHelper.CreatePlaceHolderWebPart(x, y, backgroundColor, fontColor)
            };
        }
    }
}
