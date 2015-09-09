using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP.Features.CrossSitePublishingCMS_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("81c5599f-f0d7-4971-bc66-fe4b0dcedb2f")]
    public class CrossSitePublishingCmsContentTypesEventReceiver : TargetingContentFeatureReceiver
    {
        /// <summary>
        /// Gets the name of the registration for the 'ITargetingContentConfig' implementation.
        /// </summary>
        /// <value>
        /// The name of the registration.
        /// </value>
        public override string RegistrationName
        {
            get { return RegistrationNames.Docs; }
        }
    }
}
