using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CommonCMS_SyncWebs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("faa27790-ddc8-48cc-81c7-afe148930b17")]
    public class CommonCmsSyncWebsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var variationSyncHelper = featureScope.Resolve<IVariationSyncHelper>();
                    var baseVariationSettingsConfig = featureScope.Resolve<IMultilingualismVariationsConfig>();
                    var baseVariationSettings = baseVariationSettingsConfig.VariationSettings();

                    if (baseVariationSettings != null)
                    {
                        logger.Info("Synchronize variations for web {0}", web.Url);
                        variationSyncHelper.SyncWeb(web, baseVariationSettings.Labels.ToList()); 
                    }
                }
            }
        }
    }
}
