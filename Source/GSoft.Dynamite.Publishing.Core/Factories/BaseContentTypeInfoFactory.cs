using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Factories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Core.Factories
{
    public class BaseContentTypeInfoFactory: IBaseContentTypeInfoFactory
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
        public BaseContentTypeInfoFactory(ContentTypeBuilder contentTypeHelper, ILogger logger, IResourceLocator resourceLocator)
        {
            this.contentTypeBuilder = contentTypeHelper;
            this.logger = logger;
            this.resourceLocator = resourceLocator;
        }

        public void CreateContentType(SPContentTypeCollection contentTypeCollection, ContentTypeInfo contentType)
        {
            // Ensure the create of the content type
            var ct = this.contentTypeBuilder.EnsureContentType(
                contentTypeCollection,
                contentType.ContentTypeId,
                this.resourceLocator.Find(contentType.TitleResourceKey));

            // Update the content type's group and description values
            ct.Group = this.resourceLocator.Find(contentType.ContentGroupResourceKey);
            ct.Description = this.resourceLocator.Find(contentType.DescriptionResourceKey);

            // Ensure the correct fields are added to the content type
            this.contentTypeBuilder.EnsureFieldInContentType(ct, contentType.Fields);

            // Update with changes and update inheritance
            ct.Update(true);

            this.logger.Info("TODO");
        }
    }
}
