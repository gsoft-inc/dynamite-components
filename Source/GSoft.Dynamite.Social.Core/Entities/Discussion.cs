using System;
using System.Runtime.Serialization;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.ValueTypes;

namespace GSoft.Dynamite.Social.Core.Entities
{
    /// <summary>
    /// Discussion object for the web service
    /// </summary>
    [DataContract]
    public class Discussion : BaseEntity
    {
        /// <summary>
        /// Gets or sets the association identifier.
        /// </summary>
        /// <value>
        /// The association identifier.
        /// </value>
        [DataMember(Name = "associationId")]
        [Property("AgropurPageAssociationKey")]
        public string AssociationId { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        [DataMember(Name = "modified")]
        [Property("DiscussionLastUpdated", BindingType = BindingType.ReadOnly)]
        public new DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [DataMember(Name = "author")]
        [Property]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [DataMember(Name = "body")]
        [Property]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the reply count.
        /// </summary>
        /// <value>
        /// The reply count.
        /// </value>
        [DataMember(Name = "replyCount")]
        [Property("ItemChildCount", BindingType = BindingType.ReadOnly)]
        public string ReplyCount { get; set; }

        /// <summary>
        /// Gets or sets the replies.
        /// </summary>
        /// <value>
        /// The replies.
        /// </value>
        [DataMember(Name = "replies")]
        public DiscussionReply[] Replies { get; set; }

        /// <summary>
        /// Gets or sets the user permissions.
        /// </summary>
        /// <value>
        /// The user permissions.
        /// </value>
        [DataMember(Name = "userPermissions")]
        public string[] UserPermissions { get; set; }

        /// <summary>
        /// Gets or sets the likes count.
        /// </summary>
        /// <value>
        /// The likes count.
        /// </value>
        [Property]
        [DataMember(Name = "likesCount")]
        public double LikesCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is liked by current user].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is liked by current user]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isLiked")]
        public bool IsLiked { get; set; }

        /// <summary>
        /// Gets or sets the users who like the item.
        /// </summary>
        /// <value>
        /// The users who like the item.
        /// </value>
        public UserValue[] LikedBy { get; set; }

        /// <summary>
        /// Gets or sets the parent list identifier.
        /// </summary>
        /// <value>
        /// The parent list identifier.
        /// </value>
        [DataMember(Name = "parentListId")]
        public string ParentListId { get; set; }
    }
}
