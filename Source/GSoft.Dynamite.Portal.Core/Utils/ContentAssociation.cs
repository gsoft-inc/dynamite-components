using System;
using System.Globalization;
using System.Linq;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Utils;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Portal.Core.Utils
{
    /// <summary>
    /// Class to associate the english and french pages
    /// </summary>
    public class ContentAssociation : IContentAssociation
    {
        private readonly VariationHelper variationHelper;
        private readonly NavigationHelper navigationHelper;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentAssociation" /> class.
        /// </summary>
        /// <param name="variationsHelper">The variations helper.</param>
        /// <param name="navigationHelper">The navigation helper.</param>
        /// <param name="logger">The logger.</param>
        public ContentAssociation(VariationHelper variationsHelper, NavigationHelper navigationHelper, ILogger logger)
        {
            this.variationHelper = variationsHelper;
            this.navigationHelper = navigationHelper;
            this.logger = logger;
        }

        /// <summary>
        /// Sets the source content association unique identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SetSourceGuid(SPListItem item)
        {
            // If the content is created at the source label, create the unique identifier
            if (this.variationHelper.IsCurrentWebSourceLabel(item.Web))
            {
                var sourceGuid = Guid.NewGuid();
                item[PortalFields.ContentAssociationKey.InternalName] = sourceGuid;
                item.SystemUpdate();
            }
            else
            {
                this.logger.Warn("ContentAssociation.SetSourceGuid: Trying to set source guid on web '{0}' which is not a source label.", item.Web.Url);
            }
        }

        /// <summary>
        /// Sets the friendly URL slug.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SetFriendlyUrlSlug(SPListItem item)
        {
            item[PortalFields.DateSlug.InternalName] = GetFriendlyUrlDate(item);
            item[PortalFields.Slug.InternalName] = this.navigationHelper.GenerateFriendlyUrlSlug(item.Title);

            this.logger.Info(
                "ContentAssociation.SetFriendlyUrlSlug: Set date slug '{0}' and slug '{1}' on item '{2}' in web '{3}'.",
                item[PortalFields.DateSlug.InternalName],
                item[PortalFields.Slug.InternalName],
                item.Title,
                item.Web.Url);

            item.SystemUpdate();
        }

        /// <summary>
        /// Sets the translation language.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SetTranslationLanguage(SPListItem item)
        {
            var localeAgnosticLanguage = PublishingWeb.GetPublishingWeb(item.Web).Label.Language.Split('-').First();
            item[PortalFields.ItemLanguage.InternalName] = localeAgnosticLanguage;

            this.logger.Info(
                "ContentAssociation.SetTranslationLanguage: Set item language to '{0}' on item '{1}' in web '{2}'.",
                item[PortalFields.ItemLanguage.InternalName],
                item.Title,
                item.Web.Url);

            item.SystemUpdate();
        }

        private static string GetFriendlyUrlDate(SPListItem item)
        {
            DateTime? date;
            var language = PublishingWeb.GetPublishingWeb(item.Web).Label.Language;
            var culture = new CultureInfo(language);

            if (item.ParentList.Fields.ContainsFieldWithStaticName(PortalFields.ArticleStartDate.InternalName))
            {
                date = item[PortalFields.ArticleStartDate.InternalName] as DateTime?;
            }
            else if (item.ParentList.Fields.ContainsFieldWithStaticName(PortalFields.SchedulingStartDate.InternalName))
            {
                date = item[PortalFields.SchedulingStartDate.InternalName] as DateTime?;
            }
            else
            {
                date = item[SPBuiltInFieldId.Created] as DateTime?;
            }

            if (date != null && date.HasValue)
            {
                return date.Value.ToString("d", culture).Replace('/', '-');
            }

            return string.Empty;
        }
    }
}