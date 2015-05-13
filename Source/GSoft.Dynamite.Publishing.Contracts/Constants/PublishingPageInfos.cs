using System.Collections.Generic;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Page definitions for the publishing module
    /// </summary>
    public static class PublishingPageInfos
    {
        #region Target Item Page Template

        /// <summary>
        /// The target item page template instance to create in the pages library
        /// </summary>
        /// <returns>The page info</returns>
        public static PageInfo TargetItemPageTemplate
        {
            get
            {
                return new PageInfo()
                {
                    FileName = "TargetItemPageTemplate",
                    Title = "Target Item Page Template",
                    IsPublished = true
                };
            }
        }

        #endregion

        #region Catalog Item Page Template

        /// <summary>
        /// The catalog item page template instance to create in the pages library
        /// </summary>
        /// <returns>The page info</returns>
        public static PageInfo CatalogItemPageTemplate
        {
            get
            {
                {
                    return new PageInfo()
                    {
                        FileName = "CatalogItemPageTemplate",
                        Title = "Catalog Item Page Template",
                        IsPublished = true
                    };
                }
            }
        }

        #endregion

        #region Catalog Category Items Page Template

        /// <summary>
        /// The catalog category items page template instance to create in the pages library
        /// </summary>
        /// <returns>The page info</returns>
        public static PageInfo CatalogCategoryItemsPageTemplate
        {
            get
            {
                {
                    return new PageInfo()
                    {
                        FileName = "CatalogCategoryPageTemplate",
                        Title = "Catalog Category Page Template",
                        IsPublished = true
                    };
                }
            }
        }

        #endregion
    }
}
