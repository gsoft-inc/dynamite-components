using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Features;
using GSoft.Dynamite.Features.Types;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Social.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Social.SP.Features.CommonCMS_DiscussionList
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("9971fb1f-2a4b-41f9-acf6-ada8f723338d")]
    public class CommonCmsDiscussionListEventReceiver : SPFeatureReceiver
    {
        private static FeatureDependencyInfo DiscussionListFeatureDependencyInfo
        {
            get
            {
                return new FeatureDependencyInfo()
                {
                    Name = "Discussions list feature (OOTB)",
                    FeatureId = new Guid("00BFEA71-6A49-43FA-B535-D15C05500108"),
                    ForceReactivation = false,
                    FeatureActivationMode = FeatureActivationMode.CurrentWeb
                };
            }
        }

        /// <summary>
        /// Occurs after a Feature is activated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPFeatureReceiverProperties" /> object that represents the properties of the event.</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var scope = SocialContainerProxy.BeginFeatureLifetimeScope(properties.Feature);
            var logger = scope.Resolve<ILogger>();
            var web = properties.Feature.Parent as SPWeb;
            if (web != null)
            {
                // Resolve the configuration for the social discussions
                var config = scope.Resolve<ISocialDiscussionsConfig>();

                // Ensure that the pages library template feature is activated on the web
                logger.Info("Ensuring discussion list feature '{0}' on web '{1}'", DiscussionListFeatureDependencyInfo.FeatureId, web.Url);
                var featureActivator = scope.Resolve<IFeatureDependencyActivator>(
                    new TypedParameter(typeof(SPWeb), web));
                featureActivator.EnsureFeatureActivation(DiscussionListFeatureDependencyInfo);

                // Ensure the discussion list on the web
                logger.Info("Ensuring discussion list '{0}' on web '{1}'", config.DiscussionListInfo.WebRelativeUrl, web.Url);
                var listHelper = scope.Resolve<IListHelper>();
                listHelper.EnsureList(web, config.DiscussionListInfo);
            }
            else
            {
                logger.Error("Could not resolve SPWeb feature parent for feature 'CommonCmsDiscussionListEventReceiver' activation");
            }
        }
    }
}
