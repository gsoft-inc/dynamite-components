using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Content types settings for the multilingualism module. Override the configuration from the publishing module.
    /// </summary>
    public class MultilingualismContentTypeInfoConfig : IMultilingualismContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos basePublishingContentTypeInfos;
        private readonly MultilingualismFieldInfos baseMultilingualismFieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="basePublishingContentTypeInfos">The content type definitions from the publishing module</param>
        /// <param name="baseMultilingualismFieldInfos">The field definitions from the publishing module</param>
        public MultilingualismContentTypeInfoConfig(
            PublishingContentTypeInfos basePublishingContentTypeInfos,
            MultilingualismFieldInfos baseMultilingualismFieldInfos)
        {
            this.basePublishingContentTypeInfos = basePublishingContentTypeInfos;
            this.baseMultilingualismFieldInfos = baseMultilingualismFieldInfos;
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
                var translatableItem = this.basePublishingContentTypeInfos.TranslatableItem();

                // Get the translatable item
                var translatablePage = this.basePublishingContentTypeInfos.TranslatablePage();

                // Adding the ContentAssociationKey field
                translatableItem.Fields.Add(this.baseMultilingualismFieldInfos.ContentAssociationKey());
                translatablePage.Fields.Add(this.baseMultilingualismFieldInfos.ContentAssociationKey());

                // Adding the Item Language field
                translatableItem.Fields.Add(this.baseMultilingualismFieldInfos.ItemLanguage());
                translatablePage.Fields.Add(this.baseMultilingualismFieldInfos.ItemLanguage());

                baseMultilingualContentTypes.Add(translatableItem);
                baseMultilingualContentTypes.Add(translatablePage);

                return baseMultilingualContentTypes;
            }
        }
    }
}
