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

        public FolderInfo RootFolder()
        {
            return new FolderInfo()
            {
                IsRootFolder = true,
                Name = "RootFolder",
                SubFolders = new FolderInfo[]
                {
                    this.FolderTest()
                },
                Pages = new List<PageInfo>()
                {
                    {this.pageInfos.TargetItemPageTemplate()},
                    {this.pageInfos.CatalogItemPageTemplate()}
                }
            };
        }

        public FolderInfo FolderTest()
        {
            return new FolderInfo()
            {
                Name = "Folder1",
                SubFolders = new FolderInfo[]
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
