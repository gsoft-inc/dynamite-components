using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using GSoft.Dynamite.Targeting.Contracts.Constants;
using GSoft.Dynamite.UserProfile;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.Core.Configuration
{
    /// <summary>
    /// Targeting configuration for user profile.
    /// </summary>
    public class TargetingProfileConfig : ITargetingProfileConfig
    {
        /// <summary>
        /// Gets the name of the timer job.
        /// </summary>
        /// <value>
        /// The name of the timer job.
        /// </value>
        public string TimerJobName
        {
            get
            {
                return TargetingConstants.TargetingTimerJobName;
            }
        }

        /// <summary>
        /// Gets the timer job schedule.
        /// </summary>
        /// <value>
        /// The timer job schedule.
        /// </value>
        public SPSchedule TimerJobSchedule
        {
            get
            {
                return new SPDailySchedule { BeginMinute = 0, EndMinute = 10, BeginHour = 2, EndHour = 2 };
            }
        }

        /// <summary>
        /// Gets the user profile change timespan.
        /// </summary>
        /// <value>
        /// The user profile change timespan.
        /// </value>
        public DateTime UserProfileChangeTimespan
        {
            get
            {
                // By default, include all users changed in the last 24 hours
                return DateTime.UtcNow.Subtract(TimeSpan.FromDays(1));
            }
        }

        /// <summary>
        /// Gets the user profile properties.
        /// </summary>
        /// <value>
        /// The user profile properties.
        /// </value>
        public IList<UserProfilePropertyInfo> UserProfileProperties 
        {
            get
            {
                return new List<UserProfilePropertyInfo>();
            }
        }

        /// <summary>
        /// Gets the user profile property synchronization mappings (internal names).
        /// </summary>
        /// <value>
        /// The user profile property synchronization mappings.
        /// </value>
        public IDictionary<string, string> UserProfilePropertySyncMappings
        {
            get
            {
                return new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Gets the user profile property information by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The use profile information.
        /// </returns>
        public UserProfilePropertyInfo GetUserProfilePropertyInfoByName(string name)
        {
            return this.UserProfileProperties.Single(property => property.Name.Equals(name, StringComparison.Ordinal));
        }
    }
}
