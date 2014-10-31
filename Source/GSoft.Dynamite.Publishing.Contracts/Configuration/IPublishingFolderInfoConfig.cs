using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Folders;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingFolderInfoConfig
    {
       IList<FolderInfo> RootFolderHierarchies();
    }
}
