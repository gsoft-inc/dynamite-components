using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Page layouts definitions for the publishing module
    /// </summary>
    public static class PublishingPageLayoutInfos
    {
        #region Target Item Page Layout

        /// <summary>
        /// The target item page layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo TargetItemPageLayout
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "TargetItemPageLayout.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }
        #endregion

        #region Catalog Item Page Layout

        /// <summary>
        /// The catalog item page layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo CatalogItemPageLayout
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "CatalogItemPageLayout.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }
        #endregion

        #region Catalog Category Items Page Layout

        /// <summary>
        /// The catalog category page layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo CatalogCategoryItemsPageLayout
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "CatalogCategoryPageTemplate.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }
        #endregion

        #region Right Sidebar Page Layout

        /// <summary>
        /// The right sidebar generic page layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo RightSidebar
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "RightSidebar.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The right sidebar generic page layout using Bootstrap
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapRightSidebar
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapRightSidebar.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The two columns generic page layout using Bootstrap
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapTwoColumns
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapTwoColumns.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The one column generic page layout using Bootstrap
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapOneColumn
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapOneColumn.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The left slim sidebar generic page layout using Bootstrap
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapLeftSlimSidebar
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapLeftSlimSidebar.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The Bootstrap Three Equal Columns Page Layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapThreeColumns
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapThreeColumns.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The Bootstrap Four Equal Columns Page Layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapFourColumns
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapFourColumns.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The Bootstrap Left Sidebar Page Layout
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapLeftSidebar
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapLeftSidebar.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// The Bootstrap Right Slim Sidebar
        /// </summary>
        /// <returns>The page layout info</returns>
        public static PageLayoutInfo BootstrapRightSlimSidebar
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "BootstrapRightSlimSidebar.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// A layout with a single column body and an header section
        /// </summary>
        /// <returns>The Page Layout Info</returns>
        public static PageLayoutInfo OneColunmWithHeader
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "OneColumnWithHeader.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// A layout with a single column body with three different sections and an header section with the navigation
        /// </summary>
        /// <returns>The Page Layout Info</returns>
        public static PageLayoutInfo OneColunmWithThreeTabs
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "OneColumnWithThreeTabs.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }

        /// <summary>
        /// A layout with two columns and one large column.
        /// </summary>
        /// <returns>The Page Layout Info</returns>
        public static PageLayoutInfo TwoColumnsAndOneColumn
        {
            get
            {
                return new PageLayoutInfo()
                {
                    Name = "TwoColumnsOneColumn.aspx",
                    AssociatedContentTypeId = PublishingContentTypeInfos.DefaultPage.ContentTypeId
                };
            }
        }
        #endregion
    }
}
