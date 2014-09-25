using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingDisplayTemplateInfoConfig
    {
        private readonly BasePublishingDisplayTemplateInfos _displayTemplateInfos;

        public BasePublishingDisplayTemplateInfoConfig(BasePublishingDisplayTemplateInfos displayTemplateInfos)
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
            };

            return displayTemplates;
        }
    }
}
