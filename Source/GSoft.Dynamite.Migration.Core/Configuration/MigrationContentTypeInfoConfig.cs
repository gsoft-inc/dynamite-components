using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using GSoft.Dynamite.Migration.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Migration.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the document management module
    /// </summary>
    public class MigrationContentTypeInfoConfig : IMigrationContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos basePublishingContentTypeInfos;
        private readonly MigrationFieldInfos fieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfos">The content types settings from the publishing module</param>
        /// <param name="fieldInfos">The fields settings from the migration module</param>
        public MigrationContentTypeInfoConfig(PublishingContentTypeInfos publishingContentTypeInfos, MigrationFieldInfos fieldInfos)
        {
            this.basePublishingContentTypeInfos = publishingContentTypeInfos;
            this.fieldInfos = fieldInfos;
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
                defaultItem.Fields.Add(this.fieldInfos.InternalId());

                baseDocsContentTypes.Add(defaultItem);

                return baseDocsContentTypes;
            }
        }
    }
}
