using System.Collections.Generic;
using GSoft.Dynamite.Folders;

namespace GSoft.Dynamite.Design.Contracts.Configuration
{
    /// <summary>
    /// Configuration of the root folder hierarchies for a list or a library.
    /// Use a folder that encapsulates all items definitions instead of creating items or pages individually
    /// </summary>
    public interface IDesignFolderInfoConfig
    {
        /// <summary>
        /// Property that return all the folder hierarchies to create in the design module
        /// </summary>
        IList<FolderInfo> RootFolderHierarchies { get; }
    }
}
