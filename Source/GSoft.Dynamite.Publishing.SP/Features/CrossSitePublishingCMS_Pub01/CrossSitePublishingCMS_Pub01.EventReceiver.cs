using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Publishing.Contracts.Stories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_Pub01
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("7c88e094-17de-416d-83bd-7d6d2776a318")]
    public class CrossSitePublishingCmsPub01EventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Occurs after a Feature is activated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPFeatureReceiverProperties" /> object that represents the properties of the event.</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            using (var scope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                scope.ResolveNamed<IPub01Config>("xsp").Install();
            }
        }
    }
}
