using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the navigation module
    /// </summary>
    public class NavigationContentTypeInfoConfig : INavigationContentTypeInfoConfig
    {
        private readonly PublishingContentTypeInfos _basePublishingContentTypeInfos;
        private readonly NavigationFieldInfos _basenavigationFieldInfos;
        private readonly PublishingFieldInfos basePublishingFieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="basePublishingContentTypeInfos">The content type info objects configuration</param>
        /// <param name="baseMultilingualismFieldInfos">The fields info objects configuration</param>
        /// <param name="basePublishingFieldInfos">The base publishing field information.</param>
        public NavigationContentTypeInfoConfig(
            PublishingContentTypeInfos basePublishingContentTypeInfos,
            NavigationFieldInfos baseMultilingualismFieldInfos,
            PublishingFieldInfos basePublishingFieldInfos)
        {
            this._basePublishingContentTypeInfos = basePublishingContentTypeInfos;
            this._basenavigationFieldInfos = baseMultilingualismFieldInfos;
            this.basePublishingFieldInfos = basePublishingFieldInfos;
        }

        /// <summary>
        /// Property that return all the content types to create or configure in the navigation module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {
                var baseContentTypes = new List<ContentTypeInfo>();

                // Get the Browsable Item & Page
                var browsableItem = this._basePublishingContentTypeInfos.BrowsableItem();
                var browsablePage = this._basePublishingContentTypeInfos.BrowsablePage();
                
                // Adding the Date Slug field
                browsableItem.Fields.Add(this._basenavigationFieldInfos.DateSlug());
                browsablePage.Fields.Add(this._basenavigationFieldInfos.DateSlug());

                // Adding the Title Slug field
                browsableItem.Fields.Add(this._basenavigationFieldInfos.TitleSlug());
                browsablePage.Fields.Add(this._basenavigationFieldInfos.TitleSlug());

                // Adds the field Occurrence Link Location in the content type
                browsableItem.Fields.Add(this._basenavigationFieldInfos.OccurrenceLinkLocation());
                browsablePage.Fields.Add(this._basenavigationFieldInfos.OccurrenceLinkLocation());

                // Gets the Catalog Item & Page
                var catalogItem = this._basePublishingContentTypeInfos.CatalogContentItem();
                var catalogPage = this._basePublishingContentTypeInfos.CatalogContentPage();

                // Adding the Publishing Start Date field
                catalogItem.Fields.Add(this.basePublishingFieldInfos.PublishingStartDate());

                baseContentTypes.Add(browsableItem);
                baseContentTypes.Add(browsablePage);
                baseContentTypes.Add(catalogItem);
                baseContentTypes.Add(catalogPage);

                return baseContentTypes;
            }
        }
    }
}
