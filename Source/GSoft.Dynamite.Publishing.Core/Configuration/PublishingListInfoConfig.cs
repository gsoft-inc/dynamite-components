using System.Collections.Generic;
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
        private readonly PublishingListInfos publishingListInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="publishingListInfos">The list info objects configuration</param>
        public PublishingListInfoConfig(PublishingListInfos publishingListInfos)
        {
            this.publishingListInfos = publishingListInfos;
        }

        /// <summary>
        /// Property that return all the lists to create or configure in the publishing module
        /// </summary>
        /// <returns>The lists</returns>
        public IList<ListInfo> Lists
        {
            get
            {
                return new List<ListInfo>()
                {
                    this.publishingListInfos.PagesLibrary
                };
            }
        }
    }
}
