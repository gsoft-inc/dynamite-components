using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    /// <summary>
    /// Variations configuration for the Dynamite demo module
    /// </summary>
    public class DemoMultilingualismVariationsConfig : IMultilingualismVariationsConfig
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="baseMultilingualismVariationsConfig">The variations configuration from the multilingualism module</param>
        public DemoMultilingualismVariationsConfig(IMultilingualismVariationsConfig baseMultilingualismVariationsConfig)
        {
        }

        /// <summary>
        /// Overrides variations settings from the multilingualism module
        /// </summary>
        /// <returns>The variations settings</returns>
        public VariationSettingsInfo VariationSettings()
        {
            // No variations settings for the demo
            return null;
        }
    }
}
