using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Social.Contracts.Configuration
{
    /// <summary>
    /// Interface for configuring discussions through the social module.
    /// </summary>
    public interface ISocialDiscussionsConfig
    {
        /// <summary>
        /// Gets the discussion list information.
        /// </summary>
        /// <value>
        /// The discussion list information.
        /// </value>
        ListInfo DiscussionListInfo { get; }
    }
}
