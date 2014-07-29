using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Factories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Core.Factories
{
    /// <summary>
    /// List View Factory
    /// </summary>
    public class ListViewFactory : IListViewFactory
    {
        private readonly ListHelper listHelper;
        private readonly ILogger logger;

        /// <summary>
        /// Create a list view factory
        /// </summary>
        /// <param name="listHelper">The List Helper</param>
        /// <param name="logger">The Logger</param>
        public ListViewFactory(ListHelper listHelper, ILogger logger)
        {
            this.listHelper = listHelper;
            this.logger = logger;
        }

        /// <summary>
        /// Create the collection of filed to add in the default view
        /// </summary>
        /// <param name="web">the current web</param>
        /// <param name="catalog">the current catalog</param>
        public void CreateContentCatalogView(SPWeb web, Catalog catalog)
        {
            ICollection<FieldInfo> fields = new Collection<FieldInfo>()
            {
                new FieldInfo(string.Empty, SPBuiltInFieldId.ContentType),
                PortalFields.Navigation,
                PortalFields.IsNavigationMenuItem,
                new FieldInfo(string.Empty, SPBuiltInFieldId.Created),
                new FieldInfo(string.Empty, SPBuiltInFieldId.Modified)
            };

            // Add field collection in the default view
            this.listHelper.AddFieldsToDefaultView(web, catalog, fields);
        }

        /// <summary>
        /// Create the collection of filed to add in the default view
        /// </summary>
        /// <param name="web">the current web</param>
        /// <param name="catalog">the current catalog</param>
        public void CreateNewsCatalogView(SPWeb web, Catalog catalog)
        {
            ICollection<FieldInfo> fields = new Collection<FieldInfo>()
            {
                PortalFields.Navigation,
                PortalFields.IsNavigationMenuItem,
                PortalFields.ArticleStartDate,
                new FieldInfo(string.Empty, SPBuiltInFieldId.Created),
                new FieldInfo(string.Empty, SPBuiltInFieldId.Modified)
            };

            // Add field collection in the default view
            this.listHelper.AddFieldsToDefaultView(web, catalog, fields);
        }

        /// <summary>
        /// Create the collection of filed to add in the default view
        /// </summary>
        /// <param name="web">the current web</param>
        /// <param name="catalog">the current catalog</param>
        public void CreateNodeDescriptionCatalogView(SPWeb web, Catalog catalog)
        {
            ICollection<FieldInfo> fields = new Collection<FieldInfo>()
            {
                PortalFields.Navigation,
                PortalFields.PublishingPageContent
            };

            // Add field collection in the default view
            this.listHelper.AddFieldsToDefaultView(web, catalog, fields);
        }
    }
}
