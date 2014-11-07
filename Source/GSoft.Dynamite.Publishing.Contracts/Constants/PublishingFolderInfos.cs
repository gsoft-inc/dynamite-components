using System.Collections.Generic;
using GSoft.Dynamite.Folders;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingFolderInfos
    {
        private readonly PublishingPageInfos pageInfos;

        public PublishingFolderInfos(PublishingPageInfos pageInfos)
        {
            this.pageInfos = pageInfos;
        }

        public FolderInfo ItemPageTemplates()
        {
            return new FolderInfo()
            {
                IsRootFolder = true,
                Name = "ItemPageTemplates",
                Subfolders = new FolderInfo[]
                {
                    this.FolderTest()
                },
                Pages = new List<PageInfo>()
                {
                    {this.pageInfos.TargetItemPageTemplate()},
                    {this.pageInfos.CatalogItemPageTemplate()},
                }
            };
        }

        public FolderInfo CategoryPageTemplates()
        {
            return new FolderInfo()
            {
                IsRootFolder = true,
                Name = "CategoryPageTemplates",
                Subfolders = new FolderInfo[]
                {
                    this.FolderTest()
                },
                Pages = new List<PageInfo>()
                {
                    {this.pageInfos.CatalogCategoryItemsPageTemplate()},
                }
            };
        }

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

        public FolderInfo FolderTest2()
        {
            return new FolderInfo()
            {
                Name = "Folder2",
                Pages = new List<PageInfo>()
                {
                    {this.pageInfos.TargetItemPageTemplate()},
                    {this.pageInfos.CatalogItemPageTemplate()}
                }
            };

        }
    }
}
