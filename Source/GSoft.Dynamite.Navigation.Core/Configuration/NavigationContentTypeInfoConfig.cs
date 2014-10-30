using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationContentTypeInfoConfig : INavigationContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos _basePublishingContentTypeInfos;
        private readonly NavigationFieldInfos _basenavigationFieldInfos;

        public NavigationContentTypeInfoConfig(
            PublishingContentTypeInfos basePublishingContentTypeInfos,
            NavigationFieldInfos baseMultilingualismFieldInfos)
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
                var catalogItem = this._basePublishingContentTypeInfos.BrowsableItem();
                
                // Adding the Date Slug field
                catalogItem.Fields.Add(this._basenavigationFieldInfos.DateSlug());

                // Adding the Title Slug field
                catalogItem.Fields.Add(this._basenavigationFieldInfos.TitleSlug());

                // Adding the Publishing Start Date field
                catalogItem.Fields.Add(this._basenavigationFieldInfos.PublishingStartDate());

                // Gets the Browsable Item
                var browsableItem = this._basePublishingContentTypeInfos.BrowsableItem();

                // Adds the field Occurrence Link Location in the content type
                browsableItem.Fields.Add(this._basenavigationFieldInfos.OccurrenceLinkLocation());

                baseContentTypes.Add(catalogItem);
                baseContentTypes.Add(browsableItem);

                return baseContentTypes;
            }
        }
    }
}
