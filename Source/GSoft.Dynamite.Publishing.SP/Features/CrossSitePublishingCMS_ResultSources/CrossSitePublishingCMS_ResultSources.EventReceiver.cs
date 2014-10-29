using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
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
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var logger = featureScope.Resolve<ILogger>();
                    var searchHelper = featureScope.Resolve<ISearchHelper>();
                    var baseResultSourceInfoConfig = featureScope.Resolve<IPublishingResultSourceInfoConfig>();

                    IList<ResultSourceInfo> resultSources = baseResultSourceInfoConfig.ResultSources();

                    // Create base result sources
                    foreach (var resultSource in resultSources)
                    {
                        searchHelper.EnsureResultSource(site, resultSource);
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
                   var searchHelper = featureScope.Resolve<ISearchHelper>();
                   var baseResultSourceInfoConfig = featureScope.Resolve<IPublishingResultSourceInfoConfig>();

                   IList<ResultSourceInfo> resultSources = baseResultSourceInfoConfig.ResultSources();

                   // Delete base result sources
                   foreach (var resultSource in resultSources)
                   {
                       searchHelper.DeleteResultSource(site, resultSource);
                   }
               }
           }
       }
    }
}
