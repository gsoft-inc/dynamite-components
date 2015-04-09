using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using GSoft.Dynamite.Migration.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Migration.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the migration module
    /// </summary>
    public class MigrationContentTypeInfoConfig : IMigrationContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;
        private readonly MigrationFieldInfos migrationFieldInfos;

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationContentTypeInfoConfig"/> class.
        /// </summary>
        /// <param name="publishingContentTypeInfos">The publishing content type information.</param>
        /// <param name="migrationFieldInfos">The migration field information.</param>
        public MigrationContentTypeInfoConfig(
            PublishingContentTypeInfos publishingContentTypeInfos, 
            MigrationFieldInfos migrationFieldInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
            this.migrationFieldInfos = migrationFieldInfos;
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
                var defaultItem = this.publishingContentTypeInfos.DefaultItem();

                // Adding the ContentAssociationKey field
                defaultItem.Fields.Add(this.migrationFieldInfos.InternalId());

                contentTypes.Add(defaultItem);

                return contentTypes;
            }
        }
    }
}
