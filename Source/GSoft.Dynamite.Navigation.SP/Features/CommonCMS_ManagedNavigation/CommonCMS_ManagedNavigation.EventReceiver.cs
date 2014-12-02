using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CommonCMS_ManagedNavigation
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("e2483563-7707-4666-a394-64af9f62d2e1")]
    public class CrossSitePublishingCMS_ManagedNavigationEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var navigationHelper = featureScope.Resolve<INavigationHelper>();
                    var baseNavigationSettings = featureScope.Resolve<INavigationManagedNavigationInfoConfig>();

                    IList<ManagedNavigationInfo> navigationSettings = baseNavigationSettings.NavigationSettings;

                    // Set navigation settings
                    foreach (var setting in navigationSettings)
                    {
                        if (setting.AssociatedLanguage.Equals(new CultureInfo((int)web.Language)) || setting.AssociatedLanguage.Equals(web.Locale))
                        {
                            logger.Info("Configure managed navigation for web {0}", web.Url);
                            navigationHelper.SetWebNavigationSettings(web, setting); 
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Feature deactivating event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            if (web != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var navigationHelper = featureScope.Resolve<INavigationHelper>();
                    var baseNavigationSettings = featureScope.Resolve<INavigationManagedNavigationInfoConfig>();

                    IList<ManagedNavigationInfo> navigationSettings = baseNavigationSettings.NavigationSettings;

                    // Reset navigation settings
                    foreach (var setting in navigationSettings)
                    {
                        if (setting.AssociatedLanguage.Equals(new CultureInfo((int)web.Language)) || setting.AssociatedLanguage.Equals(web.Locale))
                        {
                            logger.Info("Reseting managed navigation for web {0} to default", web.Url);
                            navigationHelper.ResetWebNavigationToDefault(web, setting);    
                        }
                    }                              
                }
            }
        }
    }
}
