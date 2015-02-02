using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Lists.Constants;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// List definitions for the publishing module
    /// </summary>
    public class PublishingListInfos
    {
        private readonly PublishingContentTypeInfos publishingContentTypeInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfos">The content type info objects configuration</param>
        public PublishingListInfos(PublishingContentTypeInfos publishingContentTypeInfos)
        {
            this.publishingContentTypeInfos = publishingContentTypeInfos;
        }

        /// <summary>
        /// The OOTB Pages Library list
        /// </summary>
        public ListInfo PagesLibrary
        {
            get
            {
                return new ListInfo("Pages", null, null)
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        this.publishingContentTypeInfos.DefaultPage(),
                        this.publishingContentTypeInfos.DefaultArticlePage()
                    },
                    ListTemplateInfo = BuiltInListTemplates.Pages
                };
            }
        }
    }
}
