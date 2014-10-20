using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_Fields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("ced7a8ec-f023-439e-8202-4eb529363ed9")]
    public class CrossSitePublishingCMS_FieldsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<FieldHelper>();
                    var baseFieldInfoConfig = featureScope.Resolve<IBaseNavigationFieldInfoConfig>();
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
    }
}
