using System.Globalization;
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
                var englishUsCulture = new CultureInfo("en-US");
                return new VariationLabelInfo()
                {
                    Title = "en",
                    DisplayName = "Home",
                    Description = "English Variation Label",
                    IsSource = true,
                    Language = englishUsCulture,
                    Locale = englishUsCulture
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
                var frenchFrCulture = new CultureInfo("fr-FR");
                return new VariationLabelInfo()
                {
                    Title = "fr",
                    DisplayName = "Accueil",
                    Description = "Label de variante Français",
                    IsSource = false,
                    Language = frenchFrCulture,
                    Locale = frenchFrCulture
                };
            }
        }
    }
}
