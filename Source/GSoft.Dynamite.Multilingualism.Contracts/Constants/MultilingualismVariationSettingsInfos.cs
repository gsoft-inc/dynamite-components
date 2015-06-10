using System.Collections.Generic;
using GSoft.Dynamite.Globalization.Variations;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Defines the language settings for the SharePoint variations configuration
    /// </summary>
    public static class MultilingualismVariationSettingsInfos
    {
        /// <summary>
        /// Represents the variations configuration for english and french languages
        /// </summary>
        /// <returns>The variations settings info</returns>
        public static VariationSettingsInfo EnglishAndFrench
        {
            get
            {
                return new VariationSettingsInfo()
                {
                    IsCopyResourcesToTarget = true,
                    IsUpdateTargetPageWebParts = false,
                    Labels = new List<VariationLabelInfo>()
                    {
                        MultilingualismVariationLabelInfos.EnglishLabel,
                        MultilingualismVariationLabelInfos.FrenchLabel
                    }
                };
            }
        }

        /// <summary>
        /// Represents the variations configuration for english language only
        /// </summary>
        /// <returns>The variations settings info</returns>
        public static VariationSettingsInfo EnglishOnly
        {
            get
            {
                return new VariationSettingsInfo()
                {
                    IsCopyResourcesToTarget = true,
                    IsUpdateTargetPageWebParts = false,
                    Labels = new List<VariationLabelInfo>()
                    {
                        MultilingualismVariationLabelInfos.EnglishLabel,
                    }
                };
            }
        }

        /// <summary>
        /// Represents the variations configuration for french language only
        /// </summary>
        /// <returns>The variations settings info</returns>
        public static VariationSettingsInfo FrenchOnly
        {
            get
            {
                return new VariationSettingsInfo()
                {
                    IsCopyResourcesToTarget = true,
                    IsUpdateTargetPageWebParts = false,
                    Labels = new List<VariationLabelInfo>()
                    {
                        MultilingualismVariationLabelInfos.FrenchLabel,
                    }
                };
            }
        }
    }
}
