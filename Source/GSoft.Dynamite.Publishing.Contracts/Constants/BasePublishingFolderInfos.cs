using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingFolderInfos
    {
        private readonly BasePublishingPageInfos _pageInfos;

        public BasePublishingFolderInfos(BasePublishingPageInfos pageInfos)
        {
            this._pageInfos = pageInfos;
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
                    {this._pageInfos.TargetItemPageTemplate()},
                    {this._pageInfos.CatalogItemPageTemplate()}
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
                    {this._pageInfos.TargetItemPageTemplate()},
                    {this._pageInfos.CatalogItemPageTemplate()}
                }
            };

        }
    }
}
