using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    public class BaseMultilingualismVariationSettingsInfos
    {

        private readonly BaseMultilingualismVariationLabelInfos _variationLabelInfos;

        public BaseMultilingualismVariationSettingsInfos(BaseMultilingualismVariationLabelInfos variationLabelInfos)
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
