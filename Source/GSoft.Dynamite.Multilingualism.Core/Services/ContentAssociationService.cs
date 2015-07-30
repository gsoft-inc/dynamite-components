using System;
using System.Globalization;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Multilingualism.Core.Services
{
    /// <summary>
    /// Service for item association with OOTB SharePoint variations
    /// </summary>
    public class ContentAssociationService : IContentAssocationService
    {
        private readonly IVariationHelper _variationsHelper;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentAssociationService" /> class.
        /// </summary>
        /// <param name="variationsHelper">The variations helper</param>
        /// <param name="logger">The logger</param>
        public ContentAssociationService(IVariationHelper variationsHelper, ILogger logger)
        {
            this._variationsHelper = variationsHelper;
            this._logger = logger;
        }

        /// <summary>
        /// Sets an unique content association key for an item
        /// </summary>
        /// <param name="item">The SharePoint list item to set</param>
        /// <param name="fieldInternalName">The field internal name for the association key</param>
        /// <returns>The updated list item with the association key (not already yet committed in the database)</returns>
        public SPListItem SetSourceGuid(SPListItem item, string fieldInternalName)
        {
            if (item.Fields.ContainsField(fieldInternalName))
            {
                // If the source guid has not been set yet
                if (item[fieldInternalName] == null)
                {
                    // If the content is created at the source label, create the unique identifier
                    if (this._variationsHelper.IsCurrentWebSourceLabel(item.Web))
                    {
                        var sourceGuid = Guid.NewGuid();
                        item[fieldInternalName] = sourceGuid;
                    }
                    else
                    {
                        this._logger.Warn("ContentAssociation.SetSourceGuid: Trying to set source guid on web '{0}' which is not a source label.", item.Web.Url);
                    } 
                }
                else
                {
                    this._logger.Warn("ContentAssociation.SetSourceGuid: Source guid already set for item {0}. Skipping...", item.Url);                
                } 
            }

            return item;
        }

        /// <summary>
        /// Sets the source creator
        /// </summary>
        /// <param name="item">The SharePoint list item to set</param>
        /// <param name="fieldInternalName">Internal name of the field for the author. If the field doesn't exists, the OOTB <c>Author</c> field will be used.</param>
        /// <returns>The updated list item with the author (not already yet committed in the database)</returns>
        public SPListItem SetSourceCreator(SPListItem item, string fieldInternalName)
        {
            if (item.Fields.ContainsField(fieldInternalName))
            {
                const string AuthorFieldName = "Author";
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
                                item[AuthorFieldName] = sourceCreatorFieldValue;
                            }
                        }
                        else
                        {
                            var authorFieldValue = item[AuthorFieldName];
                            if (authorFieldValue != null)
                            {
                                item[fieldInternalName] = authorFieldValue;
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    this._logger.Error("ContentAssociation.SetSourceCreator: error '{0}'", ex.Message);
                }
            }

            return item;
        }

        /// <summary>
        /// Sets the current language of the item according to the web language
        /// </summary>
        /// <param name="item">The SharePoint list item to set</param>
        /// <param name="fieldInternalName">The field internal name that represents the language</param>
        /// <returns>The updated list item with the language (not already yet committed in the database)</returns>
        public SPListItem SetTranslationLanguage(SPListItem item, string fieldInternalName)
        {
            if (item.Fields.ContainsField(fieldInternalName))
            {
                // Use the ll-cc format to match with the search token {Site.Locale}
                // It's better to use the locale of the site (Regional settings) instead of the Language because in the case where the locale is different,
                // it's preferable to use the locale (especially for unsupported languages)
                string locale = item.Web.Locale.Name;                 
                item[fieldInternalName] = locale;
                
                this._logger.Info(
                    "ContentAssociation.SetTranslationLanguage: Set item language to '{0}' on item '{1}' in web '{2}'.",
                    item[fieldInternalName],
                    item.Title,
                    item.Web.Url);
            }

            return item;
        }
    }
}
