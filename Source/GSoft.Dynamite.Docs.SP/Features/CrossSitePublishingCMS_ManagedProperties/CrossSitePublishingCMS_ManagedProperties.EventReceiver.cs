using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Search;
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
        /// <summary>
        /// Ensures ALL search managed properties got from modules configurations
        /// </summary>
        /// <param name="properties">The event properties</param>
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

                   foreach (var managedProperty in managedProperties)
                   {
                       logger.Info("Creating search managed property {0}", managedProperty.Name);
                       searchHelper.EnsureManagedProperty(site, managedProperty, true);
                   }
               }
           }
       }

       /// <summary>
       /// Removes ALL search managed properties got from modules configurations
       /// </summary>
       /// <param name="properties">The event properties</param>
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
