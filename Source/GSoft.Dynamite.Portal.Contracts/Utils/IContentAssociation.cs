using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Utils
{
    /// <summary>
    /// Interface for the content association
    /// </summary>
    public interface IContentAssociation
    {
        /// <summary>
        /// Method to set the source GUID
        /// </summary>
        /// <param name="item">The list item to set</param>
        void SetSourceGuid(SPListItem item);

        /// <summary>
        /// Method to set the friendly url slug
        /// </summary>
        /// <param name="item">The list item to set</param>
        void SetFriendlyUrlSlug(SPListItem item);

        /// <summary>
        /// Method to set the translation language
        /// </summary>
        /// <param name="item">The list item to set</param>
        void SetTranslationLanguage(SPListItem item);
    }
}
