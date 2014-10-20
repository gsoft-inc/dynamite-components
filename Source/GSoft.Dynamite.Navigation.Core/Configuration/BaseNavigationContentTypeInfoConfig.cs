using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class BaseNavigationContentTypeInfoConfig : IBaseNavigationContentTypeInfoConfig
    {
        private readonly BasePublishingContentTypeInfos _basePublishingContentTypeInfos;
        private readonly BaseNavigationFieldInfos _basenavigationFieldInfos;

        public BaseNavigationContentTypeInfoConfig(
            BasePublishingContentTypeInfos basePublishingContentTypeInfos,
            BaseNavigationFieldInfos baseMultilingualismFieldInfos)
        {
            this._basePublishingContentTypeInfos = basePublishingContentTypeInfos;
            this._basenavigationFieldInfos = baseMultilingualismFieldInfos;
        }

        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var baseContentTypes = new List<ContentTypeInfo>();
                
                // Get the catalog item
                var catalogItem = this._basePublishingContentTypeInfos.CatalogContentItem();
                
                // Adding the Date Slug Field field
                catalogItem.Fields.Add(this._basenavigationFieldInfos.DateSlug());

                // Adding the Title Slug Field field
                catalogItem.Fields.Add(this._basenavigationFieldInfos.TitleSlug());

                baseContentTypes.Add(catalogItem);

                return baseContentTypes;
            }
        }
    }
}
