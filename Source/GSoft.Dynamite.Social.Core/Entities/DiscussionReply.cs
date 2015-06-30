using System.Runtime.Serialization;
using GSoft.Dynamite.Binding;

namespace GSoft.Dynamite.Social.Core.Entities
{
    /// <summary>
    /// Discussion reply object for the web service
    /// </summary>
    [DataContract]
    public class DiscussionReply : Discussion
    {
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [Property(BindingType = BindingType.ReadOnly)]
        [DataMember(Name = "parentFolderId")]
        public int ParentFolderId { get; set; }

        /// <summary>
        /// Gets or sets the parent item identifier.
        /// </summary>
        /// <value>
        /// The parent item identifier.
        /// </value>
        [Property("ParentItemID")]
        [DataMember(Name = "parentItemId")]
        public int ParentItemId { get; set; }

        /// <summary>
        /// Gets or sets the author user.
        /// </summary>
        /// <value>
        /// The author user.
        /// </value>
        [DataMember(Name = "authorUser")]
        public DiscussionUser AuthorUser { get; set; }
    }
}
