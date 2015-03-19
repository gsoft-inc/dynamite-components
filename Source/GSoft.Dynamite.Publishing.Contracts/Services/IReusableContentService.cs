using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Entities;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Services
{
    /// <summary>
    /// The public reusable content service interface
    /// </summary>
    public interface IReusableContentService
    {
        /// <summary>
        /// Method to create a Reusable content by a file
        /// </summary>
        /// <param name="web">The web where to create the reusable content. Usually a root web from a site collection</param>
        /// <param name="name">The name (key) and filename of the Reusable content</param>
        /// <param name="category">The category to put in the list</param>
        /// <param name="folderRelativeToLayouts">The folder of the file relative to the /Layouts folder</param>
        /// <param name="overwrite">Overwrite existing reusable content with same key or ignore adding.</param>
        void CreateReusableContent(SPWeb web, string name, string category, string folderRelativeToLayouts, bool overwrite);

        /// <summary>
        /// Method to get a reusable content by its title/key/name
        /// </summary>
        /// <param name="web">The web where the list lives</param>
        /// <param name="reusableContentTitle">The reusable content SPListItem title</param>
        /// <returns>The Reusable Content Html </returns>
        ReusableHtmlContent GetByTitle(SPWeb web, string reusableContentTitle);

        /// <summary>
        /// Gets the reusable contents.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <returns>A list of reusable content</returns>
        IList<ReusableHtmlContent> GetReusableContents(SPWeb web);
    }
}
