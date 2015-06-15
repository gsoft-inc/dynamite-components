using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Security;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP.Features.CrossSitePublishingCMS_Fields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("a63a9e57-ac21-4850-93f0-2dc31a29bbc2")]
    public class CrossSitePublishingCmsFieldsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Creates fields for the targeting module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = TargetingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var baseFieldInfoConfig = featureScope.Resolve<ITargetingFieldInfoConfig>();
                    var baseFields = baseFieldInfoConfig.Fields;
                    var logger = featureScope.Resolve<ILogger>();

                    using (new Unsafe(site.RootWeb))
                    {
                        // Create fields
                        foreach (var field in baseFields)
                        {
                            logger.Info("Creating field {0}", field.InternalName);
                            fieldHelper.EnsureField(site.RootWeb.Fields, field);
                        }
                    }
                }
            }
        }
    }
}
