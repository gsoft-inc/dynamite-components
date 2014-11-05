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
                ContentTypeId = this.contentTypeInfo.DefaultPage().ContentTypeId,
                WebParts = new List<WebPartInfo>()
                {
                    { this.webPartInfos.TargetItemContentWebPart("Main") }
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
                ContentTypeId = this.contentTypeInfo.DefaultPage().ContentTypeId,
                WebParts = new List<WebPartInfo>()
                {
                    { this.webPartInfos.CatalogItemContentWebPart("Main") }
                },
                IsPublished = true
            };
        }

        #endregion
    }
}
