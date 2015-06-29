using System;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Lists.Constants;
using GSoft.Dynamite.Social.Contracts.Configuration;
using GSoft.Dynamite.Social.Contracts.Constants;

namespace GSoft.Dynamite.Social.Core.Configuration
{
    /// <summary>
    /// Base implementation for configuring discussions through the social module.
    /// </summary>
    public class SocialDiscussionsConfig : ISocialDiscussionsConfig
    {
        /// <summary>
        /// Gets the discussion list information.
        /// </summary>
        /// <value>
        /// The discussion list information.
        /// </value>
        public ListInfo DiscussionListInfo
        {
            get
            {
                return new ListInfo(
                    new Uri(SocialListUrls.DiscussionsListUrl, UriKind.Relative), 
                    SocialResources.DiscussionsListTitle, 
                    SocialResources.DiscussionsListDescription)
                    {
                        ListTemplateInfo = BuiltInListTemplates.DiscussionsList
                    };
            }
        }
    }
}
