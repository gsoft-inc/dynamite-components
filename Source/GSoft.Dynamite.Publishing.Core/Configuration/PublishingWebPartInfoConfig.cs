using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.WebParts;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Default configuration of web parts for the publishing module.
    /// </summary>
    public class PublishingWebPartInfoConfig : IPublishingWebPartInfoConfig
    {
        private readonly IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishingWebPartInfoConfig"/> class.
        /// </summary>
        /// <param name="publishingResultSourceInfoConfig">The publishing result source information configuration.</param>
        public PublishingWebPartInfoConfig(IPublishingResultSourceInfoConfig publishingResultSourceInfoConfig)
        {
            this.publishingResultSourceInfoConfig = publishingResultSourceInfoConfig;
        }

        /// <summary>
        /// Property that returns all web part configurations for the publishing module.
        /// </summary>
        public IList<WebPartInfo> WebParts
        {
            get
            {
                return new[]
                {
                    this.TargetItemContentWebPart,
                    this.CatalogItemContentWebPart,
                    this.CatalogCategoryItemsMainWebPart,
                    PublishingWebPartInfos.CatalogCategoryRefinementWebPart
                };
            }
        }

        private WebPartInfo TargetItemContentWebPart
        {
            get
            {
                // When you set a result source to a Search WebPart, you need to use at least the Properties["SourceName"] and Properties["SourceLevel"] attributes
                var resultSource = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.SingleTargetItem.Name);
                var querySettings = new DataProviderScriptWebPart();
                querySettings.Properties["SourceName"] = resultSource.Name;
                querySettings.Properties["SourceLevel"] = resultSource.Level.ToString();
                querySettings.Properties["QueryTemplate"] = string.Empty;

                // Update the web part information
                var webPartInfo = PublishingWebPartInfos.TargetItemContentWebPart;
                var webPart = webPartInfo.WebPart as ResultScriptWebPart;
                webPart.DataProviderJSON = querySettings.PropertiesJson;
                webPartInfo.WebPart = webPart;

                // Return the webpart
                return webPartInfo;
            }
        }

        private WebPartInfo CatalogItemContentWebPart
        {
            get
            {
                // When you set a result source to a Search WebPart, you need to use at least the Properties["SourceName"] and Properties["SourceLevel"] attributes
                var resultSource = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.SingleCatalogItem.Name);
                var querySettings = new DataProviderScriptWebPart();
                querySettings.Properties["SourceName"] = resultSource.Name;
                querySettings.Properties["SourceLevel"] = resultSource.Level.ToString();
                querySettings.Properties["QueryTemplate"] = string.Empty;

                // Update the web part information
                var webPartInfo = PublishingWebPartInfos.CatalogItemContentWebPart;
                var webPart = webPartInfo.WebPart as ResultScriptWebPart;
                webPart.DataProviderJSON = querySettings.PropertiesJson;
                webPartInfo.WebPart = webPart;

                // Return the webpart
                return webPartInfo;
            }
        }

        private WebPartInfo CatalogCategoryItemsMainWebPart
        {
            get
            {
                // When you set a result source to a Search WebPart, you need to use at least the Properties["SourceName"] and Properties["SourceLevel"] attributes
                var resultSource = this.publishingResultSourceInfoConfig.GetResultSourceInfoByName(PublishingResultSourceInfos.CatalogCategoryItems.Name);
                var querySettings = new DataProviderScriptWebPart();
                querySettings.Properties["SourceName"] = resultSource.Name;
                querySettings.Properties["SourceLevel"] = resultSource.Level.ToString();
                querySettings.Properties["QueryTemplate"] = string.Empty;

                // Update the web part information
                var webPartInfo = PublishingWebPartInfos.CatalogCategoryItemsMainWebPart;
                var webPart = webPartInfo.WebPart as ResultScriptWebPart;
                webPart.DataProviderJSON = querySettings.PropertiesJson;
                webPartInfo.WebPart = webPart;

                // Return the webpart
                return webPartInfo;
            }
        }

        /// <summary>
        /// Gets the web part information by title from this configuration.
        /// </summary>
        /// <param name="title">The title of the web part.</param>
        /// <returns>
        /// The web part information
        /// </returns>
        public WebPartInfo GetWebPartInfoByTitle(string title)
        {
            return this.WebParts.Single(w => w.WebPart.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}
