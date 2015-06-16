using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Entities;
using GSoft.Dynamite.Repositories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Repositories
{
    /// <summary>
    /// The public reusable content repository interface
    /// </summary>
    [Obsolete]
    public interface IReusableContentRepository : IRepository<ReusableHtmlContent>
    {
        /// <summary>
        /// Fetches a reusable content item by its title
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="reusableContentTitle">The title of the item</param>
        /// <returns>The reusable content entity</returns>
        ReusableHtmlContent GetByTitle(SPWeb web, string reusableContentTitle);

        /// <summary>
        /// Fetches all available reusable contents
        /// </summary>
        /// <param name="web">The current web</param>
        /// <returns>All reusable content entities</returns>
        IList<ReusableHtmlContent> GetAll(SPWeb web);
    }
}
