using System;
using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class BaseMultilingualismVariationsConfig : IBaseMultilingualismVariationsConfig
    {
        private readonly BaseMultilingualismVariationSettingsInfos _variationSettingsInfos;


        public BaseMultilingualismVariationsConfig(BaseMultilingualismVariationSettingsInfos variationSettingsInfos)
        {
            this._variationSettingsInfos = variationSettingsInfos;
        }

        public VariationSettingsInfo VariationSettings()
        {
            return this._variationSettingsInfos.EnglishAndFrench();
        }
    }
}
