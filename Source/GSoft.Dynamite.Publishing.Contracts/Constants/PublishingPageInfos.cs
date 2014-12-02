using System.Collections.Generic;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Page definitions for the publishing module
    /// </summary>
    public class PublishingPageInfos
    {
        private readonly PublishingPageLayoutInfos pageLayoutInfo;
        private readonly PublishingContentTypeInfos contentTypeInfo;
        private readonly PublishingWebPartInfos webPartInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pageLayoutInfos">The page layout info objects configuration</param>
        /// <param name="contentTypeInfos">The content type info objects configuration</param>
        /// <param name="webPartInfos">The web part info objects configuration</param>
        public PublishingPageInfos(PublishingPageLayoutInfos pageLayoutInfos, PublishingContentTypeInfos contentTypeInfos, PublishingWebPartInfos webPartInfos)
        {
            this.pageLayoutInfo = pageLayoutInfos;
            this.contentTypeInfo = contentTypeInfos;
            this.webPartInfos = webPartInfos;
        }

        #region Target Item Page Template

        /// <summary>
        /// The target item page template instance to create in the pages library
        /// </summary>
        /// <returns>The page info</returns>
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

        /// <summary>
        /// The catalog item page template instance to create in the pages library
        /// </summary>
        /// <returns>The page info</returns>
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

        #region Catalog Category Items Page Template

        /// <summary>
        /// The catalog category items page template instance to create in the pages library
        /// </summary>
        /// <returns>The page info</returns>
        public PageInfo CatalogCategoryItemsPageTemplate()
        {
            return new PageInfo()
            {
                FileName = "CatalogCategoryPageTemplate",
                Title = "Catalog Category Page Template",
                PageLayout = this.pageLayoutInfo.CatalogCategoryItemsPageLayout(),
                ContentTypeId = this.contentTypeInfo.DefaultPage().ContentTypeId,
                WebParts = new List<WebPartInfo>()
                {
                    { this.webPartInfos.TargetItemContentWebPart("Header") },
                    { this.webPartInfos.CatalogCategoryItemsMainWebPart("Main") },
                    { this.webPartInfos.CatalogCategoryRefinementWepart("RightColumn") }
                },
                IsPublished = true
            };
        }

        #endregion
    }
}
