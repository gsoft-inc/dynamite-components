using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the creation or configuration of the Lists
    /// </summary>
    public class PublishingListInfoConfig : IPublishingListInfoConfig
    {
        private readonly IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingContentTypeInfoConfig">The publishing content type information configuration.</param>
        public PublishingListInfoConfig(IPublishingContentTypeInfoConfig publishingContentTypeInfoConfig)
        {
            this.publishingContentTypeInfoConfig = publishingContentTypeInfoConfig;
        }

        /// <summary>
        /// Property that return all the lists to create or configure in the publishing module
        /// </summary>
        /// <returns>The lists</returns>
        public IList<ListInfo> Lists
        {
            get
            {
                var pagesLibrary = PublishingListInfos.PagesLibrary;
                pagesLibrary.ContentTypes = new List<ContentTypeInfo>()
                {
                    this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.DefaultPage.ContentTypeId),
                    this.publishingContentTypeInfoConfig.GetContentTypeById(PublishingContentTypeInfos.DefaultArticlePage.ContentTypeId)
                };

                return new List<ListInfo>()
                {
                    pagesLibrary
                };
            }
        }

        /// <summary>
        /// Gets the list information by web relative URL.
        /// </summary>
        /// <param name="webRelativeUrl">The web-relative URL of the list</param>
        /// <returns>
        /// The list information
        /// </returns>
        public ListInfo GetListInfoByWebRelativeUrl(string webRelativeUrl)
        {
            return this.GetListInfoByWebRelativeUrl(new Uri(webRelativeUrl, UriKind.Relative));
        }

        /// <summary>
        /// Gets the list information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web-relative URL of the list</param>
        /// <returns>
        /// The list information
        /// </returns>
        public ListInfo GetListInfoByWebRelativeUrl(Uri webRelativeUrl)
        {
            return this.Lists.Single(list => list.WebRelativeUrl.Equals(webRelativeUrl));
        }
    }
}
