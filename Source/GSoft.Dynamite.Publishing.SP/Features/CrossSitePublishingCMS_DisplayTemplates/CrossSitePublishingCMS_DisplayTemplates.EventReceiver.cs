using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_DisplayTemplates
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("f2fa3e0c-78cc-4953-9352-dbc752a33642")]
    public class CrossSitePublishingCMS_DisplayTemplatesEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var web = site.RootWeb;
                    var catalog = web.GetCatalog(SPListTemplateType.MasterPageCatalog);
                    var displayTemplateHelper = featureScope.Resolve<DisplayTemplateHelper>();


                    var displayTemplateConfig = featureScope.Resolve<IBasePublishingDisplayTemplateInfoConfig>();
                    var displayTemplates = displayTemplateConfig.DisplayTemplates();
                    var fileList = new List<SPFile>();

                    // Populate the SPFiles list
                    foreach (var displayTemplate in displayTemplates)
                    {
                        fileList.Add(catalog.RootFolder.SubFolders[displayTemplateHelper.DisplayTemplatesFolder].SubFolders[displayTemplate.Category].Files[displayTemplate.HtmlFileName]);
                    }

                    if (fileList.Count > 0)
                    {
                        // Create the JavaScript files
                        displayTemplateHelper.GenerateJavaScriptFile(fileList);
                    }
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            // TODO
        }
    }
}
