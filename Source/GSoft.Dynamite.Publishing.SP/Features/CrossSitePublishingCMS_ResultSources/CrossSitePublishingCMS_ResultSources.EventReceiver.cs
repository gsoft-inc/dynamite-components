using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Portal.SP.Publishing;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_ResultSources
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("c6ad3235-45eb-4993-b21c-1d6a90a4f343")]
    public class CrossSitePublishingCMS_ResultSourcesEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var searchHelper = featureScope.Resolve<SearchHelper>();
                    var baseResultSourceInfoConfig = featureScope.Resolve<IBasePublishingResultSourceInfoConfig>();

                    IDictionary<string, ResultSourceInfo> resultSources = baseResultSourceInfoConfig.ResultSources();

                    // Create base result sources
                    foreach (KeyValuePair<string, ResultSourceInfo> resultSource in resultSources)
                    {
                        searchHelper.EnsureResultSource(site, resultSource.Value);
                    }

                    // Check if custom configuration is present
                    ICustomPublishingResultSourceInfoConfig customResultSourceInfoConfig = null;
                    if (featureScope.TryResolve(out customResultSourceInfoConfig))
                    {
                        logger.Info("Custom result sources configuration override found!");
                        resultSources = customResultSourceInfoConfig.ResultSources();

                        // Create base result sources
                        foreach (KeyValuePair<string, ResultSourceInfo> resultSource in resultSources)
                        {
                            searchHelper.EnsureResultSource(site, resultSource.Value);
                        }
                    }
                    else
                    {
                        logger.Info("No custom catalogs configuration override found!");
                        
                    }
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
