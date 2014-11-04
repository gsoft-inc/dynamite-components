using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingListInfoConfig
    {
        /// <summary>
        /// Property that return all the lists to create
        /// </summary>
        IList<ListInfo> Lists { get; }
    }
}
