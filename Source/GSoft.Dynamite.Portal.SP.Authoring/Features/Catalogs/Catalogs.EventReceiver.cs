using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Factories;
using GSoft.Dynamite.SiteColumns;
using Microsoft.SharePoint;
using GSoft.Dynamite.Portal.Contracts.Config;

namespace GSoft.Dynamite.Portal.SP.Authoring.Features.Catalogs
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("0c65228a-2dcc-4617-826d-75d05be2e0b2")]
    public class CatalogsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Event handler for the feature activation
        /// </summary>
        /// <param name="properties">the event properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            using (var featureScope = AuthoringContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var catalogBuilder = featureScope.Resolve<CatalogBuilder>();
                var listViewFactory = featureScope.Resolve<IListViewFactory>();
                var termStoreConfig = featureScope.Resolve<IPortalTermStoreConfig>();

                // Content Catalog
                var genericCatalog = new Catalog()
                {
                    RootFolderUrl = PortalLists.ContentRootUrl,
                    Overwrite = true,
                    RemoveDefaultContentType = true,
                    DisplayName = "Contenu",
                    Description = string.Empty,
                    ListTemplate = SPListTemplateType.GenericList,
                    TaxonomyFieldMap = PortalFields.Navigation.InternalName,
                    DraftVisibilityType = DraftVisibilityType.Approver,
                    HasDraftVisibilityType = true,
                    EnableRatings = false,
                    WriteSecurity = WriteSecurityOptions.OwnerOnly,
                    ContentTypeIds = new List<SPContentTypeId>() { PortalContentTypes.ContentItemContentTypeId },
                    Segments = new List<SiteColumnField>()
                    {
                        new TaxoField()
                        {
                            InternalName = PortalFields.Navigation.InternalName,
                            DisplayName = string.Empty,
                            Description = string.Empty,
                            IsRequired = true,
                            Group = "Portal",
                            IsMultiple = false,
                            IsOpen = false,
                            TermSetGroupName = termStoreConfig.PortalNavigationTermSetGroup,
                            TermSetName = web.Language == Language.English.Culture.LCID ? termStoreConfig.NavigationENTermSet : termStoreConfig.NavigationFRTermSet,
                            TermSubsetName = "Members",
                        }
                    },
                    ManagedProperties = new List<string>() { PortalManagedProperties.PortalDateSlug, PortalManagedProperties.ListItemID, PortalManagedProperties.PortalSlug },
                };
                catalogBuilder.ProcessCatalog(web, genericCatalog);
                listViewFactory.CreateContentCatalogView(web, genericCatalog);

                // News Catalog
                genericCatalog.RootFolderUrl = PortalLists.NewsRootUrl;
                genericCatalog.DisplayName = "Actualités";
                genericCatalog.ContentTypeIds = new List<SPContentTypeId>() { PortalContentTypes.NewsItemContentTypeId };
                genericCatalog.Segments[0] = new TaxoField()
                {
                    InternalName = PortalFields.Navigation.InternalName,
                    DisplayName = string.Empty,
                    Description = string.Empty,
                    IsRequired = true,
                    Group = "Portal",
                    IsMultiple = false,
                    IsOpen = false,
                    TermSetGroupName = termStoreConfig.PortalNavigationTermSetGroup,
                    TermSetName = web.Language == Language.English.Culture.LCID ? termStoreConfig.NavigationENTermSet : termStoreConfig.NavigationFRTermSet,
                    TermSubsetName = termStoreConfig.CatalogNewsSubSet,
                };
                genericCatalog.DefaultValues = new List<SiteColumnField>()
                {
                    new TaxoField()
                    {
                        InternalName = PortalFields.Navigation.InternalName,
                        TermSetGroupName = termStoreConfig.PortalNavigationTermSetGroup,
                        TermSetName = web.Language == Language.English.Culture.LCID ? termStoreConfig.NavigationENTermSet : termStoreConfig.NavigationFRTermSet,
                        TermSubsetName = termStoreConfig.CatalogNewsSubSet,
                        DefaultValues = new List<string>() {"News"}
                    }
                };

                var newsList = catalogBuilder.ProcessCatalog(web, genericCatalog);
                listViewFactory.CreateNewsCatalogView(web, genericCatalog);

                // Mode Description Catalog
                genericCatalog.RootFolderUrl = PortalLists.NodeDescriptionRootUrl;
                genericCatalog.DisplayName = "Descriptions de noeud";
                genericCatalog.TaxonomyFieldMap = string.Empty;
                genericCatalog.ContentTypeIds = new List<SPContentTypeId>() { PortalContentTypes.NodeDescriptionItemContentTypeId };
                genericCatalog.Segments[0] = new TaxoField()
                {
                    InternalName = PortalFields.Navigation.InternalName,
                    DisplayName = string.Empty,
                    Description = string.Empty,
                    IsRequired = true,
                    Group = "Portal",
                    IsMultiple = false,
                    IsOpen = false,
                    TermSetGroupName = termStoreConfig.PortalCatalogsTermSetGroup,
                    TermSetName = termStoreConfig.CatalogGlobalTermSet,
                    TermSubsetName = string.Empty
                };
                genericCatalog.DefaultValues = null;
                genericCatalog.ManagedProperties = null;
                catalogBuilder.ProcessCatalog(web, genericCatalog);
                listViewFactory.CreateNodeDescriptionCatalogView(web, genericCatalog);
            }
        }
    }
}
