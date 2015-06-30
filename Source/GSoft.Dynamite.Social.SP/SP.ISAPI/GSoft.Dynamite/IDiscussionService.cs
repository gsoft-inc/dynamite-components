using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using GSoft.Dynamite.Social.Core.Entities;

// ReSharper disable once CheckNamespace
namespace GSoft.Dynamite.Social.SP
{
    /// <summary>
    /// The interface of a discussion board web service
    /// </summary>
    [ServiceContract(Namespace = "http:www.gsoft.com", Name = "DiscussionService")]
    public interface IDiscussionService
    {
        /// <summary>
        ///  Method to get all the discussion board by url
        /// </summary>
        /// <returns>A list of discussion</returns>
        [OperationContract, WebGet(UriTemplate = "/Discussions", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Discussion> GetAllDiscussions();

        /// <summary>
        /// Method to get a single discussion by its Id
        /// </summary>
        /// <param name="id">The discussion id.</param>
        /// <returns>
        /// A single discussion
        /// </returns>
        [OperationContract, WebGet(UriTemplate = "/Discussions/ById?id={id}", ResponseFormat = WebMessageFormat.Json)]
        Discussion GetDiscussionById(string id);

        /// <summary>
        /// Gets the discussion by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>A discussion object.</returns>
        [OperationContract, WebGet(UriTemplate = "/Discussions/ByTitle?title={title}", ResponseFormat = WebMessageFormat.Json)]
        Discussion GetDiscussionByTitle(string title);

        /// <summary>
        /// Method to get all Reply to a discussion
        /// </summary>
        /// <param name="discussionFolderId">The discussion folder identifier.</param>
        /// <returns>A list of discussion replies.</returns>
        [OperationContract, WebGet(UriTemplate = "/Replies?discussion={discussionFolderId}", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<DiscussionReply> GetAllReplies(string discussionFolderId);

        /// <summary>
        /// Method that creates a new discussion.
        /// </summary>
        /// <param name="discussion">The discussion.</param>
        /// <returns>The newly created discussion</returns>
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "/CreateDiscussion", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Discussion CreateDiscussion(Discussion discussion);

        /// <summary>
        /// Method that creates a new comment on a discussion.
        /// </summary>
        /// <param name="reply">The reply to create.</param>
        /// <returns>The newly created reply comment</returns>
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "/Reply", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DiscussionReply Reply(DiscussionReply reply);

        /// <summary>
        /// Method that updates a reply on a discussion.
        /// </summary>
        /// <param name="reply">The updated reply.</param>
        /// <returns>The updated reply object.</returns>
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "/UpdateReply", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DiscussionReply UpdateReply(DiscussionReply reply);

        /// <summary>
        /// Deletes the reply.
        /// </summary>
        /// <param name="reply">The reply.</param>
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "/DeleteReply", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void DeleteReply(DiscussionReply reply);
    }
}