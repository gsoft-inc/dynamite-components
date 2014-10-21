using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class MultilingualismContentTypeInfoConfig : IMultilingualismContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos basePublishingContentTypeInfos;
        private readonly MultilingualismFieldInfos baseMultilingualismFieldInfos;

        public MultilingualismContentTypeInfoConfig(
            PublishingContentTypeInfos basePublishingContentTypeInfos,
            MultilingualismFieldInfos baseMultilingualismFieldInfos)
        {
            this.basePublishingContentTypeInfos = basePublishingContentTypeInfos;
            this.baseMultilingualismFieldInfos = baseMultilingualismFieldInfos;
        }

       public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var baseNavigationContentTypes = new List<ContentTypeInfo>();

                // Get the translatable item
                var translatableItem = basePublishingContentTypeInfos.TranslatableItem();

                // Adding the ContentAssociationKey field
                translatableItem.Fields.Add(this.baseMultilingualismFieldInfos.ContentAssociationKey());

                // Adding the Item Language field
                translatableItem.Fields.Add(this.baseMultilingualismFieldInfos.ItemLanguage());

                baseNavigationContentTypes.Add(translatableItem);

                return baseNavigationContentTypes;
            }
        }

    }
}
