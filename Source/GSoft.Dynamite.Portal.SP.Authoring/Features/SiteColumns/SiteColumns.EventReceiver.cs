using System;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;
using Microsoft.SharePoint;
using GSoft.Dynamite.Portal.Contracts.Config;

namespace GSoft.Dynamite.Portal.SP.Authoring.Features.SiteColumns
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("04d803cf-a3d1-43cc-9d2b-eaee408d80ad")]
    public class SiteColumnsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event handler for feature activation
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = AuthoringContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var taxonomyHelper = featureScope.Resolve<TaxonomyHelper>();
                    var termStoreConfig = featureScope.Resolve<IPortalTermStoreConfig>();

                    // Navigation
                    taxonomyHelper.AssignTermSetToSiteColumn(
                        site.RootWeb,
                        PortalFields.Navigation.ID,
                        termStoreConfig.PortalNavigationTermSetGroup,
                        termStoreConfig.NavigationFRTermSet,
                        string.Empty);

                    // Subject
                    taxonomyHelper.AssignTermSetToSiteColumn(
                        site.RootWeb,
                        PortalFields.Subject.ID,
                        termStoreConfig.PortalContentTermSetGroup,
                        termStoreConfig.SubjectTermSet,
                        string.Empty);

                    // Node Title
                    taxonomyHelper.AssignTermSetToSiteColumn(
                        site.RootWeb,
                        PortalFields.Navigation.ID,
                        termStoreConfig.PortalNavigationTermSetGroup,
                        termStoreConfig.NavigationFRTermSet,
                        string.Empty);
                }
            }
        }
    }
}
