using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingFolderInfos
    {
        public BasePublishingFolderInfos FolderInfos { get; set; }
        private readonly BasePublishingPageInfos _pageInfos;

        public BasePublishingFolderInfos( BasePublishingPageInfos pageInfos)
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
                    this.FolderInfos.FolderTest()
                },
                Pages = new Dictionary<string, PageInfo>()
                {
                    {BasePublishingPageInfoKeys.TargetItemPageTemplate,this._pageInfos.TargetItemPageTemplate()},
                    {BasePublishingPageInfoKeys.CatalogItemPageTemplate,this._pageInfos.CatalogItemPageTemplate()}
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
                    this.FolderInfos.FolderTest2()
                },
            };
        }

        public FolderInfo FolderTest2()
        {
            return new FolderInfo()
            {
                Name = "Folder2",
                Pages = new Dictionary<string, PageInfo>()
                {
                    {BasePublishingPageInfoKeys.TargetItemPageTemplate,this._pageInfos.TargetItemPageTemplate()},
                    {BasePublishingPageInfoKeys.CatalogItemPageTemplate,this._pageInfos.CatalogItemPageTemplate()}
                }
            };

        }
    }
}
