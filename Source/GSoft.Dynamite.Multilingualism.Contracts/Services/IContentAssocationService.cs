using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.Contracts.Services
{
    /// <summary>
    /// Service interface for item association with OOTB SharePoint variations
    /// </summary>
    public interface IContentAssocationService
    {
        /// <summary>
        /// Sets an unique content association key for an item
        /// </summary>
        /// <param name="item">The SharePoint list item to set</param>
        /// <param name="fieldInternalName">The field internal name for the association key</param>
        /// <returns>The updated list item with the association key (not already yet committed in the database)</returns>
        SPListItem SetSourceGuid(SPListItem item, string fieldInternalName);

        /// <summary>
        /// Sets the source creator
        /// </summary>
        /// <param name="item">The SharePoint list item to set</param>
        /// <param name="fieldInternalName">Internal name of the field for the author. If the field doesn't exists, the OOTB <c>Author</c> field will be used.</param>
        /// <returns>The updated list item with the author (not already yet committed in the database)</returns>
        SPListItem SetSourceCreator(SPListItem item, string fieldInternalName);

        /// <summary>
        /// Sets the current language of the item according to the web language
        /// </summary>
        /// <param name="item">The SharePoint list item to set</param>
        /// <param name="fieldInternalName">The field internal name that represents the language</param>
        /// <returns>The updated list item with the language (not already yet committed in the database)</returns>
        SPListItem SetTranslationLanguage(SPListItem item, string fieldInternalName);
    }
}
