using System.Collections.Generic;
using GSoft.Dynamite.Folders;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Folders definitions for the publishing module. Be careful, pages are always created through a folder, never individually.
    /// </summary>
    public static class PublishingFolderInfos
    {
        /// <summary>
        /// Folder that contains items page instances
        /// </summary>
        /// <returns>The folder info</returns>
        public static FolderInfo ItemPageTemplates
        {
            get
            {
                return new FolderInfo()
                {
                    Name = "ItemPageTemplates",
                };
            }
        }

        /// <summary>
        /// Folder that contains category page instance
        /// </summary>
        /// <returns>The folder info</returns>
        public static FolderInfo CategoryPageTemplates
        {
            get
            {
                return new FolderInfo()
                {
                    Name = "CategoryPageTemplates",
                };
            }
        }
    }
}
