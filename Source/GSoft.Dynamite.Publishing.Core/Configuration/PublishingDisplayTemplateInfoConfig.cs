using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration for the creation of the Display Templates
    /// </summary>
    public class PublishingDisplayTemplateInfoConfig : IPublishingDisplayTemplateInfoConfig
    {
        /// <summary>
        /// Property that return all the display templates to create in the publishing module
        /// </summary>
        public IList<DisplayTemplateInfo> DisplayTemplates
        {
            get
            {
                var displayTemplates = new List<DisplayTemplateInfo>()
                {
                    PublishingDisplayTemplateInfos.ItemSingleContentItem,
                    PublishingDisplayTemplateInfos.ItemSingleNewsItemContent,
                    PublishingDisplayTemplateInfos.ItemSingleNewsItemHeader,
                    PublishingDisplayTemplateInfos.ItemNewsCategoryItem,
                    PublishingDisplayTemplateInfos.DefaultFilterCategoryRefinement
                };

                return displayTemplates; 
            }
        }

        /// <summary>
        /// Gets the display template information by name from this configuration.
        /// </summary>
        /// <param name="name">The display template name.</param>
        /// <returns>
        /// The display template information
        /// </returns>
        public DisplayTemplateInfo GetDisplayTemplateInfoByName(string name)
        {
            return this.DisplayTemplates.Single(t => t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
