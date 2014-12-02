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
    }
}
