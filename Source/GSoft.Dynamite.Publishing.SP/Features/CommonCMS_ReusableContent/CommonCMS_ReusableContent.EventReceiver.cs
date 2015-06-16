using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.ReusableContent;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CommonCMS_ReusableContent
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("3df12b55-154b-4d13-9edc-80bd1075d0a8")]
    public class CommonCMS_ReusableContentEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event handler called when the feature is activated
        /// </summary>
        /// <param name="properties">The event arguments</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var reusableContentHelper = featureScope.Resolve<IReusableContentHelper>();
                var reusableContentInfoConfig = featureScope.Resolve<IPublishingReusableContentInfoConfig>();

                reusableContentHelper.EnsureReusableContent(site, reusableContentInfoConfig.ReusableContents);
            }
        }
    }
}