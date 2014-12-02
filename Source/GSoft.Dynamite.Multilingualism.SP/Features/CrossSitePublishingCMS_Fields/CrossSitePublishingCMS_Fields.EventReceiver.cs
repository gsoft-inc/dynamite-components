using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Fields;
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
        /// <summary>
        /// Creates fields for the multilingualism module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MultilingualismContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var baseFieldInfoConfig = featureScope.Resolve<IMultilingualismFieldInfoConfig>();
                    var baseFields = baseFieldInfoConfig.Fields;
                    var logger = featureScope.Resolve<ILogger>();

                    // Create base Fields
                    foreach (IFieldInfo field in baseFields)
                    {
                        logger.Info("Creating field {0}", field.InternalName);
                        fieldHelper.EnsureField(site.RootWeb.Fields, field);
                    }
                }
            }
        }
    }
}
