using System;
using System.Collections.Generic;
using GSoft.Dynamite.UserProfile;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.Contracts.Configuration
{
    /// <summary>
    /// Targeting configuration interface for user profile.
    /// </summary>
    public interface ITargetingProfileConfig
    {
        /// <summary>
        /// Gets the name of the timer job.
        /// </summary>
        /// <value>
        /// The name of the timer job.
        /// </value>
        string TimerJobName { get; }

        /// <summary>
        /// Gets the timer job schedule.
        /// </summary>
        /// <value>
        /// The timer job schedule.
        /// </value>
        SPSchedule TimerJobSchedule { get; }

        /// <summary>
        /// Gets the user profile change timespan.
        /// </summary>
        /// <value>
        /// The user profile change timespan.
        /// </value>
        DateTime UserProfileChangeTimespan { get; }

        /// <summary>
        /// Gets the user profile properties.
        /// </summary>
        /// <value>
        /// The user profile properties.
        /// </value>
        IList<UserProfilePropertyInfo> UserProfileProperties { get; }

        /// <summary>
        /// Gets the user profile property synchronization mappings (internal names).
        /// </summary>
        /// <value>
        /// The user profile property synchronization mappings.
        /// </value>
        IDictionary<string, string> UserProfilePropertySyncMappings { get; }

        /// <summary>
        /// Gets the user profile property information by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The use profile information.</returns>
        UserProfilePropertyInfo GetUserProfilePropertyInfoByName(string name);
    }
}