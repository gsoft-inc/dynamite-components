using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingListInfos
    {
        private readonly PublishingContentTypeInfos publishingFieldInfos;

        public PublishingListInfos(PublishingContentTypeInfos publishingFieldInfos)
        {
            this.publishingFieldInfos = publishingFieldInfos;
        }

        public ListInfo PagesLibrary
        {
            get
            {
                return new ListInfo("Pages", null, null)
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        this.publishingFieldInfos.DefaultPage()
                    }
                };
            }
        }
    }
}
