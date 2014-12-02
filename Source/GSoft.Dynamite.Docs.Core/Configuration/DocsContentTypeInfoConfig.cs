using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Docs.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the document management module
    /// </summary>
    public class DocsContentTypeInfoConfig : IDocsContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos basePublishingContentTypeInfos;
        private readonly DocsFieldInfos docsFieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfos">The content types settings from the publishing module</param>
        /// <param name="docsFieldInfos">The fields settings from the document management module</param>
        public DocsContentTypeInfoConfig(PublishingContentTypeInfos publishingContentTypeInfos, DocsFieldInfos docsFieldInfos)
        {
            this.basePublishingContentTypeInfos = publishingContentTypeInfos;
            this.docsFieldInfos = docsFieldInfos;
        }

        /// <summary>
        /// Property that return all the content types to create or configure in the document management module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var baseDocsContentTypes = new List<ContentTypeInfo>();

                // Get the translatable item
                var defaultItem = this.basePublishingContentTypeInfos.DefaultItem();

                // Adding the ContentAssociationKey field
                defaultItem.Fields.Add(this.docsFieldInfos.InternalId());

                baseDocsContentTypes.Add(defaultItem);

                return baseDocsContentTypes;
            }
        }
    }
}
