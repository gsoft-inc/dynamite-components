using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Content types settings for the multilingualism module. Override the configuration from the publishing module.
    /// </summary>
    public class MultilingualismContentTypeInfoConfig : IMultilingualismContentTypeInfoConfig
    {
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig;
        private readonly IMultilingualismFieldInfoConfig multilingualismFieldInfoConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfoConfig">The content type definitions from the publishing module</param>
        /// <param name="multilingualismFieldInfoConfig">The field definitions from the publishing module</param>
        public MultilingualismContentTypeInfoConfig(
            IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig,
            IMultilingualismFieldInfoConfig multilingualismFieldInfoConfig)
        {
            this.publishingContentTypeInfoConfig = publishingContentTypeInfoConfig;
            this.multilingualismFieldInfoConfig = multilingualismFieldInfoConfig;
        }
        
        /// <summary>
        /// Property that return all the content types to create or configure in the multilingualism module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var baseMultilingualContentTypes = new List<ContentTypeInfo>();

                // Get the translatable item
                var translatableItem = this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.TranslatableItem.ContentTypeId);

                // Get the translatable item
                var translatablePage = this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.TranslatablePage.ContentTypeId);

                // Adding the ContentAssociationKey field
                translatableItem.Fields.Add(this.multilingualismFieldInfoConfig.GetFieldById(MultilingualismFieldInfos.ContentAssociationKey.Id));
                translatablePage.Fields.Add(this.multilingualismFieldInfoConfig.GetFieldById(MultilingualismFieldInfos.ContentAssociationKey.Id));

                // Adding the Item Language field
                translatableItem.Fields.Add(this.multilingualismFieldInfoConfig.GetFieldById(MultilingualismFieldInfos.ItemLanguage.Id));
                translatablePage.Fields.Add(this.multilingualismFieldInfoConfig.GetFieldById(MultilingualismFieldInfos.ItemLanguage.Id));

                baseMultilingualContentTypes.Add(translatableItem);
                baseMultilingualContentTypes.Add(translatablePage);

                return baseMultilingualContentTypes;
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
