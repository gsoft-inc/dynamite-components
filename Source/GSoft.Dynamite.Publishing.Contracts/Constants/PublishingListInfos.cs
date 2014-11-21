using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingListInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        public PublishingListInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        public ListInfo PagesLibrary
        {
            get
            {
                return new ListInfo("Pages", null, null)
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        this.publishingContentTypeInfos.DefaultPage()
                    },
                };
            }
        }
    }
}
