using System.Collections.Generic;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration interface for the metadata navigation settings (Tree View panel based on list or library fields)
    /// </summary>
    public interface IPublishingMetadataNavigationSettingsConfig
    {
        /// <summary>
        /// Property that return all the metadata types navigation settings to create in the publishing module
        /// </summary>
        IList<MetadataNavigationSettingsInfo> MetadataNavigationSettings { get; }

        /// <summary>
        /// Gets the metadata navigation settings information by list information from this configuration.
        /// </summary>
        /// <param name="list">The list information.</param>
        /// <returns>The Managed navigation settings</returns>
        MetadataNavigationSettingsInfo GetMetadataNavigationSettingsInfoByListInfo(ListInfo list);
    }
}
