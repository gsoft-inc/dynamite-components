using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Portal.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.SP.Authoring.Features.PropagateVariations
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("c4d2e3ae-bd44-4ce1-85bc-13bbf64dc538")]
    public class PropagateVariationsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Method called when the feature is activated
        /// </summary>
        /// <param name="properties">Event arguments</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            using (var featureScope = AuthoringContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var variationHelper = featureScope.Resolve<VariationHelper>();
                var listLocator = featureScope.Resolve<ListLocator>();

                var lists = new List<string>() 
                {
                    PortalLists.ContentRootUrl,
                    PortalLists.NewsRootUrl 
                };

                foreach (var listRootUrl in lists)
                {
                    var contentList = listLocator.GetByUrl(web, "/Lists/" + listRootUrl);
                    variationHelper.SyncList(contentList, "en");
                }
            }
        }
    }
}
