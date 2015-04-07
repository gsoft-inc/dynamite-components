using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Page layouts definitions for the publishing module
    /// </summary>
    public class PublishingPageLayoutInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfos">The page layouts info objects configuration</param>
        public PublishingPageLayoutInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        #region Target Item Page Layout

        /// <summary>
        /// The target item page layout
        /// </summary>
        /// <returns>The page layout info</returns>
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

        /// <summary>
        /// The catalog item page layout
        /// </summary>
        /// <returns>The page layout info</returns>
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

        /// <summary>
        /// The catalog category page layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public PageLayoutInfo CatalogCategoryItemsPageLayout()
        {
            return new PageLayoutInfo()
            {
                Name = "CatalogCategoryPageTemplate.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }
        #endregion

        #region Right Sidebar Page Layout

        /// <summary>
        /// The right sidebar generic page layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public PageLayoutInfo RightSidebar()
        {
            return new PageLayoutInfo()
            {
                Name = "RightSidebar.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }

        /// <summary>
        /// The right sidebar generic page layout using Bootstrap
        /// </summary>
        /// <returns>The page layout info</returns>
        public PageLayoutInfo BootstrapRightSidebar()
        {
            return new PageLayoutInfo()
            {
                Name = "BootstrapRightSidebar.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }

        /// <summary>
        /// The two columns generic page layout using Bootstrap
        /// </summary>
        /// <returns>The page layout info</returns>
        public PageLayoutInfo BootstrapTwoColumns()
        {
            return new PageLayoutInfo()
            {
                Name = "BootstrapTwoColumns.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }

        /// <summary>
        /// A layout with a single column body and an header section
        /// </summary>
        /// <returns>The Page Layout Info</returns>
        public PageLayoutInfo OneColunmWithHeader()
        {
            return new PageLayoutInfo()
            {
                Name = "OneColumnWithHeader.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }

        /// <summary>
        /// A layout with a single column body with three different sections and an header section with the navigation
        /// </summary>
        /// <returns>The Page Layout Info</returns>
        public PageLayoutInfo OneColunmWithThreeTabs()
        {
            return new PageLayoutInfo()
            {
                Name = "OneColumnWithThreeTabs.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }

        /// <summary>
        /// A layout with two columns and one large column.
        /// </summary>
        /// <returns>The Page Layout Info</returns>
        public PageLayoutInfo TwoColumnsAndOneColumn()
        {
            return new PageLayoutInfo()
            {
                Name = "TwoColumnsOneColumn.aspx",
                AssociatedContentTypeId = this.publishingContentTypeInfos.DefaultPage().ContentTypeId
            };
        }
        #endregion
    }
}
