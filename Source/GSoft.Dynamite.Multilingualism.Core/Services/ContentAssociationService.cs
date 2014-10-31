using System;
using System.Linq;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Utils;

namespace GSoft.Dynamite.Multilingualism.Core.Services
{
    public class ContentAssociationService: IContentAssocationService
    {
        private readonly IVariationHelper _variationsHelper;
        private readonly INavigationHelper _navigationHelper;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentAssociationService" /> class.
        /// </summary>
        /// <param name="variationsHelper">The variations helper.</param>
        /// <param name="navigationHelper">The navigation helper.</param>
        /// <param name="logger">The logger.</param>
        public ContentAssociationService(IVariationHelper variationsHelper, INavigationHelper navigationHelper, ILogger logger)
        {
            this._variationsHelper = variationsHelper;
            this._navigationHelper = navigationHelper;
            this._logger = logger;
        }

        /// <summary>
        /// Sets an unique content association key for an item
        /// </summary>
        /// <param name="item">The list item</param>
        /// <param name="fieldInternalName">The field internal name</param>
        public void SetSourceGuid(SPListItem item, string fieldInternalName)
        {
            if (item.Fields.ContainsField(fieldInternalName))
            {
                // If the content is created at the source label, create the unique identifier
                if (this._variationsHelper.IsCurrentWebSourceLabel(item.Web))
                {
                    var sourceGuid = Guid.NewGuid();
                    item[fieldInternalName] = sourceGuid;
                    item.SystemUpdate();
                }
                else
                {
                    this._logger.Warn("ContentAssociation.SetSourceGuid: Trying to set source guid on web '{0}' which is not a source label.", item.Web.Url);
                }
            }
        }

        /// <summary>
        /// Sets the source creator
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldInternalName"></param>
        public void SetSourceCreator(SPListItem item, string fieldInternalName)
        {
            if (item.Fields.ContainsField(fieldInternalName))
            {
                const string authorFieldName = "Author";
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(
                    () =>
                    {
                        // If the current web is not the source label, set the author to the source creator
                        // If the current web is the source label, save the author to the source creator field
                        if (!this._variationsHelper.IsCurrentWebSourceLabel(item.Web))
                        {
                            var sourceCreatorFieldValue = item[fieldInternalName];
                            if (sourceCreatorFieldValue != null)
                            {
                                item[authorFieldName] = sourceCreatorFieldValue;
                                item.SystemUpdate();
                            }
                        }
                        else
                        {
                            var authorFieldValue = item[authorFieldName];
                            if (authorFieldValue != null)
                            {
                                item[fieldInternalName] = authorFieldValue;
                                item.SystemUpdate();
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    this._logger.Error("ContentAssociation.SetSourceCreator: error '{0}'", ex.Message);
                }
            }
        }

        /// <summary>
        /// Sets the current language of the item according to the web language
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="fieldInternalName">The field internal name</param>
        public void SetTranslationLanguage(SPListItem item, string fieldInternalName)
        {

            if (item.Fields.ContainsField(fieldInternalName))
            {
                var localeAgnosticLanguage = PublishingWeb.GetPublishingWeb(item.Web).Label.Title;
                item[fieldInternalName] = localeAgnosticLanguage;

                this._logger.Info(
                    "ContentAssociation.SetTranslationLanguage: Set item language to '{0}' on item '{1}' in web '{2}'.",
                    item[fieldInternalName],
                    item.Title,
                    item.Web.Url);

                item.SystemUpdate();
            }
        }
    }
}
