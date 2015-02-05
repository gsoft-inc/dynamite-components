using System.Collections.Generic;
using GSoft.Dynamite.Folders;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Folders definitions for the publishing module. Be careful, pages are always created through a folder, never individually.
    /// </summary>
    public class PublishingFolderInfos
    {
        private readonly PublishingPageInfos pageInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pageInfos">The page info objects configuration</param>
        public PublishingFolderInfos(PublishingPageInfos pageInfos)
        {
            this.pageInfos = pageInfos;
        }

        /// <summary>
        /// Folder that contains items page instances
        /// </summary>
        /// <returns>The folder info</returns>
        public FolderInfo ItemPageTemplates()
        {
            return new FolderInfo()
            {
                Name = "ItemPageTemplates",
                Subfolders = new FolderInfo[]
                {
                    this.FolderTest()
                },
                Pages = new List<PageInfo>()
                {
                    this.pageInfos.TargetItemPageTemplate(),
                    this.pageInfos.CatalogItemPageTemplate(),
                }
            };
        }

        /// <summary>
        /// Folder that contains category page instance
        /// </summary>
        /// <returns>The folder info</returns>
        public FolderInfo CategoryPageTemplates()
        {
            return new FolderInfo()
            {
                Name = "CategoryPageTemplates",
                Subfolders = new FolderInfo[]
                {
                    this.FolderTest()
                },
                Pages = new List<PageInfo>()
                {
                    this.pageInfos.CatalogCategoryItemsPageTemplate(),
                }
            };
        }

        /// <summary>
        /// Test nested folder
        /// </summary>
        /// <returns>The folder info</returns>
        public FolderInfo FolderTest()
        {
            return new FolderInfo()
            {
                Name = "Folder1",
                Subfolders = new FolderInfo[]
                {
                    this.FolderTest2()
                },
            };
        }

        /// <summary>
        /// Test nested folder
        /// </summary>
        /// <returns>The folder info</returns>
        public FolderInfo FolderTest2()
        {
            return new FolderInfo()
            {
                Name = "Folder2",
                Pages = new List<PageInfo>()
                {
                    this.pageInfos.TargetItemPageTemplate(),
                    this.pageInfos.CatalogItemPageTemplate()
                }
            };
        }
    }
}
