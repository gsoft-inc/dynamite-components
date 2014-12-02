using System.Collections.Generic;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Lists settings for the multilingualism module
    /// </summary>
    public class MultilingualismListInfoConfig : IPublishingListInfoConfig
    {
        private readonly PublishingListInfos multilingualismListInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="multilingualismListInfos">The list settings from the multilingualism module</param>
        public MultilingualismListInfoConfig(PublishingListInfos multilingualismListInfos)
        {
            this.multilingualismListInfos = multilingualismListInfos;
        }

        /// <summary>
        /// Property that return all the lists to create or configure in the publishing module
        /// </summary>
        public IList<ListInfo> Lists
        {
            get
            {
                return new List<ListInfo>()
                {
                    this.multilingualismListInfos.PagesLibrary
                };
            }
        }
    }
}
