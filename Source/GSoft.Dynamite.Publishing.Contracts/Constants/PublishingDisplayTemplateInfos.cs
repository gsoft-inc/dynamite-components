using GSoft.Dynamite.Branding;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Display template definitions for the publishing module
    /// </summary>
    public class PublishingDisplayTemplateInfos
    {
        /// <summary>
        /// Display template reference for a single news item header information display (date, author, etc...)
        /// </summary>
        /// <returns>The display template info</returns>
        public DisplayTemplateInfo ItemSingleNewsItemHeader()
        {
            return new DisplayTemplateInfo("Item_SingleNewsItemHeader", DisplayTemplateCategory.Search);
        }

        /// <summary>
        /// Display template reference for a single news item display
        /// </summary>
        /// <returns>The display template info</returns>
        public DisplayTemplateInfo ItemSingleNewsItemContent()
        {
            return new DisplayTemplateInfo("Item_SingleNewsItemContent", DisplayTemplateCategory.Search);
        }

        /// <summary>
        /// Display template reference for a single content item display
        /// </summary>
        /// <returns>The display template info</returns>
        public DisplayTemplateInfo ItemSingleContentItem()
        {
            return new DisplayTemplateInfo("Item_SingleContentItem", DisplayTemplateCategory.Search);
        }

        /// <summary>
        /// Display template reference for  multiple news items display
        /// </summary>
        /// <returns>The display template info</returns>
        public DisplayTemplateInfo ItemNewsCategoryItem()
        {
            return new DisplayTemplateInfo("Item_NewsCategorySingleResult", DisplayTemplateCategory.Search);
        }

        /// <summary>
        /// Display template reference for the refinement filter
        /// </summary>
        /// <returns>The display template info</returns>
        public DisplayTemplateInfo DefaultFilterCategoryRefinement()
        {
            return new DisplayTemplateInfo("Filter_DefaultCategoryRefinement", DisplayTemplateCategory.Filter);
        }
    }
}
