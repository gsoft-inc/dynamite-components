using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_TermDrivenPages
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("e34110a4-5d07-47dc-9f96-769aaa0b9b29")]
    public class CrossSitePublishingCMS_TermDrivenPagesEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Sets the term driven pages settings for taxonomy navigation terms
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var navigationHelper = featureScope.Resolve<INavigationHelper>();

                    var baseTermDrivenPageSettingsInfoConfig = featureScope.Resolve<INavigationTermDrivenPageSettingsInfoConfig>();

                    var termDrivenPageSettingInfos = baseTermDrivenPageSettingsInfoConfig.TermDrivenPageSettingInfos;

                    // Set term driven pages
                    foreach (var termDrivenSetting in termDrivenPageSettingInfos)
                    {
                        if (termDrivenSetting.IsTerm)
                        {
                            logger.Info("Setting term driven page {0} for term {1}", termDrivenSetting.CatalogTargetUrl, termDrivenSetting.Term.Label);
                        }
                        else
                        {
                            logger.Info("Setting term driven page {0} for term {1}", termDrivenSetting.CatalogTargetUrl, termDrivenSetting.TermSet.Label);
                        }

                        navigationHelper.SetTermDrivenPageSettings(web, termDrivenSetting);
                    }
                }
            }
        }
    }
}
