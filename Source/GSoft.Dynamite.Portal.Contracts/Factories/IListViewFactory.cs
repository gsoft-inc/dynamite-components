using GSoft.Dynamite.Catalogs;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Factories
{
    /// <summary>
    /// Interface for ListView Factory
    /// </summary>
    public interface IListViewFactory
    {
        /// <summary>
        /// Create the default view for content catalog
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="catalog">The content catalog</param>
        void CreateContentCatalogView(SPWeb web, Catalog catalog);

        /// <summary>
        /// Create the default view for news catalog
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="catalog">The news catalog</param>
        void CreateNewsCatalogView(SPWeb web, Catalog catalog);

        /// <summary>
        /// Create the collection of filed to add in the default view
        /// </summary>
        /// <param name="web">the current web</param>
        /// <param name="catalog">the current catalog</param>
        void CreateNodeDescriptionCatalogView(SPWeb web, Catalog catalog);
    }
}
