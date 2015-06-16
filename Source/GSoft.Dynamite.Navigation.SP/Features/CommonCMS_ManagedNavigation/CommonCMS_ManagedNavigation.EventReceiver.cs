using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

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
                    var fieldLocator = featureScope.Resolve<IFieldLocator>();
                    var baseNavigationSettings = featureScope.Resolve<INavigationManagedNavigationInfoConfig>();
                    var publishingListConfig = featureScope.Resolve<IPublishingListInfoConfig>();

                    IList<ManagedNavigationInfo> navigationSettings = baseNavigationSettings.NavigationSettings;

                    // Set navigation settings
                    foreach (var setting in navigationSettings)
                    {
                        if (setting.AssociatedLanguage.Equals(new CultureInfo((int)web.Language)) || setting.AssociatedLanguage.Equals(web.Locale))
                        {
                            logger.Info("Configuring managed navigation for web {0}", web.Url);

                            // Set the web settings
                            navigationHelper.SetWebNavigationSettings(web, setting);

                            // The problem with this code is each navigation column on lists is set. This setting was already done
                            // on the publishing module. With this code, we cannot use specified termset on a list.
                            // Look for the DynamiteNavigation field on any relevant list on the web
                            var navListFieldsOnCurrentWeb = new Dictionary<string, SPField>();
                            foreach (SPList list in web.Lists)
                            {
                                var navField = fieldLocator.GetFieldById(list.Fields, PublishingFieldInfos.Navigation.Id);

                                if (navField != null)
                                {
                                    navListFieldsOnCurrentWeb.Add(list.Title, navField);
                                }
                            }

                            // Update the fields afterwards because updating them while looping on the SPListCollection
                            // will blow up (can't execute while enumerating).
                            foreach (string listTitle in navListFieldsOnCurrentWeb.Keys)
                            {
                                logger.Info(
                                    "Configuring managed navigation term set {0} (id:{1}) for field DynamiteNavigation on list {2}",
                                    setting.TermSet.Label,
                                    setting.TermSet.Id,
                                    listTitle);
                                var navField = navListFieldsOnCurrentWeb[listTitle];

                                // We assume that everybody wants their lists' DynamiteNavigation fields
                                // to be bound by default to the same term set as their parent web.
                                var asTaxoField = navField as TaxonomyField;
                                asTaxoField.TermSetId = setting.TermSet.Id;
                                asTaxoField.Update();
                            }
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
