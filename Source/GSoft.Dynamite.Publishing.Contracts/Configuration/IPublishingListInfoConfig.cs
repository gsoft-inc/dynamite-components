using System;
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

        /// <summary>
        /// Gets the list information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web-relative URL of the list</param>
        /// <returns>The list information</returns>
        ListInfo GetListInfoByWebRelativeUrl(string webRelativeUrl);

        /// <summary>
        /// Gets the list information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web-relative URL of the list</param>
        /// <returns>The list information</returns>
        ListInfo GetListInfoByWebRelativeUrl(Uri webRelativeUrl);
    }
}
