using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.Portal.SP.Publishing;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Factories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.Internal_Catalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("ca885202-4f15-473d-bd2d-738bec1db6cc")]
    public class Internal_CatalogsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var baseCatalogConfig = featureScope.Resolve<IBaseCatalogInfoConfig>();
                    var catalogFactory = featureScope.Resolve<IBaseCatalogInfoFactory>();
                }
            }
        }
    }
}
