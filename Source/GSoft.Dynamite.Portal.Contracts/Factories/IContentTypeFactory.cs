using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Factories
{
    /// <summary>
    /// Interface for the Content Type Factory
    /// </summary>
    public interface IContentTypeFactory
    {
        #region Items
        /// <summary>
        /// Creates the browsed Item Content Type
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        void CreateBrowsableItem(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the Translatable Item Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        void CreateTranslatableItem(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the Schedulable Item Content Type
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        void CreateSchedulableItem(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the Navigation Item Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        void CreateMenuManageableContentItem(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the Content Item Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        void CreateContentItem(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the News Item Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        void CreateNewsItem(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the Node Description Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection</param>
        void CreateNodeDescriptionItem(SPContentTypeCollection contentTypeCollection);
        #endregion Items

        #region Pages
        /// <summary>
        /// Creates the Translatable Page Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        void CreateTranslatablePage(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the content page Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        void CreateContentPage(SPContentTypeCollection contentTypeCollection);

        /// <summary>
        /// Creates the news page Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        void CreateNewsPage(SPContentTypeCollection contentTypeCollection);
        #endregion Pages
    }
}
