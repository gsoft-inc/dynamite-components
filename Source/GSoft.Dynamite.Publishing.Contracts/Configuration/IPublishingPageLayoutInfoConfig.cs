using System.Collections.Generic;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Pages layouts configuration for the publishing modules
    /// </summary>
    public interface IPublishingPageLayoutInfoConfig
    {
        /// <summary>
        /// Property that return all the page layouts to create or configure in the publishing module
        /// </summary>
        IList<PageLayoutInfo> PageLayouts { get; }
    }
}
