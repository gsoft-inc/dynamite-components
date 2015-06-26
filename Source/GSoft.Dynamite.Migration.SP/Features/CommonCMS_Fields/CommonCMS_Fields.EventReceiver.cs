using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Migration.SP.Features.CommonCMS_Fields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("a38203e2-762d-4379-8c2a-fab5dc426817")]
    public class CommonCMS_FieldsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Ensure fields for the document management module
        /// </summary>
        /// <param name="properties">The event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = MigrationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var baseFieldInfoConfig = featureScope.Resolve<IMigrationFieldInfoConfig>();
                    var baseFields = baseFieldInfoConfig.Fields;
                    var logger = featureScope.Resolve<ILogger>();

                    // Create base Fields
                    foreach (BaseFieldInfo field in baseFields)
                    {
                        logger.Info("Creating field {0} in site {1}", field.InternalName, site.Url);
                        fieldHelper.EnsureField(site.RootWeb.Fields, field);
                    }
                }
            }
        }
    }
}
