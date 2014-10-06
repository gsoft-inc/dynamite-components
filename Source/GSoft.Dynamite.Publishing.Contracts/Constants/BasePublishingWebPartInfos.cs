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

        public WebPartInfo ItemContentWebPart()
        {
            // When you set a result source to a Search WebPart, you need to use at least the Properties["SourceName"] and Properties["SourceLevel"] attributes
            var querySettings = new DataProviderScriptWebPart();
            querySettings.Properties["SourceName"] = this._resultSourceInfos.SingleTargetItem().Name;
            querySettings.Properties["SourceLevel"] = this._resultSourceInfos.SingleTargetItem().Level.ToString();
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
    }
}
