using System.Collections.Generic;
using GSoft.Dynamite.Folders;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration of the root folder hierarchies for a list or a library.
    /// Use a folder that encapsulates all items definitions instead of creating items or pages individually
    /// </summary>
    public class PublishingFolderInfoConfig : IPublishingFolderInfoConfig
    {
        private readonly PublishingFolderInfos folderInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="folderInfos">The folder info objects configuration</param>
        public PublishingFolderInfoConfig(PublishingFolderInfos folderInfos)
        {
            this.folderInfos = folderInfos;
        }

        /// <summary>
        /// Property that return all the folder hierarchies to create in the publishing module
        /// </summary>
        public IList<FolderInfo> RootFolderHierarchies
        {
            get
            {
                return new List<FolderInfo>()
                {
                    this.folderInfos.ItemPageTemplates(),
                    this.folderInfos.CategoryPageTemplates()
                };
            }
        }
    }
}
