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

        /// <summary>
        /// Gets Page layout from this configuration using its file name including the aspx extention.
        /// </summary>
        /// <param name="name">The page layout name including aspx extention.</param>
        /// <returns>The page layout information.</returns>
        PageLayoutInfo GetPageLayoutByName(string name);
    }
}
