using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Services
{
    public interface ISlugBuilderService
    {
        /// <summary>
        /// Sets the friendly URL slug.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="dateFieldName">The date field name</param>
        /// <param name="titleFieldName">The title field name</param>
        void SetFriendlyUrlSlug(SPListItem item, string dateFieldName, string titleFieldName);
    }
}
