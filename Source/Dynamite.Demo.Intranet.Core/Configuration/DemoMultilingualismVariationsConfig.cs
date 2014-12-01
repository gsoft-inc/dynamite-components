using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DemoMultilingualismVariationsConfig : IMultilingualismVariationsConfig
    {
        public DemoMultilingualismVariationsConfig(IMultilingualismVariationsConfig baseMultilingualismVariationsConfig)
        {
        }

        public VariationSettingsInfo VariationSettings()
        {
            // No variations settings for the demo
            return null;
        }
    }
}
