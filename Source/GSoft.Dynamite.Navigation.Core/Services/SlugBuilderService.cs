using System;
using System.Globalization;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    public class SlugBuilderService : ISlugBuilderService
    {
        private readonly ILogger _logger;
        private readonly NavigationHelper _navigationHelper;

        public SlugBuilderService(ILogger logger, NavigationHelper navigationHelper)
        {
            this._logger = logger;
            this._navigationHelper = navigationHelper;
        }

        /// <summary>
        /// Sets the friendly URL slug.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="dateFieldName">The date field name</param>
        /// <param name="titleFieldName">The title field name</param>
        public void SetFriendlyUrlSlug(SPListItem item, string dateFieldName, string titleFieldName)
        {
            if (item.Fields.ContainsField(dateFieldName) &&
               item.Fields.ContainsField(titleFieldName))
            {
                item[dateFieldName] = GetFriendlyUrlDate(item, dateFieldName);
                item[titleFieldName] = this._navigationHelper.GenerateFriendlyUrlSlug(item.Title);

                this._logger.Info(
                    "ContentAssociation.SetFriendlyUrlSlug: Set date slug '{0}' and slug '{1}' on item '{2}' in web '{3}'.",
                    item[dateFieldName],
                    item[titleFieldName],
                    item.Title,
                    item.Web.Url);

                item.SystemUpdate();
            }
        }

        private static string GetFriendlyUrlDate(SPListItem item, string fieldName)
        {
            var dateFieldValue = item[fieldName];
            var date = (DateTime)dateFieldValue;
            var language = PublishingWeb.GetPublishingWeb(item.Web).Label.Language;
            var culture = new CultureInfo(language);

            return date.ToString("d", culture).Replace('/', '-');
        }
    }
}
