using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration for the creation or configuration of the Lists
    /// </summary>
    public interface IPublishingListInfoConfig
    {
        /// <summary>
        /// Property that return all the lists to create or configure in the publishing module
        /// </summary>
        IList<ListInfo> Lists { get; }
    }
}
