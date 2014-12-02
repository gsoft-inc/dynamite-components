using GSoft.Dynamite.Globalization.Variations;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    /// <summary>
    /// Interface for variations settings for the multilingual module
    /// </summary>
    public interface IMultilingualismVariationsConfig
    {
        /// <summary>
        /// Property that return all the variation settings to use in the multilingualism module
        /// </summary>
        /// <returns>A list of variation settings to use in the multilingualism module</returns>
        VariationSettingsInfo VariationSettings();
    }
}
