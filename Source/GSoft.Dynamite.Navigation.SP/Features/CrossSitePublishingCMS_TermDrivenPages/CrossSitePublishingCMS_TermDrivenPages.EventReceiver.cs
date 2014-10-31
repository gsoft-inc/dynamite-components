using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("5c004e26-0775-4fea-bf77-f6edbabbb6ff")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var navigationHelper = featureScope.Resolve<INavigationHelper>();

                    var baseTermDrivenPageSettingsInfoConfig = featureScope.Resolve<INavigationTermDrivenpageSettingsInfoConfig>();

                    IList<TermDrivenPageSettingInfo> termDrivenPageSettingInfos = baseTermDrivenPageSettingsInfoConfig.TermDrivenPageSettingInfos;

                    // Create base result types
                    foreach (var termDrivenSetting in termDrivenPageSettingInfos)
                    {
                        navigationHelper.SetTermDrivenPageSettings(site, termDrivenSetting);
                    }
                }
            }
        }
    }
}
