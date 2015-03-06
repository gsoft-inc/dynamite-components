using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using Microsoft.SharePoint;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Security;

namespace GSoft.Dynamite.Search.SP.Features.CrossSitePublishingCMS_Fields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("2557a658-3616-4dbd-82dc-f031561a0117")]
    public class CrossSitePublishingCMS_FieldsEventReceiver : SPFeatureReceiver
    {
        // <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = SearchContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var fieldInfoConfig = featureScope.Resolve<ISearchFieldInfoConfig>();
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
