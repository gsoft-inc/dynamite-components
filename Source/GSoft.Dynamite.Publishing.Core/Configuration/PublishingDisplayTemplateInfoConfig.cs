using System.Collections.Generic;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingDisplayTemplateInfoConfig : IPublishingDisplayTemplateInfoConfig
    {
        private readonly PublishingDisplayTemplateInfos _displayTemplateInfos;

        public PublishingDisplayTemplateInfoConfig(PublishingDisplayTemplateInfos displayTemplateInfos)
        {
            this._displayTemplateInfos = displayTemplateInfos;
        }

        public IList<DisplayTemplateInfo> DisplayTemplates()
        {
            var displayTemplates = new List<DisplayTemplateInfo>()
            {
                {this._displayTemplateInfos.ItemSingleContentItem()},
                {this._displayTemplateInfos.ItemSingleNewsItemContent()},
                {this._displayTemplateInfos.ItemSingleNewsItemHeader()},
                {this._displayTemplateInfos.ItemNewsCategoryItem()},
                {this._displayTemplateInfos.DefaultFilterCategoryRefinement()}
            };

            return displayTemplates;
        }
    }
}
