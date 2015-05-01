using GSoft.Dynamite.Globalization.Variations;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Defines SharePoint variations labels
    /// </summary>
    public static class MultilingualismVariationLabelInfos
    {
        /// <summary>
        /// The english variation label definition
        /// </summary>
        /// <returns>The label info</returns>
        public static VariationLabelInfo EnglishLabel
        {
            get
            {
                return new VariationLabelInfo()
                {
                    Title = "en",
                    Description = "English Variation Label",
                    FlagControlDisplayName = "Home",
                    HierarchyCreationMode = CreationMode.PublishingSitesAndAllPages,
                    IsSource = true,
                    Language = "en-US",
                    Locale = 1033
                };
            }
        }

        /// <summary>
        /// The french variation label definition
        /// </summary>
        /// <returns>The label info</returns>
        public static VariationLabelInfo FrenchLabel
        {
            get
            {
                return new VariationLabelInfo()
                {
                    Title = "fr",
                    Description = "Label de variante Français",
                    FlagControlDisplayName = "Accueil",
                    HierarchyCreationMode = CreationMode.PublishingSitesAndAllPages,
                    IsSource = false,
                    Language = "fr-FR",
                    Locale = 1036
                };
            }
        }
    }
}
