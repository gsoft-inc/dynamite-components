using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

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
        /// <summary>
        /// Handles the feature activated event.
        /// </summary>
        /// <param name="properties">Feature Receiver Properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var baseFieldInfoConfig = featureScope.Resolve<INavigationFieldInfoConfig>();
                    var baseFieldInfos = baseFieldInfoConfig.Fields;
                    var baseFieldDefinition = featureScope.Resolve<NavigationFieldInfos>();

                    // Gets the field
                    var fieldReference = baseFieldDefinition.OccurrenceLinkLocation();
                    var field = baseFieldInfos.Single(baseField => baseField.Id == fieldReference.Id) as TaxonomyMultiFieldInfo;

                    // Updates the visibility properties of the field
                    field.IsHiddenInDisplayForm = false;
                    field.IsHiddenInEditForm = false;
                    field.IsHiddenInNewForm = false;
                    field.IsHiddenInListSettings = false;

                    // Ensures the field
                    fieldHelper.EnsureField(site.RootWeb.Fields, field);
                }
            }
        }

        /// <summary>
        /// Handles the feature deactivating event.
        /// </summary>
        /// <param name="properties">Feature Receiver Properties</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var baseFieldInfoConfig = featureScope.Resolve<INavigationFieldInfoConfig>();
                    var baseFieldInfos = baseFieldInfoConfig.Fields;
                    var baseFieldDefinition = featureScope.Resolve<NavigationFieldInfos>();

                    // Gets the field
                    var fieldReference = baseFieldDefinition.OccurrenceLinkLocation();
                    var field = baseFieldInfos.Single(baseField => baseField.Id == fieldReference.Id) as TaxonomyMultiFieldInfo;

                    // Updates the visibility properties of the field
                    field.IsHiddenInDisplayForm = true;
                    field.IsHiddenInEditForm = true;
                    field.IsHiddenInNewForm = true;
                    field.IsHiddenInListSettings = true;

                    // Ensures the field
                    fieldHelper.EnsureField(site.RootWeb.Fields, field);
                }
            }
        }
    }
}
