using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Docs.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    public class DocsContentTypeInfoConfig : IDocsContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos basePublishingContentTypeInfos;
        private readonly DocsFieldInfos docsFieldInfos;

        public DocsContentTypeInfoConfig(PublishingContentTypeInfos publishingContentTypeInfos, DocsFieldInfos docsFieldInfos)
        {
            this.basePublishingContentTypeInfos = publishingContentTypeInfos;
            this.docsFieldInfos = docsFieldInfos;
        }


        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var baseDocsContentTypes = new List<ContentTypeInfo>();

                // Get the translatable item
                var defaultItem = basePublishingContentTypeInfos.DefaultItem();

                // Adding the ContentAssociationKey field
                defaultItem.Fields.Add(this.docsFieldInfos.InternalId());

                baseDocsContentTypes.Add(defaultItem);

                return baseDocsContentTypes;
            }
        }
    }
}
