using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    public class MultilingualismVariationLabelInfos
    {
        public VariationLabelInfo EnglishLabel()
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

        public VariationLabelInfo FrenchLabel()
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
