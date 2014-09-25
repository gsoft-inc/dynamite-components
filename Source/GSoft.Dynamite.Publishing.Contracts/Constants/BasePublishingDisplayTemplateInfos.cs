using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingDisplayTemplateInfos
    {
        public DisplayTemplateInfo ItemSingleNewsItemHeader()
        {
            return new DisplayTemplateInfo("Item_SingleNewsItemHeader", DisplayTemplateCategory.Search);
        }

        public DisplayTemplateInfo ItemSingleNewsItemContent()
        {
            return new DisplayTemplateInfo("Item_SingleNewsItemContent", DisplayTemplateCategory.Search);
        }

        public DisplayTemplateInfo ItemSingleContentItem()
        {
            return new DisplayTemplateInfo("Item_SingleContentItem", DisplayTemplateCategory.Search);
        }
    }
}
