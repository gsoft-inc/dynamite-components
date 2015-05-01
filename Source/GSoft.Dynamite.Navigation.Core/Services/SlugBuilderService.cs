using System;
using System.Globalization;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    /// <summary>
    /// The service for the URL slugs generation
    /// </summary>
    public class SlugBuilderService : ISlugBuilderService
    {
        private readonly ILogger logger;
        private readonly INavigationHelper navigationHelper;
        private readonly INavigationFieldInfoConfig navigationFieldConfig;
        private readonly IPublishingFieldInfoConfig publishingFieldConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlugBuilderService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="navigationHelper">The navigation helper.</param>
        /// <param name="navigationFieldConfig">The navigation field configuration.</param>
        /// <param name="publishingFieldConfig">The publishing field configuration.</param>
        public SlugBuilderService(
            ILogger logger, 
            INavigationHelper navigationHelper, 
            INavigationFieldInfoConfig navigationFieldConfig,
            IPublishingFieldInfoConfig publishingFieldConfig)
        {
            this.logger = logger;
            this.navigationHelper = navigationHelper;
            this.navigationFieldConfig = navigationFieldConfig;
            this.publishingFieldConfig = publishingFieldConfig;
        }

        /// <summary>
        /// Sets the friendly URL slug.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SetFriendlyUrlSlug(SPListItem item)
        {
            var itemDateFieldName = this.publishingFieldConfig.GetFieldById(PublishingFieldInfos.PublishingStartDate.Id).InternalName;
            var dateSlugFieldName = this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.DateSlug.Id).InternalName;
            var titleSlugFieldName = this.navigationFieldConfig.GetFieldById(NavigationFieldInfos.TitleSlug.Id).InternalName;

            // Generate title slug
            if (item.Fields.ContainsField(titleSlugFieldName))
            {
                item[titleSlugFieldName] = this.navigationHelper.GenerateFriendlyUrlSlug(item.Title);
                this.logger.Info(
                    "ContentAssociation.SetFriendlyUrlSlug: Set title slug '{0}' on item '{1}' in web '{2}'.",
                    item[titleSlugFieldName],
                    item.Title,
                    item.Web.Url);
            }

            // Generate date slug
            if (item.Fields.ContainsField(dateSlugFieldName) && item.Fields.ContainsField(itemDateFieldName))
            {
                item[dateSlugFieldName] = GetFriendlyUrlDate(item, itemDateFieldName);
                this.logger.Info(
                    "ContentAssociation.SetFriendlyUrlSlug: Set date slug '{0}' on item '{1}' in web '{2}'.",
                    item[dateSlugFieldName],
                    item.Title,
                    item.Web.Url);
            }

            item.SystemUpdate();
        }

        private static string GetFriendlyUrlDate(SPListItem item, string fieldName)
        {
            var dateFieldValue = item[fieldName];
            var date = (DateTime)dateFieldValue;
            var publishingWeb = PublishingWeb.GetPublishingWeb(item.Web);
            CultureInfo culture;

            // If the site has a variation label
            if (publishingWeb.Label != null)
            {
                var language = publishingWeb.Label.Language;
                culture = new CultureInfo(language);
            }
            else
            {
                culture = publishingWeb.Web.Locale;
            }

            return date.ToString("d", culture).Replace('/', '-');
        }
    }
}
