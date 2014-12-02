using System.Collections.Generic;
using GSoft.Dynamite.Folders;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration of the root folder hierarchies for a list or a library.
    /// Use a folder that encapsulates all items definitions instead of creating items or pages individually
    /// </summary>
    public interface IPublishingFolderInfoConfig
    {
        /// <summary>
        /// Property that return all the folder hierarchies to create in the publishing module
        /// </summary>
        IList<FolderInfo> RootFolderHierarchies { get; }
    }
}
