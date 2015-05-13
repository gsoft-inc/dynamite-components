using System.Collections.Generic;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Design.Contracts.Configuration
{
    /// <summary>
    /// Page configurations used in the design module (Home pages)
    /// These configurations will be used in the Folder configuration.
    /// </summary>
    public interface IDesignPageInfoConfig
    {
        /// <summary>
        /// Property that returns all page configurations for the design module.
        /// </summary>
        IList<PageInfo> Pages { get; }

        /// <summary>
        /// Gets the page information by file name from this configuration.
        /// </summary>
        /// <param name="fileName">The file name of the page without the file extension.</param>
        /// <returns>The page information</returns>
        PageInfo GetPageInfoByFileName(string fileName);
    }
}
