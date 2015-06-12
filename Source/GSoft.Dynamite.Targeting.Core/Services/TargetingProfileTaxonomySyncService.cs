using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Targeting.Contracts.Services;
using GSoft.Dynamite.Taxonomy;
using GSoft.Dynamite.UserProfile;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Targeting.Core.Services
{
    /// <summary>
    /// Service for tasks related to content targeting for a user based on his profile.
    /// </summary>
    public class TargetingProfileTaxonomySyncService : ITargetingProfileTaxonomySyncService
    {
        private const string MonitoredScopePrefix = "GSoft.Dynamite.Targeting.Core.Services.UserProfileTargetingService";

        private readonly ITaxonomyService taxonomyService;
        private readonly IUserProfileHelper userProfileHelper;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetingProfileTaxonomySyncService" /> class.
        /// </summary>
        /// <param name="taxonomyService">The taxonomy service.</param>
        /// <param name="userProfileHelper">The user profile helper.</param>
        /// <param name="logger">The logger.</param>
        public TargetingProfileTaxonomySyncService(
            ITaxonomyService taxonomyService, 
            IUserProfileHelper userProfileHelper,
            ILogger logger)
        {
            this.taxonomyService = taxonomyService;
            this.userProfileHelper = userProfileHelper;
            this.logger = logger;
        }

        /// <summary>
        /// Synchronizes the taxonomy fields from specified mappings
        /// The source property will build the destination property taxonomy tree.
        /// </summary>
        /// <param name="site">The site for the service context.</param>
        /// <param name="user">The user for which to sync the profile properties.</param>
        /// <param name="mappings">The taxonomy property mappings.  The key is the source property name. The value is the destination property name.</param>
        public void SyncTaxonomyFieldsForUser(SPSite site, SPUser user, IDictionary<string, string> mappings)
        {
            using (new SPMonitoredScope(string.Format(CultureInfo.InvariantCulture, "{0}::{1}", MonitoredScopePrefix, "SyncTaxonomyFieldsForUser")))
            {
                // Get user profile objects
                var context = SPServiceContext.GetContext(site);
                var userProfileManager = new UserProfileManager(context);
                var profileSubtypeProperties = this.userProfileHelper.GetProfileSubtypePropertyManager(site);
                var userProfile = userProfileManager.GetUserProfile(user.LoginName);

                // For each property, update mapping
                foreach (var mapping in mappings)
                {
                    var targetPropertyName = mapping.Value;
                    var targetSubtypeProp = profileSubtypeProperties.GetPropertyByName(targetPropertyName);
                    this.SyncTaxonomyFields(site, userProfile, mapping, targetSubtypeProp.CoreProperty.TermSet.Id, user.ParentWeb);
                }
            }
        }

        /// <summary>
        /// Synchronizes the taxonomy fields from specified mappings for changed user profile in the last specified window of time.
        /// The source property will build the destination property taxonomy tree.
        /// </summary>
        /// <param name="site">The site for the service context.</param>
        /// <param name="changeStartDate">The start date for which to include user changes.</param>
        /// <param name="mappings">The taxonomy property mappings.  The key is the source property name. The value is the destination property name.</param>
        public void SyncTaxonomyFieldsForChangedUsers(SPSite site, DateTime changeStartDate, IDictionary<string, string> mappings)
        {
            using (new SPMonitoredScope(string.Format(CultureInfo.InvariantCulture, "{0}::{1}", MonitoredScopePrefix, "SyncTaxonomyFieldsForChangedUsers")))
            {
                // Get user profile objects
                var context = SPServiceContext.GetContext(site);
                var userProfileManager = new UserProfileManager(context);
                var profileSubtypeManager = ProfileSubtypeManager.Get(context);
                var profileSubtype =
                    profileSubtypeManager.GetProfileSubtype(
                        ProfileSubtypeManager.GetDefaultProfileName(ProfileType.User));
                var profileSubtypeProperties = profileSubtype.Properties;

                // For each property, update mapping
                foreach (var mapping in mappings)
                {
                    var sourcePropertyName = mapping.Key;
                    var targetPropertyName = mapping.Value;

                    var srcSubtypeProp = profileSubtypeProperties.GetPropertyByName(sourcePropertyName);
                    var targetSubtypeProp = profileSubtypeProperties.GetPropertyByName(targetPropertyName);

                    if (srcSubtypeProp != null && targetSubtypeProp != null)
                    {
                        if (targetSubtypeProp.CoreProperty.TermSet != null
                            && srcSubtypeProp.CoreProperty.TermSet != null)
                        {
                            if (targetSubtypeProp.CoreProperty.IsMultivalued == true)
                            {
                                // Get some subset of changes to a user profile since last 24h hours
                                var startDate = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1));
                                var changeQuery = new UserProfileChangeQuery(false, true);
                                var changeToken = new UserProfileChangeToken(startDate);
                                changeQuery.ChangeTokenStart = changeToken;
                                changeQuery.SingleValueProperty = true;
                                changeQuery.MultiValueProperty = true;
                                changeQuery.Update = true;
                                changeQuery.Add = false;
                                changeQuery.Delete = false;
                                changeQuery.UpdateMetadata = true;

                                var changes = userProfileManager.GetChanges(changeQuery);
                                foreach (
                                    var profile in
                                        changes.OfType<UserProfilePropertyValueChange>()
                                            .Select(change => (UserProfile)change.ChangedProfile))
                                {
                                    this.SyncTaxonomyFields(
                                        site,
                                        profile,
                                        mapping,
                                        targetSubtypeProp.CoreProperty.TermSet.Id);
                                }
                            }
                            else
                            {
                                this.logger.Error(
                                    string.Format(
                                        CultureInfo.InvariantCulture,
                                        @"UserProfileTargetingService.SyncTaxonomyFieldsForChangedUsers: The target property {0} is not set as multi valued. Please set this target property as multi valued",
                                        targetPropertyName));
                            }
                        }
                        else
                        {
                            this.logger.Error(
                                @"UserProfileTargetingService.SyncTaxonomyFieldsForChangedUsers: 
                            Some properties have wrong TermSet configuration. Please review user properties taxonomy settings.");
                        }
                    }
                    else
                    {
                        this.logger.Error(
                            @"UserProfileTargetingService.SyncTaxonomyFieldsForChangedUsers: 
                        One or more user properties specified in the configuration list doesn't exists in the user profile property schema!");
                    }
                }
            }
        }

        private void SyncTaxonomyFields(
            SPSite site,
            Microsoft.Office.Server.UserProfiles.UserProfile userProfile,
            KeyValuePair<string, string> mapping,
            Guid termSetId)
        {
            Action<Microsoft.Office.Server.UserProfiles.UserProfile> commitAction = (x) => x.Commit();
            this.SyncTaxonomyFields(site, userProfile, mapping, termSetId, commitAction);
        }

        private void SyncTaxonomyFields(
            SPSite site,
            Microsoft.Office.Server.UserProfiles.UserProfile userProfile,
            KeyValuePair<string, string> mapping,
            Guid termSetId,
            SPWeb updateWeb)
        {
            Action<Microsoft.Office.Server.UserProfiles.UserProfile> commitAction = (updatedUserProfile) =>
            {
                updateWeb.AllowUnsafeUpdates = true;
                updatedUserProfile.Commit();
                updateWeb.AllowUnsafeUpdates = false;
            };

            this.SyncTaxonomyFields(site, userProfile, mapping, termSetId, commitAction);
        }

        private void SyncTaxonomyFields(
            SPSite site,
            Microsoft.Office.Server.UserProfiles.UserProfile userProfile,
            KeyValuePair<string, string> mapping,
            Guid termSetId,
            Action<Microsoft.Office.Server.UserProfiles.UserProfile> commitAction)
        {
            var srcPropertyValue = userProfile[mapping.Key];
            var targetPropertyValue = userProfile[mapping.Value];
            var originalValue = srcPropertyValue.GetTaxonomyTerms();
            if (originalValue.Any())
            {
                // Clear property value
                targetPropertyValue.Clear();

                // Get all terms and update the property with the values
                var branchTerms = this.taxonomyService.GetTermPathFromRootToTerm(site, termSetId, originalValue[0].Id, false);
                branchTerms.ToList().ForEach(term => targetPropertyValue.AddTaxonomyTerm(term));
            }
            else
            {
                this.logger.Warn(
                    "UserProfileTargetingService.SyncTaxonomyFields: No values found for source property '{0}' for user '{1}",
                    mapping.Key,
                    userProfile.AccountName);
            }

            // Update the user profile
            commitAction.Invoke(userProfile);
        }
    }
}
