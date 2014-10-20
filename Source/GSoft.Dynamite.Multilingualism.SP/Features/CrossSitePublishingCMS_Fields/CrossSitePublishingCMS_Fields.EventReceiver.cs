using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Features.CrossSitePublishingCMS_Fields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("3807deb0-3421-4525-ac09-34270c8d6d82")]
    public class CrossSitePublishingCMS_FieldsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<FieldHelper>();
                    var baseFieldInfoConfig = featureScope.Resolve<IMultilingualismFieldInfoConfig>();
                    var baseFields = baseFieldInfoConfig.Fields;
                    var logger = featureScope.Resolve<ILogger>();

                    // Create base Fields
                    foreach (IFieldInfo field in baseFields)
                    {
                        fieldHelper.EnsureField(site.RootWeb.Fields, field);
                    }

                    // Create additionnal custom fields
                  /*  ICustomPublishingFieldInfoConfig customContentTypeConfig = null;
                    if (featureScope.TryResolve(out customContentTypeConfig))
                    {
                        var customFields = customContentTypeConfig.Fields;

                        foreach (IFieldInfo field in customFields)
                        {
                            fieldHelper.EnsureField(site.RootWeb.Fields, field);
                        }
                    }
                    else
                    {
                        logger.Info("No custom fields override found!");
                    }*/
                }
            }
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
