using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DemoMultilingualismVariationsConfig : IMultilingualismVariationsConfig
    {
        private readonly MultilingualismVariationSettingsInfos _baseVariationsSettingsInfo;
        private readonly IMultilingualismVariationsConfig _baseMultilingualismVariationsConfig;

        public DemoMultilingualismVariationsConfig(IMultilingualismVariationsConfig baseMultilingualismVariationsConfig)
        {
            this._baseMultilingualismVariationsConfig = baseMultilingualismVariationsConfig;
        }

        public VariationSettingsInfo VariationSettings()
        {
            // No variations settings for the demo
            return null;
        }
    }
}
