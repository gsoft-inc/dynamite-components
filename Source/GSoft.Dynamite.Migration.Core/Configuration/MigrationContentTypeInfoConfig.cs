using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using GSoft.Dynamite.Migration.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Migration.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the migration module
    /// </summary>
    public class MigrationContentTypeInfoConfig : IMigrationContentTypeInfoConfig
    {
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig;
        private readonly IMigrationFieldInfoConfig migrationFieldInfoConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationContentTypeInfoConfig"/> class.
        /// </summary>
        /// <param name="publishingContentTypeInfoConfig">The publishing content type information configuration.</param>
        /// <param name="migrationFieldInfoConfig">The migration field information configuration.</param>
        public MigrationContentTypeInfoConfig(IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig, IMigrationFieldInfoConfig migrationFieldInfoConfig)
        {
            this.publishingContentTypeInfoConfig = publishingContentTypeInfoConfig;
            this.migrationFieldInfoConfig = migrationFieldInfoConfig;
        }

        /// <summary>
        /// Property that return all the content types to create or configure in the migration module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var contentTypes = new List<ContentTypeInfo>();

                // Get the translatable item
                var defaultItem = this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.DefaultItem.ContentTypeId);

                // Adding the ContentAssociationKey field
                defaultItem.Fields.Add(this.migrationFieldInfoConfig.GetFieldById(MigrationFieldInfos.InternalId.Id));

                contentTypes.Add(defaultItem);

                return contentTypes;
            }
        }

        /// <summary>
        /// Gets the content type from the ContentTypes property where the id of that content type is passed by parameter.
        /// </summary>
        /// <param name="contentTypeId">The unique identifier of the content type we are looking for.</param>
        /// <returns>
        /// The content type information.
        /// </returns>
        public ContentTypeInfo GetContentTypeById(SPContentTypeId contentTypeId)
        {
            return this.ContentTypes.Single(c => c.ContentTypeId.Equals(contentTypeId));
        }
    }
}
