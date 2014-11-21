using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationListInfos
    {
        private readonly PublishingFieldInfos publishingFieldInfos;
        private readonly PublishingCatalogInfos publishingCatalogInfos;
        private readonly PublishingListInfos publishingListInfos;

        public NavigationListInfos(PublishingFieldInfos publishingFieldInfos, PublishingCatalogInfos publishingCatalogInfos, PublishingListInfos publishingListInfos)
        {
            this.publishingFieldInfos = publishingFieldInfos;
            this.publishingCatalogInfos = publishingCatalogInfos;
            this.publishingListInfos = publishingListInfos;
        }


        public ListInfo ContentPages
        {
            get
            {
                // Content pages editors can create terms directly in the form
                var customizedNavigationField = this.publishingFieldInfos.Navigation();
                customizedNavigationField.CreateValuesInEditForm = true;

                var contentPages = this.publishingCatalogInfos.ContentPages();
                contentPages.FieldDefinitions = new List<IFieldInfo>()
                {
                    customizedNavigationField
                };

                return contentPages;
            }
        }

        public ListInfo PagesLibrary
        {
            get
            {
                // Content pages editors can create terms directly in the form
                var customizedNavigationField = this.publishingFieldInfos.Navigation();
                customizedNavigationField.CreateValuesInEditForm = true;

                var pagesLibrary = this.publishingListInfos.PagesLibrary;
                pagesLibrary.FieldDefinitions = new List<IFieldInfo>()
                {
                    customizedNavigationField
                };

                return pagesLibrary;
            }
        }



    }
}
