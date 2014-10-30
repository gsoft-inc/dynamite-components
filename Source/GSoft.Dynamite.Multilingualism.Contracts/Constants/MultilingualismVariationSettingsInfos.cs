using System.Collections.Generic;
using GSoft.Dynamite.Globalization.Variations;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    public class MultilingualismVariationSettingsInfos
    {

        private readonly MultilingualismVariationLabelInfos _variationLabelInfos;

        public MultilingualismVariationSettingsInfos(MultilingualismVariationLabelInfos variationLabelInfos)
        {
            this._variationLabelInfos = variationLabelInfos;
        }

        public VariationSettingsInfo EnglishAndFrench()
        {
            return new VariationSettingsInfo()
            {
                AutoSpawnStopAfterDelete = "true",
                CopyResources = "true",
                CreateHierarchies = "true",
                EnableAutoSpawn = "false",
                SourceVarRootWebTemplate = "CMSPUBLISHING#0",
                UpdateWebParts = "false",
                SendNotificationEmail = "false",
                Labels = new List<VariationLabelInfo>()
                {
                    this._variationLabelInfos.EnglishLabel(),
                    this._variationLabelInfos.FrenchLabel()
                }
            };
        }

        public VariationSettingsInfo EnglishOnly()
        {
            return new VariationSettingsInfo()
            {
                AutoSpawnStopAfterDelete = "true",
                CopyResources = "true",
                CreateHierarchies = "true",
                EnableAutoSpawn = "false",
                SourceVarRootWebTemplate = "CMSPUBLISHING#0",
                UpdateWebParts = "false",
                SendNotificationEmail = "false",
                Labels = new List<VariationLabelInfo>()
                {
                    this._variationLabelInfos.EnglishLabel(),
                }
            };
        }

        public VariationSettingsInfo FrenchOnly()
        {
            return new VariationSettingsInfo()
            {
                AutoSpawnStopAfterDelete = "true",
                CopyResources = "true",
                CreateHierarchies = "true",
                EnableAutoSpawn = "false",
                SourceVarRootWebTemplate = "CMSPUBLISHING#0",
                UpdateWebParts = "false",
                SendNotificationEmail = "false",
                Labels = new List<VariationLabelInfo>()
                {
                    this._variationLabelInfos.FrenchLabel(),
                }
            };
        }   
    }
}
