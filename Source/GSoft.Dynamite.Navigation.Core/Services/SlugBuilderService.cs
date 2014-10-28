using System;
using System.Globalization;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    public class SlugBuilderService : ISlugBuilderService
    {
        private readonly ILogger _logger;
        private readonly NavigationHelper _navigationHelper;
        private readonly NavigationFieldInfos _navigationFieldInfos;

        public SlugBuilderService(ILogger logger, NavigationHelper navigationHelper, NavigationFieldInfos navigationFieldInfos)
        {
            this._logger = logger;
            this._navigationHelper = navigationHelper;
            this._navigationFieldInfos = navigationFieldInfos;
        }

        /// <summary>
        /// Sets the friendly URL slug.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SetFriendlyUrlSlug(SPListItem item)
        {
            var itemDateFieldName = this._navigationFieldInfos.PublishingStartDate().InternalName;
            var dateSlugFieldName = this._navigationFieldInfos.DateSlug().InternalName;
            var titleSlugFieldName = this._navigationFieldInfos.TitleSlug().InternalName;

            if (item.Fields.ContainsField(dateSlugFieldName) &&
               item.Fields.ContainsField(itemDateFieldName) && item.Fields.ContainsField(titleSlugFieldName))
            {
                item[dateSlugFieldName] = GetFriendlyUrlDate(item, itemDateFieldName);
                item[titleSlugFieldName] = this._navigationHelper.GenerateFriendlyUrlSlug(item.Title);

                this._logger.Info(
                    "ContentAssociation.SetFriendlyUrlSlug: Set date slug '{0}' and slug '{1}' on item '{2}' in web '{3}'.",
                    item[dateSlugFieldName],
                    item[titleSlugFieldName],
                    item.Title,
                    item.Web.Url);

                item.SystemUpdate();
            }
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
