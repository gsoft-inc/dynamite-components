using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Security;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CommonCMS_Fields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("9611ef57-7a3a-4016-ad86-c0bae58b4e0c")]
    public class Internal_FieldsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var fieldInfoConfig = featureScope.Resolve<IPublishingFieldInfoConfig>();
                    var fields = fieldInfoConfig.Fields;
                    var logger = featureScope.Resolve<ILogger>();

                    using (new Unsafe(site.RootWeb))
                    {
                        // Create base Fields
                        foreach (var field in fields)
                        {
                            logger.Info("Creating field {0} on site {1}", field.InternalName, site.Url);
                            fieldHelper.EnsureField(site.RootWeb.Fields, field);
                        } 
                    }
                }
            }
        }
    }
}
