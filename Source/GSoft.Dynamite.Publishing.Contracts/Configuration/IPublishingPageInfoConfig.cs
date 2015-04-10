using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Page configurations used in the publishing module. 
    /// These configurations will be used in the Folder configuration.
    /// </summary>
    public interface IPublishingPageInfoConfig
    {
        /// <summary>
        /// Property that returns all page configurations for the publishing module.
        /// </summary>
        IList<PageInfo> Pages { get; }

        /// <summary>
        /// Gets the page information by file name from this configuration.
        /// </summary>
        /// <param name="fileName">The file name of the page without the aspx extention.</param>
        /// <returns>The page information</returns>
        PageInfo GetPageInfoByFileName(string fileName);
    }
}
