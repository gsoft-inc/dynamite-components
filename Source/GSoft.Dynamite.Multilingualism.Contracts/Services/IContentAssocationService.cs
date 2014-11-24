using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.Contracts.Services
{
    public interface IContentAssocationService
    {
        /// <summary>
        /// Sets an unique content association key for an item
        /// </summary>
        /// <param name="item">The list item</param>
        /// <param name="fieldInternalName">The field internal name</param>
        SPListItem SetSourceGuid(SPListItem item, string fieldInternalName);

        /// <summary>
        /// Sets the source creator
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldInternalName"></param>
        SPListItem SetSourceCreator(SPListItem item, string fieldInternalName);

        /// <summary>
        /// Sets the current language of the item according to the web language
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="fieldInternalName">The field internal name</param>
        SPListItem SetTranslationLanguage(SPListItem item, string fieldInternalName);
    }
}
