using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Content types configuration for the navigation module
    /// </summary>
    public class NavigationContentTypeInfoConfig : INavigationContentTypeInfoConfig
    {
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeConfig;
        private readonly INavigationFieldInfoConfig navigationFieldConfig;
        private readonly IPublishingFieldInfoConfig publishingFieldConfig;

        public NavigationContentTypeInfoConfig(
            IPublishingContentTypeInfoConfig publishingContentTypeConfig,
            INavigationFieldInfoConfig navigationFieldConfig,
            IPublishingFieldInfoConfig publishingFieldConfig)
        {
            this.publishingContentTypeConfig = publishingContentTypeConfig;
            this.navigationFieldConfig = navigationFieldConfig;
            this.publishingFieldConfig = publishingFieldConfig;
        }

        /// <summary>
        /// Property that return all the content types to create or configure in the navigation module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get
            {

                // Get the Browsable Item & Page
                var browsableItem = this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.BrowsableItem.ContentTypeId);
                var browsablePage = this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.BrowsablePage.ContentTypeId);
                
                // Adding the Date Slug field
                browsableItem.Fields.Add(this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.DateSlug.Id));
                browsablePage.Fields.Add(this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.DateSlug.Id));

                // Adding the Title Slug field
                browsableItem.Fields.Add(this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.TitleSlug.Id));
                browsablePage.Fields.Add(this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.TitleSlug.Id));

                // Adds the field Occurrence Link Location in the content type
                browsableItem.Fields.Add(this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.OccurrenceLinkLocation.Id));
                browsablePage.Fields.Add(this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.OccurrenceLinkLocation.Id));

                // Gets the Catalog Item & Page
                var catalogItem = this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.CatalogContentItem.ContentTypeId);
                var catalogPage = this.publishingContentTypeConfig.GetContentTypeById(PublishingContentTypeInfos.CatalogContentPage.ContentTypeId);

                // Adding the Publishing Start Date field
                catalogItem.Fields.Add(this.publishingFieldConfig.GetFieldById(PublishingFieldInfos.PublishingStartDate.Id));

                // Return the content types.
                return new List<ContentTypeInfo>()
                {
                    browsableItem,
                    browsablePage,
                    catalogItem,
                    catalogPage
                };
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
