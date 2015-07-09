using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Autofac;
using GSoft.Dynamite.Social.Core.Entities;
using GSoft.Dynamite.Social.Core.Repositories;
using Microsoft.SharePoint;

// ReSharper disable once CheckNamespace
namespace GSoft.Dynamite.Social.SP
{
    /// <summary>
    /// Menu administration web service.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DiscussionService : IDiscussionService
    {
        // IMPORTANT
        // When a web application is configured to use claims authentication (Windows claims, form-based authentication claims, or SAML claims), 
        // the IIS website is always configured to have anonymous access turned on. Your custom SOAP and WCF endpoints may receive requests 
        // from anonymous users. If you have code in your WCF service that calls the RunWithElevatedPrivileges method to access information 
        // without first checking whether the call is from an authorized user or an anonymous user, you risk returning protected SharePoint 
        // data to any anonymous user for some of your functions that use that approach.

        /// <summary>
        /// Method to get all the discussion board by URL.
        /// </summary>
        /// <returns>
        /// A list of discussions.
        /// </returns>
        public IEnumerable<Discussion> GetAllDiscussions()
        {
            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            return repository.GetAllDiscussions(SPContext.Current.Web).ToList();
        }

        /// <summary>
        /// Method to get all Reply to a discussion
        /// </summary>
        /// <param name="discussionFolderId">The discussion folder identifier.</param>
        /// <returns>
        /// A list of discussion replies.
        /// </returns>
        public IEnumerable<DiscussionReply> GetAllReplies(string discussionFolderId)
        {
            int discussionId;
            if (!int.TryParse(discussionFolderId, out discussionId))
            {
                // TODO: Add logging or handler error
                return new List<DiscussionReply>();
            }

            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            return repository.GetReplies(SPContext.Current.Web, discussionId).ToList();
        }

        /// <summary>
        /// Method that creates a new comment on a discussion.
        /// </summary>
        /// <param name="reply">The reply to create.</param>
        /// <returns>
        /// The newly created reply comment
        /// </returns>
        public DiscussionReply Reply(DiscussionReply reply)
        {
            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            return repository.Reply(SPContext.Current.Web, reply);
        }

        /// <summary>
        /// Method that updates a reply on a discussion.
        /// </summary>
        /// <param name="reply">The updated reply.</param>
        /// <returns>
        /// The updated reply object.
        /// </returns>
        public DiscussionReply UpdateReply(DiscussionReply reply)
        {
            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            return repository.UpdateReply(SPContext.Current.Web, reply);
        }

        /// <summary>
        /// Deletes the reply.
        /// </summary>
        /// <param name="reply">The reply.</param>
        public void DeleteReply(DiscussionReply reply)
        {
            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            repository.DeleteReply(SPContext.Current.Web, reply);
        }

        /// <summary>
        /// Method to get a single discussion by its Id
        /// </summary>
        /// <param name="idString">The discussion id.</param>
        /// <returns>
        /// A single discussion
        /// </returns>
        public Discussion GetDiscussionById(string idString)
        {
            var id = int.Parse(idString);
            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            return repository.GetById(SPContext.Current.Web, id);
        }

        /// <summary>
        /// Gets the discussion by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>
        /// A discussion object.
        /// </returns>
        public Discussion GetDiscussionByTitle(string title)
        {
            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            return repository.GetByTitle(SPContext.Current.Web, title);
        }

        /// <summary>
        /// Method that creates a new discussion.
        /// </summary>
        /// <param name="discussion">The discussion.</param>
        /// <returns>
        /// The newly created discussion
        /// </returns>
        public Discussion CreateDiscussion(Discussion discussion)
        {
            var repository = SocialContainerProxy.Current.Resolve<DiscussionRepository>();
            return repository.Create(SPContext.Current.Web, discussion);
        }
    }
}
