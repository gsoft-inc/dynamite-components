using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Features;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CommonCMS_DisplayTemplates
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("f2fa3e0c-78cc-4953-9352-dbc752a33642")]
    public class CommonCMS_DisplayTemplatesEventReceiver : SPFeatureReceiver
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
                    var web = site.RootWeb;
                    var catalog = web.GetCatalog(SPListTemplateType.MasterPageCatalog);
                    var displayTemplateHelper = featureScope.Resolve<IDisplayTemplateHelper>();

                    var displayTemplateConfig = featureScope.Resolve<IPublishingDisplayTemplateInfoConfig>();
                    var displayTemplates = displayTemplateConfig.DisplayTemplates;
                    var fileList = new List<SPFile>();

                    // Resolve feature dependency activator
                    // Note: Need to pass the site and web objects to support site and web scoped features.
                    var featureDependencyActivator =
                        featureScope.Resolve<IFeatureDependencyActivator>(
                            new TypedParameter(typeof(SPSite), site),
                            new TypedParameter(typeof(SPWeb), site.RootWeb));

                    // Activate feature dependencies defined in this configuration
                    featureDependencyActivator.EnsureFeatureActivation(displayTemplateConfig as IFeatureDependencyConfig);

                    // Populate the SPFiles list
                    foreach (var displayTemplate in displayTemplates)
                    {
                        fileList.Add(catalog.RootFolder.SubFolders[displayTemplateHelper.DisplayTemplatesFolder].SubFolders[displayTemplate.CategoryFolderName].Files[displayTemplate.HtmlFileName]);
                    }

                    if (fileList.Count > 0)
                    {
                        // Create the JavaScript files
                        displayTemplateHelper.GenerateJavaScriptFile(fileList);
                    }
                }
            }
        }
    }
}
