using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingFolderInfoConfig : IBasePublishingFolderInfoConfig
    {
        private readonly BasePublishingFolderInfos _folderInfos;

        public BasePublishingFolderInfoConfig(BasePublishingFolderInfos folderInfos)
        {
            this._folderInfos = folderInfos;
        }

        public FolderInfo RootFolderHierarchy()
        {
            return this._folderInfos.RootFolder();
        }
    }
}
