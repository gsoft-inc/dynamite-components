using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
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

                    IList<ResultSourceInfo> resultSources = baseResultSourceInfoConfig.ResultSources();

                    // Create base result sources
                    foreach (var resultSource in resultSources)
                    {
                        searchHelper.EnsureResultSource(site, resultSource);
                    }

                    // Check if custom configuration is present
                    ICustomPublishingResultSourceInfoConfig customResultSourceInfoConfig = null;
                    if (featureScope.TryResolve(out customResultSourceInfoConfig))
                    {
                        logger.Info("Custom result sources configuration override found!");
                        resultSources = customResultSourceInfoConfig.ResultSources();

                        // Create base result sources
                        foreach (var resultSource in resultSources)
                        {
                            searchHelper.EnsureResultSource(site, resultSource);
                        }
                    }
                    else
                    {
                        logger.Info("No custom result sources configuration override found!");
                        
                    }
                }
            }
        }

       public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
       {
           var site = properties.Feature.Parent as SPSite;

           if (site != null)
           {
               using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
               {
                   var logger = featureScope.Resolve<ILogger>();
                   var searchHelper = featureScope.Resolve<SearchHelper>();
                   var baseResultSourceInfoConfig = featureScope.Resolve<IBasePublishingResultSourceInfoConfig>();

                   IList<ResultSourceInfo> resultSources = baseResultSourceInfoConfig.ResultSources();

                   // Delete base result sources
                   foreach (var resultSource in resultSources)
                   {
                       searchHelper.DeleteResultSource(site, resultSource);
                   }

                   // Check if custom configuration is present
                   ICustomPublishingResultSourceInfoConfig customResultSourceInfoConfig = null;
                   if (featureScope.TryResolve(out customResultSourceInfoConfig))
                   {
                       logger.Info("Custom result sources configuration override found!");
                       resultSources = customResultSourceInfoConfig.ResultSources();

                       // Create base result sources
                       foreach (var resultSource in resultSources)
                       {
                           searchHelper.DeleteResultSource(site, resultSource);
                       }
                   }
                   else
                   {
                       logger.Info("No custom result sources configuration override found!");

                   }
               }
           }
       }
    }
}
