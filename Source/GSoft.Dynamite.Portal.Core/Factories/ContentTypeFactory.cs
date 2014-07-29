using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Factories;
using GSoft.Dynamite.Utils;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Core.Factories
{
    /// <summary>
    /// Utility class that ensures the content type creation.
    /// </summary>
    public class ContentTypeFactory : IContentTypeFactory
    {
        /// <summary>
        /// Injection dependencies
        /// </summary>
        private readonly ContentTypeBuilder contentTypeBuilder;
        private readonly ILogger logger;
        private readonly IResourceLocator resourceLocator;

        /// <summary>
        /// Constructor for the ContentTypes class
        /// </summary>
        /// <param name="contentTypeHelper">A ContentTypeHelper object.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="resourceLocator">The resource locator</param>
        public ContentTypeFactory(ContentTypeBuilder contentTypeHelper, ILogger logger, IResourceLocator resourceLocator)
        {
            this.contentTypeBuilder = contentTypeHelper;
            this.logger = logger;
            this.resourceLocator = resourceLocator;
        }

        /// <summary>
        /// Creates the Item that can be browsed Content Type
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        public void CreateBrowsableItem(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the create of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.BrowsableItemContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeBrowsableItemName));

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeBrowsableItemDescription);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.BrowsableItemFields);

            // Update with changes and update inheritance
            contentType.Update(true);
        }

        /// <summary>
        /// Method to create the translatable item
        /// </summary>
        /// <param name="contentTypeCollection">The collection of content type</param>
        public void CreateTranslatableItem(SPContentTypeCollection contentTypeCollection)
        {
            this.logger.Info("Creating translatable item content type '{0}'", PortalContentTypes.TranslatableItemContentTypeId);

            // Ensure the create of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.TranslatableItemContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeTranslatableItemName));

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeTranslatableItemDescription);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.TranslatableItemFields);

            //// Add event receiver association for item added
            this.contentTypeBuilder.AddEventReceiverDefinition(
                contentType,
                SPEventReceiverType.ItemAdded,
                "GSoft.Dynamite.Portal.SP.Authoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=1e3bb3fbc94d83df",
                "GSoft.Dynamite.Portal.SP.Authoring.Events.TranslatableItemEventReceiver");

            //// Add event receiver association for item updated
            this.contentTypeBuilder.AddEventReceiverDefinition(
                contentType,
                SPEventReceiverType.ItemUpdated,
                "GSoft.Dynamite.Portal.SP.Authoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=1e3bb3fbc94d83df",
                "GSoft.Dynamite.Portal.SP.Authoring.Events.TranslatableItemEventReceiver");

            // Update with changes and update inheritance
            contentType.Update(true);
        }

        /// <summary>
        /// Method to create schedulable item
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection</param>
        public void CreateSchedulableItem(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the create of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.SchedulableItemContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeSchedulableItemName));

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeSchedulableItemDescription);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.SchedulableItemFields);

            // Update with changes and update inheritance
            contentType.Update(true);
        }

        /// <summary>
        /// Creates the Navigation Content Item Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        public void CreateMenuManageableContentItem(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the create of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.FeaturedItemContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeFeaturedItemName));

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeFeaturedItemDescription);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.FeaturedItemFields);

            // Update with changes and update inheritance
            contentType.Update(true);
        }

        /// <summary>
        /// Creates the Portal Content Item Content Type
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        public void CreateContentItem(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the creation of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                 contentTypeCollection,
                 PortalContentTypes.ContentItemContentTypeId,
                 this.resourceLocator.Find(PortalResources.ContentTypeContentItemName));

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.ContentItemFields);

            // Order the fields in the content type
            this.contentTypeBuilder.ReorderFieldsInContentType(contentType, PortalFieldCollections.OrderedContentItemFields);

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeContentItemDescription);

            contentType.Update(true);
        }

        /// <summary>
        /// Creates the News Item Content Type
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        public void CreateNewsItem(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the creation of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                 contentTypeCollection,
                 PortalContentTypes.NewsItemContentTypeId,
                 this.resourceLocator.Find(PortalResources.ContentTypeNewsItemName));

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.NewsItemFields);

            // Order the fields in the content type
            this.contentTypeBuilder.ReorderFieldsInContentType(contentType, PortalFieldCollections.OrderedNewsItemFields);

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeNewsItemDescription);

            contentType.Update(true);
        }

        /// <summary>
        /// Creates the Node Description Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection</param>
        public void CreateNodeDescriptionItem(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the creation of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.NodeDescriptionItemContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeNodeDescriptionItemName));

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.NodeDescriptionFields);

            // Order the fields in the content type
            this.contentTypeBuilder.ReorderFieldsInContentType(contentType, PortalFieldCollections.OrderedNodeDescriptionItemFields);

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeNodeDescriptionItemDescription);

            contentType.Update(true);
        }

        /// <summary>
        /// Creates the Translatable Page Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content types collection.</param>
        public void CreateTranslatablePage(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the creation of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.TranslatablePageContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeTranslatablePageName));

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeTranslatablePageDescripion);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.TranslatablePageFields);

            contentType.Update(true);
        }

        #region Pages Content Types
        /// <summary>
        /// Creates the content page Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        public void CreateContentPage(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the creation of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.ContentPageContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeContentPageName));

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeContentPageDescription);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.ContentPageFields);

            contentType.Update(true);
        }

        /// <summary>
        /// Creates the news page Content Type.
        /// </summary>
        /// <param name="contentTypeCollection">The content type collection.</param>
        public void CreateNewsPage(SPContentTypeCollection contentTypeCollection)
        {
            // Ensure the creation of the content type
            var contentType = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                PortalContentTypes.NewsPageContentTypeId,
                this.resourceLocator.Find(PortalResources.ContentTypeNewsPageName));

            // Update the content type's group and description values
            contentType.Group = this.resourceLocator.Find(PortalResources.ContentTypeGroup);
            contentType.Description = this.resourceLocator.Find(PortalResources.ContentTypeNewsPageDescription);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(contentType, PortalFieldCollections.NewsPageFields);

            contentType.Update(true);
        }
        #endregion
    }
}
