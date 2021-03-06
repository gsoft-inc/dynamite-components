﻿using System;
using System.Runtime.Serialization;
using GSoft.Dynamite.Binding;

namespace GSoft.Dynamite.Social.Core.Entities
{
    /// <summary>
    /// Discussion object for the web service
    /// </summary>
    [DataContract]
    public class Discussion
    {
        /// <summary>
        /// Item identifier within its list
        /// </summary>
        [DataMember(Name = "id")]
        [Property("ID", BindingType = BindingType.ReadOnly)]
        public int Id { get; set; }

        /// <summary>
        /// Item title
        /// </summary>
        [DataMember(Name = "title")]
        [Property]
        public string Title { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        [DataMember(Name = "created")]
        [Property(BindingType = BindingType.ReadOnly)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the parent list identifier.
        /// </summary>
        /// <value>
        /// The parent list identifier.
        /// </value>
        [DataMember(Name = "parentListId")]
        public string ParentListId { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        [DataMember(Name = "modified")]
        [Property("DiscussionLastUpdated", BindingType = BindingType.ReadOnly)]
        public DateTime Modified { get; set; }

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
    }
}
