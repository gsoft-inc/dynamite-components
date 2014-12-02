using System.Collections.Generic;
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
        private readonly PublishingDisplayTemplateInfos _displayTemplateInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="displayTemplateInfos">The display template info objects configuration</param>
        public PublishingDisplayTemplateInfoConfig(PublishingDisplayTemplateInfos displayTemplateInfos)
        {
            this._displayTemplateInfos = displayTemplateInfos;
        }

        /// <summary>
        /// Property that return all the display templates to create in the publishing module
        /// </summary>
        public IList<DisplayTemplateInfo> DisplayTemplates
        {
            get
            {
                var displayTemplates = new List<DisplayTemplateInfo>()
                {
                    this._displayTemplateInfos.ItemSingleContentItem(),
                    this._displayTemplateInfos.ItemSingleNewsItemContent(),
                    this._displayTemplateInfos.ItemSingleNewsItemHeader(),
                    this._displayTemplateInfos.ItemNewsCategoryItem(),
                    this._displayTemplateInfos.DefaultFilterCategoryRefinement()
                };

                return displayTemplates; 
            }
        }
    }
}
