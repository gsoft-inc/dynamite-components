using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Configuration;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_CatalogConnections
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("7c9333fa-7084-46bc-bb7a-7a793eb5b694")]
    public class CrossSitePublishingCMS_CatalogConnectionsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var authoringWeb = properties.Feature.Parent as SPWeb;

            if (authoringWeb != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var propertyBagHelper = featureScope.Resolve<IPropertyBagHelper>();
                    var catalogHelper = featureScope.Resolve<ICatalogHelper>();
                    var catalogConnections= featureScope.Resolve<INavigationCatalogConnectionInfoConfig>().CatalogConnections;
                    var logger = featureScope.Resolve<ILogger>();

                    // Get the url of the associated publishing site for the current web
                    var publishingSiteUrl = propertyBagHelper.GetWebValue(authoringWeb, "DSP_AssociatedPublishingSite");
                    if (!string.IsNullOrEmpty(publishingSiteUrl))
                    {
                        using (var publishingSite = new SPSite(publishingSiteUrl))
                        {
                            // Open the associated SPWeb
                            var publishingWeb = publishingSite.OpenWeb();

                            // Create catalog connections
                            foreach (var catalogConnection in catalogConnections)
                            {
                                // Update the connected web with the publishing web
                                catalogConnection.TargetWeb = publishingWeb;
                                catalogConnection.SourceWeb = authoringWeb;

                                logger.Info("Connecting catalog {0} form {1} to the site {2}", 
                                    catalogConnection.Catalog.RootFolderUrl,
                                    authoringWeb.Url,
                                    publishingWeb.Url
                                    );

                                catalogHelper.EnsureCatalogConnection(publishingSite, catalogConnection, true);
                            }
                        }
                    }
                    else
                    {
                        logger.Info("Unable to find the DSP_AssociatedPublishingSite property bag value for the  web {0}", authoringWeb.Url);
                    }
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var authoringWeb = properties.Feature.Parent as SPWeb;

            if (authoringWeb != null)
            {
                using (var featureScope = NavigationContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var propertyBagHelper = featureScope.Resolve<IPropertyBagHelper>();
                    var catalogHelper = featureScope.Resolve<ICatalogHelper>();
                    var catalogConnections = featureScope.Resolve<INavigationCatalogConnectionInfoConfig>().CatalogConnections;
                    var logger = featureScope.Resolve<ILogger>();

                    // Get the url of the associated publishing site for the current web
                    var publishingSiteUrl = propertyBagHelper.GetWebValue(authoringWeb, "DSP_AssociatedPublishingSite");
                    if (!string.IsNullOrEmpty(publishingSiteUrl))
                    {
                        using (var publishingSite = new SPSite(publishingSiteUrl))
                        {
                            // Open the associated SPWeb
                            var publishingWeb = publishingSite.OpenWeb();

                            // Create catalog connections
                            foreach (var catalogConnection in catalogConnections)
                            {
                                // Update the connected web with the publishing web
                                catalogConnection.TargetWeb = publishingWeb;
                                catalogConnection.SourceWeb = authoringWeb;

                                logger.Info("Deleting catalog {0} form {1} to the site {2}",
                                    catalogConnection.Catalog.RootFolderUrl,
                                    authoringWeb.Url,
                                    publishingWeb.Url
                                    );

                                catalogHelper.DeleteCatalogConnection(publishingSite, catalogConnection);
                            }
                        }
                    }
                    else
                    {
                        logger.Info("Unable to find the DSP_AssociatedPublishingSite property bag value for the  web {0}", authoringWeb.Url);
                    }
                }
            }
        }
    }
}
