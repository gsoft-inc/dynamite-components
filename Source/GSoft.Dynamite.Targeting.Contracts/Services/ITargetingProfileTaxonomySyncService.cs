using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.Contracts.Services
{
    /// <summary>
    /// Service interface for tasks related to content targeting for a user based on his profile.
    /// </summary>
    public interface ITargetingProfileTaxonomySyncService
    {
        /// <summary>
        /// Synchronizes the taxonomy fields from specified mappings for specific user.
        /// The source property will build the destination property taxonomy tree.
        /// </summary>
        /// <param name="site">The site for the service context.</param>
        /// <param name="user">The user for which to sync the profile properties.</param>
        /// <param name="mappings">The taxonomy property mappings.  The key is the source property name. The value is the destination property name.</param>
        void SyncTaxonomyFieldsForUser(SPSite site, SPUser user, IDictionary<string, string> mappings);

        /// <summary>
        /// Synchronizes the taxonomy fields from specified mappings for changed user profile in the last specified window of time.
        /// The source property will build the destination property taxonomy tree.
        /// </summary>
        /// <param name="site">The site for the service context.</param>
        /// <param name="changeStartDate">The start date for which to include user changes.</param>
        /// <param name="mappings">The taxonomy property mappings.  The key is the source property name. The value is the destination property name.</param>
        void SyncTaxonomyFieldsForChangedUsers(SPSite site, DateTime changeStartDate, IDictionary<string, string> mappings);

        /// <summary>
        /// Synchronizes the taxonomy fields from specified mappings for users with empty target fields.
        /// The source property will build the destination property taxonomy tree.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <param name="mappings">The mappings.</param>
        void SyncTaxonomyFieldsForEmptyTargetFields(SPSite site, IDictionary<string, string> mappings);
    }
}