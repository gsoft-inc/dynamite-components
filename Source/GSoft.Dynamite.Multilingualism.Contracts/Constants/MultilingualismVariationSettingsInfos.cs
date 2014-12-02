using System.Collections.Generic;
using GSoft.Dynamite.Globalization.Variations;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Defines the language settings for the SharePoint variations configuration
    /// </summary>
    public class MultilingualismVariationSettingsInfos
    {
        private readonly MultilingualismVariationLabelInfos _variationLabelInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="variationLabelInfos">The variation labels settings from the multilingualism module</param>
        public MultilingualismVariationSettingsInfos(MultilingualismVariationLabelInfos variationLabelInfos)
        {
            this._variationLabelInfos = variationLabelInfos;
        }

        /// <summary>
        /// Represents the variations configuration for english and french languages
        /// </summary>
        /// <returns>The variations settings info</returns>
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

        /// <summary>
        /// Represents the variations configuration for english language only
        /// </summary>
        /// <returns>The variations settings info</returns>
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

        /// <summary>
        /// Represents the variations configuration for french language only
        /// </summary>
        /// <returns>The variations settings info</returns>
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
