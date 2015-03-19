using System.Collections.Generic;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Lists.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Lists configurations for the navigation module
    /// </summary>
    public class NavigationListInfos
    {
        private readonly PublishingFieldInfos publishingFieldInfos;
        private readonly PublishingCatalogInfos publishingCatalogInfos;
        private readonly PublishingListInfos publishingListInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingFieldInfos">The fields info configuration objects from the publishing module</param>
        /// <param name="publishingCatalogInfos">The catalogs info configuration objects from the publishing module</param>
        /// <param name="publishingListInfos">The lists info configuration objects from the publishing module</param>
        public NavigationListInfos(PublishingFieldInfos publishingFieldInfos, PublishingCatalogInfos publishingCatalogInfos, PublishingListInfos publishingListInfos)
        {
            this.publishingFieldInfos = publishingFieldInfos;
            this.publishingCatalogInfos = publishingCatalogInfos;
            this.publishingListInfos = publishingListInfos;
        }

        /// <summary>
        /// The content pages catalog
        /// </summary>
        public ListInfo ContentPages
        {
            get
            {
                // Content pages editors can create terms directly in the form
                var customizedNavigationField = this.publishingFieldInfos.Navigation();
                customizedNavigationField.CreateValuesInEditForm = true;

                var contentPages = this.publishingCatalogInfos.ContentPages();
                contentPages.FieldDefinitions = new List<BaseFieldInfo>()
                {
                    customizedNavigationField
                };

                return contentPages;
            }
        }

        /// <summary>
        /// The OOTB Pages Library
        /// </summary>
        public ListInfo PagesLibrary
        {
            get
            {
                // Content pages editors can create terms directly in the form
                var customizedNavigationField = this.publishingFieldInfos.Navigation();
                customizedNavigationField.CreateValuesInEditForm = true;

                var pagesLibrary = this.publishingListInfos.PagesLibrary;
                pagesLibrary.FieldDefinitions = new List<BaseFieldInfo>()
                {
                    customizedNavigationField
                };
                
                return pagesLibrary;
            }
        }
    }
}
