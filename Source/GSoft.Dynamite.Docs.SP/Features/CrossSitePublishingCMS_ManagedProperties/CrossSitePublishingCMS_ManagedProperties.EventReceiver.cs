using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Helpers;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Docs.SP.Features.CrossSitePublishingCMS_ManagedProperties
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("89cbcc01-fe7b-4ae5-b2f9-1efb86a5fc2d")]
    public class CrossSitePublishingCMS_ManagedPropertiesEventReceiver : SPFeatureReceiver
    {
       public override void FeatureActivated(SPFeatureReceiverProperties properties)
       {
           var site = properties.Feature.Parent as SPSite;

           if (site != null)
           {
               using (var featureScope = DocsContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
               {
                   var searchHelper = featureScope.Resolve<ISearchHelper>();
                   var managedProperties = featureScope.Resolve<IDocsManagedPropertyInfoConfig>().ManagedProperties;
                   var logger = featureScope.Resolve<ILogger>();

                   // Create base content types
                   foreach (var managedProperty in managedProperties)
                   {
                       logger.Info("Creating search managed property {0}", managedProperty.Name);
                       searchHelper.EnsureManagedProperty(site, managedProperty, true);
                   }
               }
           }
       }

       public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
       {
           var site = properties.Feature.Parent as SPSite;

           if (site != null)
           {
               using (var featureScope = DocsContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
               {
                   var searchHelper = featureScope.Resolve<ISearchHelper>();
                   var managedProperties = featureScope.Resolve<IDocsManagedPropertyInfoConfig>().ManagedProperties;
                   var logger = featureScope.Resolve<ILogger>();

                   // Create base content types
                   foreach (var managedProperty in managedProperties)
                   {
                       logger.Info("Deleting search managed property {0}", managedProperty.Name);
                       searchHelper.DeleteManagedProperty(site, managedProperty);
                   }
               }
           }
       }
    }
}
