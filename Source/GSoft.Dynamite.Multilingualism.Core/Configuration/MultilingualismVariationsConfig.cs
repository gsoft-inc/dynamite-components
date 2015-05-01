using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Variations settings for the multilingual module
    /// </summary>
    public class MultilingualismVariationsConfig : IMultilingualismVariationsConfig
    {
        /// <summary>
        /// Property that return all the variation settings to use in the multilingualism module
        /// </summary>
        /// <returns>A list of variation settings to use in the multilingualism module</returns>
        public VariationSettingsInfo VariationSettings()
        {
            return MultilingualismVariationSettingsInfos.EnglishAndFrench;
        }
    }
}
