using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoMultilingualismVariationsConfig : IBaseMultilingualismVariationsConfig
    {
        private BaseMultilingualismVariationLabelInfos _baseVariationsSettingsInfo;

        public DynamiteDemoMultilingualismVariationsConfig(BaseMultilingualismVariationLabelInfos baseVariationsSettingsInfo)
        {
            this._baseVariationsSettingsInfo = baseVariationsSettingsInfo;
        }

        public VariationSettingsInfo VariationSettings()
        {
            // No variations settings for the demo
            return null;
        }
    }
}
