using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CommonCMS_VariationsHierarchies
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("63800021-8d04-45d0-9c74-bff6bcc6d3d8")]
    public class CommonCmsVariationsHierarchiesventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var variationHelper = featureScope.Resolve<VariationHelper>();
                    var baseVariationSettingsConfig = featureScope.Resolve<IMultilingualismVariationsConfig>();
                    var logger = featureScope.Resolve<ILogger>();

                    var baseVariationSettings = baseVariationSettingsConfig.VariationSettings();

                    if (baseVariationSettings != null)
                    {
                        logger.Info("Creating variation hierarchies for {0}", site.Url);
                        variationHelper.SetupVariations(site, baseVariationSettings);
                    }
                }
            }
        }
    }
}
