using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Helpers;
using Microsoft.SharePoint;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Navigation.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_OccurrenceLinkLocationField
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("9c37a632-666f-465a-a92a-330aa5e7db44")]
    public class CrossSitePublishingCMS_OccurrenceLinkLocationFieldEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<FieldHelper>();
                    var baseFieldInfos = featureScope.Resolve<NavigationFieldInfos>();

                    var field = baseFieldInfos.OccurrenceLinkLocation();    

                    field.IsHiddenInDisplayForm = false;
                    field.IsHiddenInDisplayForm = false;
                    field.IsHiddenInDisplayForm = false;
                    field.IsHiddenInDisplayForm = false;

                    fieldHelper.EnsureField(site.RootWeb.Fields, field);
                }
            }
        }

        /// <summary>
        /// Handles when the feature deactiving
        /// </summary>
        /// <param name="properties">Properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<FieldHelper>();
                    var baseFieldInfos = featureScope.Resolve<NavigationFieldInfos>();

                    var field = baseFieldInfos.OccurrenceLinkLocation();

                    field.IsHiddenInDisplayForm = true;
                    field.IsHiddenInDisplayForm = true;
                    field.IsHiddenInDisplayForm = true;
                    field.IsHiddenInDisplayForm = true;

                    fieldHelper.EnsureField(site.RootWeb.Fields, field);
                }
            }
        }
    }
}
