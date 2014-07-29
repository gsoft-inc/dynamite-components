using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Portal.Contracts.WebParts
{
    /// <summary>
    /// Interface for contextual navigation web part
    /// </summary>
    public interface IContextualNavigation : IBaseWebPart
    {
        /// <summary>
        /// Search page
        /// </summary>
        bool SearchPages { get; set; }

        /// <summary>
        /// Is parent node.
        /// </summary>
        bool IsParentNode { get; set; }
    }
}
