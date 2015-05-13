using GSoft.Dynamite.Folders;

namespace GSoft.Dynamite.Design.Contracts.Constants
{
    /// <summary>
    /// Folders definitions for the design module. Be careful, pages are always created through a folder, never individually.
    /// </summary>
    public static class DesignFolderInfos
    {
        /// <summary>
        /// The French folder
        /// </summary>
        /// <returns>A Root FolderInfo for the french language</returns>
        public static FolderInfo RootFolderFr
        {
            get
            {
                return new FolderInfo()
                {
                    Name = "RootFolderFr",
                };
            }
        }

        /// <summary>
        /// The English folder
        /// </summary>
        /// <returns>A Root FolderInfo for the english language</returns>
        public static FolderInfo RootFolderEn
        {
            get
            {
                return new FolderInfo()
                {
                    Name = "RootFolderEn",                  
                };
            }
        }
    }
}
