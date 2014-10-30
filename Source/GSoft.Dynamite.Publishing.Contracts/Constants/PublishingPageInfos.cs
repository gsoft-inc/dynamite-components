using System.Collections.Generic;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingPageInfos
    {
        private readonly PublishingPageLayoutInfos pageLayoutInfo;
        private readonly PublishingContentTypeInfos contentTypeInfo;
        private readonly PublishingWebPartInfos webPartInfos;

        public PublishingPageInfos(PublishingPageLayoutInfos pageLayoutInfos, PublishingContentTypeInfos contentTypeInfos, PublishingWebPartInfos webPartInfos)
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
                },
                IsPublished = true             
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
                },
                IsPublished = true
            };
        }

        #endregion
    }
}
