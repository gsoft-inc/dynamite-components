using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Features.CrossSitePublishingCMS_TermDrivenPages
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("5c004e26-0775-4fea-bf77-f6edbabbb6ff")]
    public class CrossSitePublishingCMS_TermDrivenPagesEventReceiver_Obsolete : SPFeatureReceiver
    {
        /// This feature is now obsolete.  It is conserved only for backwards compatilibilty.
        /// Explanation: This feature was site-scoped, and was passing Site.RootWeb to the NavigationHelper.
        /// So the NavigationHelper, when resolving the navigation term set of the web, was always resolving
        /// the root web's navigation term set, which, in the case of variations, wasn't properly configured.
        /// The new feature is now web-scoped, and the feature is activated on all source and target(s) webs.
    }
}
