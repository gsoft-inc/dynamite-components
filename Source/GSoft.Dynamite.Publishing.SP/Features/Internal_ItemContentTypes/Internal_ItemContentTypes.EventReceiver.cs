using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Portal.SP.Publishing;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Factories;
using GSoft.Dynamite.Publishing.Contracts.Keys;
using Microsoft.SharePoint;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.SP.Features.Item_ContentTypes
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("9448f2f7-011f-4104-a38e-492fba043a2f")]
    public class Publishing_ContentTypesEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var contentTypeFactory = featureScope.Resolve<IBaseContentTypeInfoFactory>();
                    var baseContentTypeConfig = featureScope.Resolve<IBaseContentTypeInfoConfig>();
                    var baseContentTypes = baseContentTypeConfig.ContentTypes();
                    var logger = featureScope.Resolve<ILogger>();
                    var taxonomyHelper = featureScope.Resolve<TaxonomyHelper>();
                    var termStoreConfig = featureScope.Resolve<IBaseTaxonomyConfig>();

                    var termGroups = termStoreConfig.TermGroups();

                    // Navigation Column
                    taxonomyHelper.AssignTermSetToSiteColumn(
                        site.RootWeb,
                        BaseFieldInfoValues.Navigation.ID,
                        termGroups[BaseTermGroupInfoKeys.NavigationTermGroup].Name,
                        termGroups[BaseTermGroupInfoKeys.NavigationTermGroup].TermSets[BaseTermSetInfoKeys.GlobalNavigationTermSet].Labels[Language.English.Culture.LCID],
                        string.Empty);

                    // Create base content types
                    foreach (KeyValuePair<string, ContentTypeInfo> contentType in baseContentTypes)
                    {
                        contentTypeFactory.CreateContentType(site.RootWeb.ContentTypes, contentType.Value);
                    }

                    // Create additionnal custom content types
                    ICustomContentTypeInfoConfig customContentTypeConfig = null;
                    if (featureScope.TryResolve(out customContentTypeConfig))
                    {
                        var customContentTypes = customContentTypeConfig.ContentTypes();
                        
                        foreach (KeyValuePair<string, ContentTypeInfo> contentType in customContentTypes)
                        {
                            contentTypeFactory.CreateContentType(site.RootWeb.ContentTypes, contentType.Value);
                        }
                    }
                    else
                    {
                        logger.Info("No custom content types override found!");
                    }
                }
            }
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}
    }
}
