using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingFolderInfoConfig : IBasePublishingFolderInfoConfig
    {
        private readonly BasePublishingFolderInfos folderInfos;

        public BasePublishingFolderInfoConfig(BasePublishingFolderInfos folderInfos)
        {
            this.folderInfos = folderInfos;
        }

        public FolderInfo RootFolderHierarchy()
        {
            return this.folderInfos.RootFolder();
        }
    }
}
