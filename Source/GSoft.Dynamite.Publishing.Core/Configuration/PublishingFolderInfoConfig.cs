using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingFolderInfoConfig : IPublishingFolderInfoConfig
    {
        private readonly PublishingFolderInfos folderInfos;

        public PublishingFolderInfoConfig(PublishingFolderInfos folderInfos)
        {
            this.folderInfos = folderInfos;
        }

        public FolderInfo RootFolderHierarchy()
        {
            return this.folderInfos.RootFolder();
        }
    }
}
