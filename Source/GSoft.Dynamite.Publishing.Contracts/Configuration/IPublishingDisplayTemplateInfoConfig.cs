using System.Collections.Generic;
using GSoft.Dynamite.Branding;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Configuration interface for the creation of the Display Templates
    /// </summary>
    public interface IPublishingDisplayTemplateInfoConfig
    {
        /// <summary>
        /// Property that return all the display templates to create in the publishing module
        /// </summary>
        IList<DisplayTemplateInfo> DisplayTemplates { get; }

        /// <summary>
        /// Gets the display template information by name from this configuration.
        /// </summary>
        /// <param name="name">The display template name.</param>
        /// <returns>The display template information</returns>
        DisplayTemplateInfo GetDisplayTemplateInfoByName(string name);
    }
}
