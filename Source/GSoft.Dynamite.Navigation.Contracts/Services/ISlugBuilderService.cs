using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Services
{
    /// <summary>
    /// Interface for the slug builder service
    /// </summary>
    public interface ISlugBuilderService
    {
        /// <summary>
        /// Sets the friendly URL slug.
        /// </summary>
        /// <param name="item">The item.</param>
        void SetFriendlyUrlSlug(SPListItem item);
    }
}
