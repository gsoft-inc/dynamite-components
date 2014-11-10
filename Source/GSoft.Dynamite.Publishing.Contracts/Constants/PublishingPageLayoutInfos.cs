using System.Collections.Generic;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingPageLayoutInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        public PublishingPageLayoutInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        #region Target Item Page Layout

        public PageLayoutInfo TargetItemPageLayout()
        {
            return new PageLayoutInfo()
            {
                Name = "TargetItemPageLayout.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }
        #endregion

        #region Catalog Item Page Layout

        public PageLayoutInfo CatalogItemPageLayout()
        {
            return new PageLayoutInfo()
            {
                Name = "CatalogItemPageLayout.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }
        #endregion

        #region Catalog Category Items Page Layout

        public PageLayoutInfo CatalogCategoryItemsPageLayout()
        {
            return new PageLayoutInfo()
            {
                Name = "CatalogCategoryPageTemplate.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }
        #endregion
    }
}
