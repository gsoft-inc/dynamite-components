using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Caml;
using GSoft.Dynamite.Collections;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Social.Contracts.Configuration;
using GSoft.Dynamite.Social.Core.Entities;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Social.Core.Repositories
{
    /// <summary>
    /// Discussion board repository.
    /// </summary>
    public class DiscussionRepository
    {
        private readonly ISocialDiscussionsConfig config;
        private readonly ICamlBuilder camlBuilder;
        private readonly IListLocator listLocator;
        private readonly ISharePointEntityBinder binder;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionRepository" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="camlBuilder">The CAML builder.</param>
        /// <param name="listLocator">The list locator.</param>
        /// <param name="binder">The binder.</param>
        /// <param name="logger">The logger.</param>
        public DiscussionRepository(
            ISocialDiscussionsConfig config, 
            ICamlBuilder camlBuilder, 
            IListLocator listLocator, 
            ISharePointEntityBinder binder, 
            ILogger logger)
        {
            this.config = config;
            this.camlBuilder = camlBuilder;
            this.listLocator = listLocator;
            this.binder = binder;
            this.logger = logger;
        }

        /// <summary>
        /// Gets all discussions.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <returns>A collection of discussions.</returns>
        public IEnumerable<Discussion> GetAllDiscussions(SPWeb web)
        {
            // Get discussions ordered by modified date
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var discussions = list.Folders.Cast<SPListItem>()
                .Select(
                    item =>
                    {
                        var discussion = this.binder.Get<Discussion>(item);
                        discussion.UserPermissions = this.GetCurrentUserPermissionsOnItem(web, item);
                        discussion.Replies = this.GetReplies(web, item.ID).ToArray();
                        return discussion;
                    })
                .OrderByDescending(x => x.Modified)
                .ToList();

            return discussions;
        }

        /// <summary>
        /// Gets the replies.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="discussionId">The discussion identifier.</param>
        /// <returns>
        /// All replies for a specific discussion.
        /// </returns>
        public IEnumerable<DiscussionReply> GetReplies(SPWeb web, int discussionId)
        {
            // Get folder containing replies for specified discussion
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var folder = list.Folders.Cast<SPListItem>().SingleOrDefault(item => item.ID == discussionId);
            if (folder == null)
            {
                return new DiscussionReply[] { };
            }

            var query = new SPQuery()
            {
                Folder = folder.Folder,
                Query = this.camlBuilder.OrderBy(this.camlBuilder.FieldRef("Created", CamlEnums.SortType.Descending))
            };

            // Get each reply and fill in the user object
            var replies = list.GetItems(query).Cast<SPListItem>().Select(
                item =>
                {
                    var reply = this.binder.Get<DiscussionReply>(item);
                    reply.UserPermissions = this.GetCurrentUserPermissionsOnItem(web, item);
                    reply.AuthorUser = GetUserByFieldValue(reply.Author);
                    return reply;
                });

            return replies;
        }

        /// <summary>
        /// Replies the specified discussion.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="reply">The reply.</param>
        /// <returns>
        /// The discussion reply.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">reply argument.</exception>
        /// <exception cref="System.InvalidOperationException">Failed to validate form digest.</exception>
        /// <exception cref="System.ArgumentException">Reply parent ID.</exception>
        public DiscussionReply Reply(SPWeb web, DiscussionReply reply)
        {
            if (reply == null)
            {
                throw new ArgumentNullException("reply");
            }

            // Validate form digest for security
            if (!SPUtility.ValidateFormDigest())
            {
                this.logger.Error("DiscussionRepository.Reply: Failed to validate form digest for reply on discussion id '{0}'.", reply.ParentFolderId);
                throw new InvalidOperationException("Failed to validate form digest");
            }

            // Get discussion parent folder by ID
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var parentFolder = list.Folders.Cast<SPListItem>().SingleOrDefault(x => x.ID == reply.ParentFolderId);
            if (parentFolder == null)
            {
                this.logger.Error("DiscussionRepository.Reply: The Discussion with the id '{0}' was not found", reply.ParentFolderId);
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, "The Discussion with the Title {0} was not found", reply.ParentFolderId));
            }

            // Create discussion reply and update the body field
            var replyItem = SPUtility.CreateNewDiscussionReply(parentFolder);
            replyItem["Body"] = reply.Body;

            // If mapped to a parent item, set the value
            if (reply.ParentItemId > 0)
            {
                this.logger.Info("DiscussionRepository.Reply: Mapping reply to parent item id '{0}'.", reply.ParentItemId);
                replyItem["ParentItemID"] = reply.ParentItemId;
            }

            replyItem.Update();
            return this.binder.Get<DiscussionReply>(replyItem);
        }

        /// <summary>
        /// Updates the reply.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="reply">The reply.</param>
        /// <returns>
        /// The updated discussion reply.
        /// </returns>
        public DiscussionReply UpdateReply(SPWeb web, DiscussionReply reply)
        {
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var replyItem = list.GetItemById(reply.Id);
            if (replyItem != null)
            {
                replyItem["Body"] = reply.Body;
                replyItem.Update();

                return this.binder.Get<DiscussionReply>(replyItem);
            }

            this.logger.Warn("DiscussionRepository.UpdateReply: Could not find reply with id '{0}'.", reply.Id);
            return null;
        }

        /// <summary>
        /// Deletes the reply.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="reply">The reply.</param>
        public void DeleteReply(SPWeb web, DiscussionReply reply)
        {
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var replyItem = list.GetItemById(reply.Id);
            if (replyItem != null)
            {
                replyItem.Delete();
            }
            else
            {
                this.logger.Warn("DiscussionRepository.DeleteReply: Could not find item with id '{0}'.", reply.Id);
            }
        }

        /// <summary>
        /// Creates a new discussion.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="discussion">The discussion.</param>
        /// <returns>
        /// The newly created discussion
        /// </returns>
        public Discussion Create(SPWeb web, Discussion discussion)
        {
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var item = SPUtility.CreateNewDiscussion(list, discussion.Title);
            this.binder.FromEntity(discussion, item);
            item["Body"] = discussion.Body;
            item.Update();

            var newDiscussion = this.binder.Get<Discussion>(item);
            newDiscussion.ParentListId = item.ParentList.ID.ToString("D");
            return newDiscussion;
        }

        /// <summary>
        /// Gets the discussion by unique identifier.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="id">The unique identifier.</param>
        /// <returns>
        /// The association discussion.
        /// </returns>
        public Discussion GetById(SPWeb web, int id)
        {
            // Get discussion by id
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var item = list.GetItemById(id);
            if (item != null)
            {
                this.logger.Info("DiscussionRepository.GetById: Discussion with id '{0}' found.", id);
                var discussion = this.binder.Get<Discussion>(item);
                discussion.ParentListId = item.ParentList.ID.ToString("D");
                discussion.UserPermissions = this.GetCurrentUserPermissionsOnItem(web, item);
                discussion.Replies = this.GetReplies(web, discussion.Id).ToArray();
                return discussion;
            }

            return new Discussion() { UserPermissions = this.GetCurrentUserPermissionsOnList(web) };
        }

        /// <summary>
        /// Gets the by title.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="title">The title.</param>
        /// <returns>The discussion.</returns>
        public Discussion GetByTitle(SPWeb web, string title)
        {
            // Get discussion by title
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            var caml = this.camlBuilder.Where(
                this.camlBuilder.Equal(
                    this.camlBuilder.FieldRef(BuiltInFields.Title.InternalName), 
                    this.camlBuilder.Value("Text", title)));

            var query = new SPQuery() { Query = caml, ViewAttributes = "Scope='RecursiveAll'", RowLimit = 1 };
            var items = list.GetItems(query);
            if (items.Count == 1)
            {
                this.logger.Info("DiscussionRepository.GetByTitle: Discussion with title '{0}' found.", title);
                var item = items[0];
                var discussion = this.binder.Get<Discussion>(item);
                discussion.ParentListId = item.ParentList.ID.ToString("D");
                discussion.UserPermissions = this.GetCurrentUserPermissionsOnItem(web, item);
                discussion.Replies = this.GetReplies(web, discussion.Id).ToArray();
                return discussion;
            }

            return new Discussion() { UserPermissions = this.GetCurrentUserPermissionsOnList(web) };
        }

        private static DiscussionUser GetUserByFieldValue(string fieldValue)
        {
            var user = new SPFieldUserValue(SPContext.Current.Web, fieldValue).User;
            var serviceContext = SPServiceContext.GetContext(SPContext.Current.Site);
            var userProfileManager = new UserProfileManager(serviceContext);
            var profile = userProfileManager.GetUserProfile(user.LoginName);
            var pictureUrl = profile[PropertyConstants.PictureUrl].Value.ToString();

            return new DiscussionUser()
            {
                Id = user.ID,
                Email = user.Email,
                PictureUrl = pictureUrl,
                DisplayName = user.Name,
                LoginName = user.LoginName
            };
        }
        
        private string[] GetCurrentUserPermissionsOnItem(SPWeb web, SPListItem item)
        {
            var permissions = new List<string>();
            if (item.DoesUserHavePermissions(SPBasePermissions.EditListItems))
            {
                permissions.Add("Edit");

                // If users have permissions to edit all items or
                // if user should only have edit permissions on their own items
                var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
                if ((list.WriteSecurity == 1) || (list.WriteSecurity == 2))
                {
                    var currentUserLogin = SPContext.Current.Web.CurrentUser.LoginName;
                    var authorUserLogin = new SPFieldUserValue(list.ParentWeb, item[SPBuiltInFieldId.Author].ToString()).User.LoginName;
                    if (authorUserLogin.Equals(currentUserLogin, StringComparison.OrdinalIgnoreCase))
                    {
                        permissions.Add("EditAuthor");
                    }
                }
            }

            if (item.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
            {
                permissions.Add("ManageWeb");
            }

            if (item.DoesUserHavePermissions(SPBasePermissions.ManageLists))
            {
                permissions.Add("ManageLists");
            }

            return permissions.ToArray();
        }

        private string[] GetCurrentUserPermissionsOnList(SPWeb web)
        {
            var permissions = new List<string>();
            var list = this.listLocator.GetByUrl(web, this.config.DiscussionListInfo.WebRelativeUrl);
            if (list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
            {
                permissions.Add("Edit");
            }

            if (list.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
            {
                this.logger.Info("DiscussionRepository.GetCurrentUserPermissionsOnItem: Current user has 'ManagedWeb' permissions.");
                permissions.Add("ManageWeb");
            }

            if (list.DoesUserHavePermissions(SPBasePermissions.ManageLists))
            {
                this.logger.Info("DiscussionRepository.GetCurrentUserPermissionsOnItem: Current user has 'ManageLists' permissions.");
                permissions.Add("ManageLists");
            }

            return permissions.ToArray();
        }
    }
}
