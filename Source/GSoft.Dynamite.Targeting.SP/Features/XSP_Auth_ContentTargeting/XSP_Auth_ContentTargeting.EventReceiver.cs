using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.SP.Features.CrossSitePublishingCMS_Catalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("bbbc8a60-c310-43b8-ad7e-83696bede5be")]
    public class CrossSitePublishingCmsCatalogsEventReceiver : TargetingContentFeatureReceiver
    {
        /// <summary>
        /// Gets the name of the registration for the 'ITargetingContentConfig' implementation.
        /// </summary>
        /// <value>
        /// The name of the registration.
        /// </value>
        public override string RegistrationName
        {
            get { return RegistrationNames.Auth; }
        }
    }
}
