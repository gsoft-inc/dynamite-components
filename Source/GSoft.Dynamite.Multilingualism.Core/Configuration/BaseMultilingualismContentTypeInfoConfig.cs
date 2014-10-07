using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class BaseMultilingualismContentTypeInfoConfig : IBasePublishingContentTypeInfoConfig
    {
        private IBasePublishingContentTypeInfoConfig basePublishingContentTypeInfoConfig;
        private BasePublishingContentTypeInfos basePublishingContentTypeInfos;
        private BaseMultilingualismFieldInfos baseMultilingualismFieldInfos;

        public BaseMultilingualismContentTypeInfoConfig(
            IBasePublishingContentTypeInfoConfig basePublishingContentTypeInfoConfig,
            BasePublishingContentTypeInfos basePublishingContentTypeInfos,
            BaseMultilingualismFieldInfos baseMultilingualismFieldInfos)
        {
            this.basePublishingContentTypeInfoConfig = basePublishingContentTypeInfoConfig;
            this.basePublishingContentTypeInfos = basePublishingContentTypeInfos;
            this.baseMultilingualismFieldInfos = baseMultilingualismFieldInfos;
        }

       public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                // Getting the base content types
                var baseContentTypes = this.basePublishingContentTypeInfoConfig.ContentTypes;

                // Getting the Translatable Item (to add fields)
                var translatableItemFieldInfo = baseContentTypes.Single(contentType => contentType.ContentTypeId == this.basePublishingContentTypeInfos.TranslatableItem().ContentTypeId);
                
                // Adding the ContentAssociationKey field
                translatableItemFieldInfo.Fields.Add(this.baseMultilingualismFieldInfos.ContentAssociationKey());

                return baseContentTypes;
            }
        }

    }
}
