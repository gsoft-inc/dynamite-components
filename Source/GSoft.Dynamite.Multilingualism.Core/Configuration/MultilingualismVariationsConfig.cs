using System;
using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class MultilingualismVariationsConfig : IMultilingualismVariationsConfig
    {
        private readonly MultilingualismVariationSettingsInfos _variationSettingsInfos;


        public MultilingualismVariationsConfig(MultilingualismVariationSettingsInfos variationSettingsInfos)
        {
            this._variationSettingsInfos = variationSettingsInfos;
        }

        public VariationSettingsInfo VariationSettings()
        {
            return this._variationSettingsInfos.EnglishAndFrench();
        }
    }
}
