using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingPageInfos
    {
        private readonly BasePublishingPageLayoutInfos pageLayoutInfo;
        private readonly BasePublishingContentTypeInfos contentTypeInfo;
        private readonly BasePublishingWebPartInfos webPartInfos;

        public BasePublishingPageInfos(BasePublishingPageLayoutInfos pageLayoutInfos, BasePublishingContentTypeInfos contentTypeInfos, BasePublishingWebPartInfos webPartInfos)
        {
            this.pageLayoutInfo = pageLayoutInfos;
            this.contentTypeInfo = contentTypeInfos;
            this.webPartInfos = webPartInfos;
        }

        #region Target Item Page Template

        public PageInfo TargetItemPageTemplate()
        {
            return new PageInfo()
            {
                FileName = "TargetItemPageTemplate",
                Title = "Target Item Page Template",
                PageLayout = this.pageLayoutInfo.TargetItemPageLayout(),
                ContentTypeId = this.contentTypeInfo.Page().ContentTypeId,
                WebParts = new Dictionary<string, WebPartInfo>()
                {
                    {"Main",this.webPartInfos.TargetItemContentWebPart()}
                }
            };
        }

        #endregion

        #region Catalog Item Page Template

        public PageInfo CatalogItemPageTemplate()
        {
            return new PageInfo()
            {
                FileName = "CatalogItemPageTemplate",
                Title = "Catalog Item Page Template",
                PageLayout = this.pageLayoutInfo.CatalogItemPageLayout(),
                ContentTypeId = this.contentTypeInfo.Page().ContentTypeId,
                WebParts = new Dictionary<string, WebPartInfo>()
                {
                    {"Main",this.webPartInfos.CatalogItemContentWebPart()}
                }
            };
        }

        #endregion
    }
}
