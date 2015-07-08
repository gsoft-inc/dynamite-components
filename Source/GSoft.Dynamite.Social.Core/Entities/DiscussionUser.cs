using GSoft.Dynamite.ValueTypes;

namespace GSoft.Dynamite.Social.Core.Entities
{
    /// <summary>
    /// User value used in a discussion or discussion reply.
    /// </summary>
    public class DiscussionUser : UserValue
    {
        /// <summary>
        /// Gets or sets the picture URL.
        /// </summary>
        /// <value>
        /// The picture URL.
        /// </value>
        public string PictureUrl { get; set; }
    }
}
