using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class BaseNavigationContentTypeInfoConfig: IBasePublishingContentTypeInfoConfig
    {
        private readonly IBasePublishingContentTypeInfoConfig basePublishingContentTypeInfoConfig;
        private readonly BasePublishingContentTypeInfos basePublishingContentTypeInfos;
        private readonly BaseNavigationFieldInfos basenavigationFieldInfos;

        public BaseNavigationContentTypeInfoConfig(
            IBasePublishingContentTypeInfoConfig basePublishingContentTypeInfoConfig,
            BasePublishingContentTypeInfos basePublishingContentTypeInfos,
            BaseNavigationFieldInfos baseMultilingualismFieldInfos)
        {
            this.basePublishingContentTypeInfoConfig = basePublishingContentTypeInfoConfig;
            this.basePublishingContentTypeInfos = basePublishingContentTypeInfos;
            this.basenavigationFieldInfos = baseMultilingualismFieldInfos;
        }

        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                // Getting the base content types
                var baseContentTypes = this.basePublishingContentTypeInfoConfig.ContentTypes;

                // Getting the Translatable Item (to add fields)
                var catalogItemFieldInfo = baseContentTypes.Single(contentType => contentType.ContentTypeId == this.basePublishingContentTypeInfos.CatalogContentItem().ContentTypeId);
                
                // Adding the Date Slug Field field
                catalogItemFieldInfo.Fields.Add(this.basenavigationFieldInfos.DateSlug());

                // Adding the Title Slug Field field
                catalogItemFieldInfo.Fields.Add(this.basenavigationFieldInfos.TitleSlug());

                return baseContentTypes;
            }
        }
    }
}
