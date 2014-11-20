using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingListInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;
        private readonly PublishingFieldInfos publishingFieldInfos;

        public PublishingListInfos(PublishingContentTypeInfos publishingContentTypeInfos, PublishingFieldInfos publishingFieldInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
            this.publishingFieldInfos = publishingFieldInfos;
        }

        public ListInfo PagesLibrary
        {
            get
            {
                // Content pages editors can create terms directly in the form
                var customizedNavigationField = this.publishingFieldInfos.Navigation();
                customizedNavigationField.CreateValuesInEditForm = true;

                return new ListInfo("Pages", null, null)
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        this.publishingContentTypeInfos.DefaultPage()
                    },
                    FieldDefinitions = new List<IFieldInfo>()
                    {
                        customizedNavigationField
                    }
                };
            }
        }
    }
}
